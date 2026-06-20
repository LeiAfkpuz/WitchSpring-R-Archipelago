using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using WS1RCLASS;

namespace WitchSpringRTestPlugin
{
    public class ReceivedItemScanner
    {
        private readonly List<ReceivedApItem> parsedItems = new();

        // The save file carries an "AP_RECV_<n>" marker switch recording the last
        // item index actually delivered into THAT save. When the loaded save's
        // marker is behind processed_received_index.txt (crash before saving,
        // Alt+F4, or loading an older slot), we rewind the index so those items
        // get re-delivered instead of being lost.
        private bool needsSaveReconcile = true;

        // How many times the game's AddItem may reject a specific item before we
        // give up on it and skip ahead, so one bad item can't block the whole queue.
        private const int MaxGrantAttempts = 5;
        private readonly Dictionary<int, int> grantAttempts = new();

        private class ReceivedApItem
        {
            public int Index;
            public string ItemName = "";
            public string Message = "";
        }

        public void Scan()
        {
            if (!IsInGame())
            {
                // next time we're back in gameplay we may be in a freshly loaded save
                needsSaveReconcile = true;
                return;
            }

            string json = BridgeClient.ReadReceivedItemsJson();

            if (string.IsNullOrWhiteSpace(json))
                return;

            ParseReceivedItems(json);

            if (parsedItems.Count == 0)
                return;

            int processedIndex = BridgeClient.ReadProcessedReceivedIndex();

            // Markers are namespaced by the active session (seed+team+slot+name) so a
            // save reused across seeds can never read another seed's delivery markers.
            string sessionTag = BridgeClient.GetSessionTag();

            if (needsSaveReconcile)
            {
                DataSet dataSet = UnityEngine.Object.FindObjectOfType<DataSet>();

                if (dataSet == null)
                    return; // don't grant anything until we could reconcile

                int savedIndex = ReadIndexMarkerFromSave(dataSet, processedIndex, sessionTag);

                if (savedIndex < processedIndex)
                {
                    Plugin.LogRef.LogWarning(
                        $"[AP] Save is behind the delivery log (save: #{savedIndex}, log: #{processedIndex}). " +
                        $"Rewinding so items #{savedIndex + 1}-#{processedIndex} get re-delivered."
                    );

                    BridgeClient.WriteProcessedReceivedIndex(savedIndex);
                    processedIndex = savedIndex;
                }

                needsSaveReconcile = false;
            }

            // If the gameplay scene is still initializing, DataSet won't exist yet.
            // Treat that as transient: try again next tick without burning retries.
            if (UnityEngine.Object.FindObjectOfType<DataSet>() == null)
                return;

            foreach (ReceivedApItem item in parsedItems)
            {
                //if (ItemGranting.PlayerAlreadyHasItem(item.ItemName))
                //    continue;

                if (item.Index <= processedIndex)
                    continue;

                Plugin.LogRef.LogWarning(
                    $"[AP] Processing received item #{item.Index} {item.ItemName}"
                );

                bool granted = ItemGranting.GrantItem(item.ItemName);

                if (!granted)
                {
                    int attempts = grantAttempts.TryGetValue(item.Index, out int prior) ? prior + 1 : 1;
                    grantAttempts[item.Index] = attempts;

                    if (attempts < MaxGrantAttempts)
                    {
                        // Might be a momentary state (mid scene transition, UI not up).
                        // Stop here and retry the SAME item on the next tick so we keep
                        // delivery in order.
                        Plugin.LogRef.LogWarning(
                            $"Grant failed for AP item #{item.Index} ({item.ItemName}), " +
                            $"attempt {attempts}/{MaxGrantAttempts}; will retry next tick."
                        );
                        return;
                    }

                    // The game keeps rejecting this specific item id (e.g. an item that
                    // can't be added this way). Skip it so everything BEHIND it - which
                    // may include progression - still gets delivered. The skip is logged
                    // and recorded so the lost item is visible.
                    Plugin.LogRef.LogError(
                        $"[AP] Could not deliver item #{item.Index} ({item.ItemName}) after " +
                        $"{MaxGrantAttempts} tries - the game rejected it. SKIPPING so later items arrive."
                    );
                    BridgeClient.RecordUndeliverableItem(item.Index, item.ItemName);
                    // fall through to mark it processed and continue the queue
                }
                else if (!string.IsNullOrEmpty(item.Message))
                {
                    // Only announce items we actually delivered (skipped ones already
                    // logged an error above).
                    UIMessage.Show(item.Message);
                }

                WriteIndexMarkerToSave(processedIndex, item.Index, sessionTag);
                BridgeClient.WriteProcessedReceivedIndex(item.Index);
                processedIndex = item.Index;
            }
        }

        private static string MarkerName(string sessionTag, int index)
        {
            return $"AP_RECV_{sessionTag}_{index}";
        }

        private static int ReadIndexMarkerFromSave(DataSet dataSet, int processedIndex, string sessionTag)
        {
            if (processedIndex < 0)
                return processedIndex;

            try
            {
                for (int n = processedIndex; n >= 0; n--)
                {
                    if (dataSet.CheckSwitch(MarkerName(sessionTag, n)))
                        return n;
                }
            }
            catch (System.Exception ex)
            {
                // probing failed - keep the file index rather than re-delivering on bad data
                Plugin.LogRef.LogWarning($"Could not read AP receive marker from save: {ex.Message}");
                return processedIndex;
            }

            return -1; // no marker for this session: fresh save (or pre-update save) - deliver everything
        }

        private static void WriteIndexMarkerToSave(int previousIndex, int newIndex, string sessionTag)
        {
            try
            {
                DataSet dataSet = UnityEngine.Object.FindObjectOfType<DataSet>();

                if (dataSet == null)
                    return;

                // set the new marker before clearing the old one - if we crash in
                // between, the reconcile probe takes the highest marker it finds
                dataSet.SetSwitchOn(MarkerName(sessionTag, newIndex));

                if (previousIndex >= 0 && previousIndex != newIndex)
                    dataSet.SetSwitchOff(MarkerName(sessionTag, previousIndex));
            }
            catch (System.Exception ex)
            {
                Plugin.LogRef.LogWarning($"Could not record AP receive marker in save: {ex.Message}");
            }
        }

        private void ParseReceivedItems(string json)
        {
            parsedItems.Clear();

            MatchCollection matches = Regex.Matches(
                json,
                "\"index\"\\s*:\\s*(\\d+)[\\s\\S]*?\"item\"\\s*:\\s*\"([^\"]+)\"[\\s\\S]*?\"message\"\\s*:\\s*\"([^\"]+)\""
            );

            // Fall back to the message-less shape so an older received_items.json still
            // delivers items (just without the "Received X" popup).
            if (matches.Count == 0)
            {
                matches = Regex.Matches(
                    json,
                    "\"index\"\\s*:\\s*(\\d+)[\\s\\S]*?\"item\"\\s*:\\s*\"([^\"]+)\""
                );
            }

            foreach (Match match in matches)
            {
                int index = int.Parse(match.Groups[1].Value);
                string itemName = match.Groups[2].Value.Trim();
                string message = match.Groups.Count > 3 ? match.Groups[3].Value.Trim() : "";

                if (!string.IsNullOrEmpty(itemName))
                {
                    parsedItems.Add(new ReceivedApItem
                    {
                        Index = index,
                        ItemName = itemName,
                        Message = message
                    });
                }
            }
        }

        // Scenes where it's safe to deliver received items: every gameplay map / town /
        // cave / temple in the game. Built by unioning the offline event dump, the plugin's
        // field-item checks, and the apworld locations. Title, prologue, and ending-cutscene
        // scenes are deliberately excluded; battles are an in-place overlay (no scene of
        // their own) so they're excluded automatically. If a brand-new scene name ever shows
        // up, add it here (regen via the allowlist build in the Events Full Dump tooling).
        private static readonly HashSet<string> GameplayScenes = new HashSet<string>
        {
            "Cave_BoarMountain",
            "Cave_BoarMountain_New",
            "Cave_Castle_Mine",
            "Cave_Castle_Mine2",
            "Cave_Castle_Mine_New",
            "Cave_Crystal",
            "Cave_Dark",
            "Cave_Dog",
            "Cave_Golem_BackMountain",
            "Cave_Golem_BackMountain_2",
            "Cave_Golem_BackMountain_Fire",
            "Cave_Golem_BackMountain_Fire_2",
            "Cave_Golem_BackMountain_Fire_3",
            "Cave_Golem_BackMountain_Fire_4",
            "Cave_Golem_BackMountain_Fire_Blast",
            "Cave_Golem_BackMountain_Fire_Cow",
            "Cave_Golem_BackMountain_Fox",
            "Cave_Kench",
            "Cave_Lalaque_Mine",
            "Cave_Lalaque_Mine_CannaArea_1",
            "Cave_Lalaque_Mine_CannaArea_2",
            "Cave_Lalaque_Mine_CannaArea_3",
            "Cave_Lalaque_Mine_CannaArea_3_New",
            "Cave_Lalaque_Mine_CannaArea_4",
            "Cave_Lalaque_Mine_CannaArea_Store",
            "Cave_Lalaque_Mine_Caric",
            "Cave_Lalaque_Mine_Caric_New",
            "Cave_LunaCave",
            "Cave_Nightmare",
            "Cave_Nightmare_New",
            "Cave_Pirate",
            "Cave_Pudding",
            "Cave_Pudding_2",
            "Cave_Pudding_2_New",
            "Cave_Pudding_3",
            "Cave_Pudding_New",
            "Cave_Rabbit",
            "Cave_RedBeard",
            "Cave_RedBeard_New",
            "Cave_RukeValleyGrave",
            "Cave_RukeValleyGrave_New",
            "Cave_Thief",
            "Cave_UnderLalaque",
            "Cave_UnderLalaque2",
            "Cave_UnderLalaque3",
            "Cave_UnderTemple_1",
            "Cave_UnderTemple_2",
            "Cave_UnderTemple_3",
            "Cave_UnderTemple_4",
            "Cave_UnderTemple_5",
            "Cave_UnderTemple_6",
            "Cave_UnderTemple_7",
            "Cave_UnderTemple_7_BrokenChair",
            "Cave_UnderTemple_Jude",
            "Forest_BlackWitch",
            "Forest_BlackWitch_New",
            "Forest_BlackWitch_PetArea",
            "Forest_Boar",
            "Forest_Boar2",
            "Forest_Boar2_New",
            "Forest_Creich",
            "Forest_Elicion",
            "Forest_ElicionTop",
            "Forest_ElicionTop_New",
            "Forest_Elicion_1",
            "Forest_Elicion_2",
            "Forest_Elicion_2_New",
            "Forest_Elicion_Blocked",
            "Forest_Elicion_Lectrino",
            "Forest_Elicion_Rhino",
            "Forest_Kalzbero",
            "Forest_Kench",
            "Forest_Lalaque",
            "Forest_LalaqueEastSouth",
            "Forest_Lalaque_EastSouth",
            "Forest_Lalaque_EastSouth_New",
            "Forest_Lalaque_Maets",
            "Forest_Lalaque_Maets_New",
            "Forest_Lalaque_New",
            "Forest_Lalaque_NorthEast",
            "Forest_Lalaque_NorthEast_New",
            "Forest_Lalaque_NorthWest",
            "Forest_Lalaque_South",
            "Forest_Lalaque_WaterFall",
            "Forest_Lalaque_WestSouth",
            "Forest_Lalaque_WestSouth_New",
            "Forest_Laoba",
            "Forest_Laoba_New",
            "Forest_LionField",
            "Forest_LionField_Mid",
            "Forest_LionField_Side",
            "Forest_NukeField",
            "Forest_NukeField_New",
            "Home",
            "Home_Pieberry",
            "Home_Pieberry_New",
            "House_Anna",
            "House_Anna_new",
            "House_Canna",
            "House_Canna_New",
            "House_LalauqeVillageSet",
            "House_LalauqeVillageSet_New",
            "House_Luna",
            "House_Luna_New",
            "House_Pieberry",
            "Island_Arua",
            "Island_Arua_2",
            "Island_LandNorthWestBeach",
            "Island_LandSouth",
            "Island_LandSouth2",
            "Island_LandSouth_East",
            "Island_MinilEntrance",
            "Island_MinilEntrance_New",
            "Road_Babellia",
            "Road_Babellia2",
            "Road_Babellia2_New",
            "Road_Babellia2_War",
            "Road_Babellia2_War_Rail",
            "Road_Babellia3",
            "Road_Babellia3_New",
            "Road_Babellia4_DurokHill",
            "Road_Babellia_New",
            "Road_Babellia_Night",
            "Road_Babellia_WarriorCamp",
            "Road_Babellia_WarriorCamp_New",
            "Road_NorthHill",
            "Road_NorthHill_New",
            "ShipWrecked_Cannon",
            "ShipWrecked_Enter",
            "ShipWrecked_Prison",
            "ShipWrecked_Top",
            "SnowLand",
            "SnowLand_Cave",
            "SnowLand_Cave2",
            "SnowLand_Cave2_New",
            "SnowLand_Cave3_Race",
            "SnowLand_Cave4_Tialion",
            "SnowLand_Cave5_Necomis",
            "SnowLand_New",
            "SnowLand_Passage",
            "Swamp_1",
            "Swamp_2",
            "Swamp_Pool",
            "Swamp_Pool2",
            "TeasureTest_NukeFly",
            "Temple_Aimhard",
            "Temple_Aimhard_FireField",
            "Temple_Aimhard_Mid",
            "Temple_Aimhard_Spring",
            "Temple_Aimhard_Spring_New",
            "Temple_Aimhard_UnderPrison",
            "Temple_Aimhard_UnderPrison2",
            "Temple_Aimhard_UnderPrison3",
            "Temple_Aramute_Spring",
            "Temple_Aramute_Square",
            "Temple_Arua",
            "Temple_Arua_New",
            "Temple_Arua_Room1",
            "Temple_Arua_Room1_New",
            "Temple_Durok",
            "Temple_Durok_2",
            "Temple_Durok_2_New",
            "Temple_Durok_New",
            "Temple_Durok_Spring",
            "Temple_Durok_Spring_New",
            "Temple_Durok_Temar",
            "Temple_Elicion",
            "Temple_Elicion_Mid",
            "Temple_Elicion_Spring",
            "Temple_Elicion_Spring_New",
            "Temple_Elicion_WaterRoom",
            "Vatican_Lobby2_Night",
            "Vatican_Lobby3_Night",
            "Vatican_Lobby_Night",
            "Vatican_MainHole",
            "Vatican_MainHole_Night",
            "Vatican_Prison",
            "Vatican_Prison_Ice",
            "Vatican_Prison_Underway",
            "Velly_Dragon",
            "Velly_Dragon_Lightning",
            "Velly_Dragon_Lightning_New",
            "Velly_Dragon_Lightning_Passage",
            "Velly_Dragon_New",
            "Velly_Dragon_WhiteRock",
            "Velly_Dragon_WhiteRock_New",
            "Village_Dwarf",
            "Village_Lalaque",
            "Village_Lalaque_New",
            "Village_Lalaque_North",
            "Village_Lalaque_North_New",
            "Village_Lalaque_South",
            "Village_Vabellia_Enter",
            "Village_Vabellia_Enter_New",
            "Village_Vabellia_Grave",
            "Village_Vabellia_Grave_New",
            "Village_Vabellia_InnerSet",
            "Village_Vabellia_InnerSet_New",
            "Village_Vabellia_Night",
            "Village_Vabellia_NightFinal",
        };

        private bool IsInGame()
        {
            return GameplayScenes.Contains(SceneManager.GetActiveScene().name);
        }
    }
}