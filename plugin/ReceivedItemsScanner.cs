using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

namespace WitchSpringRTestPlugin
{
    public class ReceivedItemScanner
    {
        private readonly List<ReceivedApItem> parsedItems = new();

        private class ReceivedApItem
        {
            public int Index;
            public string ItemName = "";
        }

        public void Scan()
        {
            if (!IsInGame())
                return;

            string json = BridgeClient.ReadReceivedItemsJson();

            if (string.IsNullOrWhiteSpace(json))
                return;

            ParseReceivedItems(json);

            if (parsedItems.Count == 0)
                return;

            int processedIndex = BridgeClient.ReadProcessedReceivedIndex();

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
                    Plugin.LogRef.LogWarning(
                        $"Grant failed for AP item #{item.Index}: {item.ItemName}"
                    );

                    return;
                }
                BridgeClient.WriteProcessedReceivedIndex(item.Index);
                processedIndex = item.Index;
            }
        }

        private void ParseReceivedItems(string json)
        {
            parsedItems.Clear();

            MatchCollection matches = Regex.Matches(
                json,
                "\"index\"\\s*:\\s*(\\d+)[\\s\\S]*?\"item\"\\s*:\\s*\"([^\"]+)\""
            );

            foreach (Match match in matches)
            {
                int index = int.Parse(match.Groups[1].Value);
                string itemName = match.Groups[2].Value.Trim();

                if (!string.IsNullOrEmpty(itemName))
                {
                    parsedItems.Add(new ReceivedApItem
                    {
                        Index = index,
                        ItemName = itemName
                    });
                }
            }
        }

        private bool IsInGame()
        {
            string scene = SceneManager.GetActiveScene().name;

            return scene == "Forest_BlackWitch"
                || scene == "House_Pieberry"
                || scene == "Temple_Arua"
                || scene == "House_LalauqeVillageSet"
                || scene == "Temple_Arua_Room1"
                || scene == "House_Anna"
                || scene == "Village_Lalaque_North"
                || scene == "Cave_Lalaque_Mine"
                || scene == "Cave_Lalaque_Mine_CannaArea_1"
                || scene == "Cave_Lalaque_Mine_CannaArea_2"
                || scene == "Cave_Lalaque_Mine_CannaArea_3"
                || scene == "Cave_Lalaque_Mine_CannaArea_4"
                || scene == "Cave_Lalaque_Mine_CannaArea_Store"
                || scene == "Cave_Pudding"
                || scene == "Cave_Pudding_2"
                || scene == "Cave_Pudding_3"
                || scene == "Swamp_1"
                || scene == "Cave_Golem_BackMountain"
                || scene == "Cave_Golem_BackMountain_Fire"
                || scene == "Cave_Golem_BackMountain_Fox"
                || scene == "Cave_Golem_BackMountain_Fire_2"
                || scene == "Cave_Golem_BackMountain_Fire_Cow"
                || scene == "Island_Arua"
                || scene == "Forest_Boar"
                || scene == "Road_NorthHill"
                || scene == "Forest_Lalaque"
                || scene == "Forest_Lalaque_WestSouth"
                || scene == "Forest_Lalaque_EastSouth"
                || scene == "Village_Lalaque"
                || scene == "Village_Lalaque_North"
                || scene == "Village_Lalaque_South"
                || scene == "Forest_Lalaque_Maets"
                || scene == "Forest_Lalaque_South"
                || scene == "Forest_Lalaque_NorthWest"
                || scene == "Forest_Lalaque_NorthEast";
        }
    }
}