using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BepInEx;

namespace WitchSpringRTestPlugin
{
    public static class BridgeClient
    {
        // Rooted in the game's install folder so the game mod and the AP client agree on
        // the location on every OS (including the game running under Proton on Linux).
        private static readonly string RootDir =
            Path.Combine(Paths.GameRootPath, "Archipelago");

        private static readonly string ActiveSessionPath =
            Path.Combine(RootDir, "active_session.json");

        private static string lastLoggedBridgeDir = "";

        private static string BridgeDir
        {
            get
            {
                string sessionDir = TryReadActiveSessionBridgeDir();

                if (!string.IsNullOrWhiteSpace(sessionDir))
                    return sessionDir;
                return "";
            }
        }

        public static bool EnsureBridgeDir()
        {
            if (!HasActiveSession())
            {
                Plugin.Log.LogWarning("No active_session.json found. Start/Connect the WitchSpring R AP Client before launching the game.");
                return false;
            }

            Directory.CreateDirectory(BridgeDir);
            return true;
        }

        public static string ReceivedItemsPath =>
            Path.Combine(BridgeDir, "received_items.json");

        public static string CheckedLocationsPath =>
            Path.Combine(BridgeDir, "checked_locations.json");

        public static string ProcessedReceivedIndexPath =>
            Path.Combine(BridgeDir, "processed_received_index.txt");

        private static string TryReadActiveSessionBridgeDir()
        {
            try
            {
                if (!File.Exists(ActiveSessionPath))
                    return "";

                string json = File.ReadAllText(ActiveSessionPath);

                // The client writes the session folder name relative to <game>/Archipelago/Sessions,
                // so no absolute path (with OS-specific separators) ever crosses the bridge.
                Match match = Regex.Match(
                    json,
                    "\"session_dir\"\\s*:\\s*\"([^\"]+)\""
                );

                if (!match.Success)
                    return "";

                string bridgeDir = Path.Combine(RootDir, "Sessions", match.Groups[1].Value);

                if (bridgeDir != lastLoggedBridgeDir)
                {
                    lastLoggedBridgeDir = bridgeDir;
                    Plugin.Log.LogInfo($"Using bridge dir: {bridgeDir}");
                }

                return bridgeDir;
            }
            catch
            {
                return "";
            }
        }

        //private static void EnsureBridgeDir()
        //{
        //    Directory.CreateDirectory(BridgeDir);
        //}

        public static bool HasActiveSession()
        {
            return !string.IsNullOrWhiteSpace(BridgeDir);
        }

        // A switch-name-safe tag uniquely identifying the active seed+team+slot+name
        // (the Sessions folder name). Used to namespace the AP_RECV save markers so a
        // game save reused across different seeds can never read another seed's markers.
        public static string GetSessionTag()
        {
            string dir = BridgeDir;
            if (string.IsNullOrEmpty(dir))
                return "";
            string name = Path.GetFileName(dir);
            return Regex.Replace(name, "[^A-Za-z0-9]", "_");
        }

        // Checks wait here until they are safely on disk; if a write fails (file
        // briefly locked by the client, disk hiccup, ...) they are retried every
        // scanner tick instead of being lost.
        private static readonly HashSet<long> pendingChecks = new HashSet<long>();

        public static void WriteCheckedLocation(long locationId)
        {
            pendingChecks.Add(locationId);
            Plugin.Log.LogInfo($"Sent AP location check: {locationId}");
            FlushPendingChecks();
        }

        public static void FlushPendingChecks()
        {
            if (pendingChecks.Count == 0)
                return;

            try
            {
                if (!EnsureBridgeDir())
                    return;

                // checked_locations.json is a permanent ledger: only ever grows,
                // never cleared. The client dedupes against the server, so stale
                // entries are harmless and the file is bounded by total locations.
                HashSet<long> checkedLocations = new HashSet<long>(pendingChecks);

                if (File.Exists(CheckedLocationsPath))
                {
                    string existingJson = File.ReadAllText(CheckedLocationsPath);

                    MatchCollection matches = Regex.Matches(existingJson, @"\d+");

                    foreach (Match match in matches)
                    {
                        if (long.TryParse(match.Value, out long existingId))
                            checkedLocations.Add(existingId);
                    }
                }

                string json = "{\n  \"checked_locations\": [" + string.Join(", ", checkedLocations) + "]\n}";

                // write-then-rename so the client can never read a half-written file
                string tempPath = CheckedLocationsPath + ".tmp";
                File.WriteAllText(tempPath, json);
                File.Move(tempPath, CheckedLocationsPath, true);

                pendingChecks.Clear();
            }
            catch (Exception ex)
            {
                Plugin.Log.LogWarning($"checked_locations.json write failed, will retry: {ex.Message}");
            }
        }

        private static string cachedReceivedJson = "";
        private static DateTime cachedReceivedAt = DateTime.MinValue;

        // Whether an AP item with this display name has been received. Caches the
        // received_items.json text for ~1s because this can be called from the
        // CheckSwitch gate hook, which the game may poll frequently.
        public static bool HasReceivedItem(string itemName)
        {
            if ((DateTime.UtcNow - cachedReceivedAt).TotalSeconds > 1.0)
            {
                cachedReceivedJson = ReadReceivedItemsJson() ?? "";
                cachedReceivedAt = DateTime.UtcNow;
            }

            if (string.IsNullOrEmpty(cachedReceivedJson))
                return false;

            return cachedReceivedJson.Contains($"\"item\": \"{itemName}\"")
                || cachedReceivedJson.Contains($"\"item\":\"{itemName}\"");
        }

        public static string ReadReceivedItemsJson()
        {
            if (!HasActiveSession())
            {
                Plugin.Log.LogWarning("No active AP session. Skipping received item read.");
                return "";
            }
            if (!File.Exists(ReceivedItemsPath))
              {
                Plugin.Log.LogWarning("received_items.json not found");
                return "";
              }
            return File.ReadAllText(ReceivedItemsPath);
        }

        public static int ReadProcessedReceivedIndex()
        {
            if (!HasActiveSession())
                return -1;
            if (!File.Exists(ProcessedReceivedIndexPath))
                return -1;

            string text = File.ReadAllText(ProcessedReceivedIndexPath).Trim();

            if (int.TryParse(text, out int value))
                return value;

            return -1;
        }

        public static void WriteProcessedReceivedIndex(int index)
        {
            if (!EnsureBridgeDir()) return;
            File.WriteAllText(ProcessedReceivedIndexPath, index.ToString());
            Plugin.Log.LogInfo($"Updated processed AP item index: {index}");
        }

        public static string UndeliverableItemsPath =>
            Path.Combine(BridgeDir, "undeliverable_items.txt");

        // Append an item the game refused to accept, so a skipped delivery is visible
        // to the player/dev instead of only living in the BepInEx log.
        public static void RecordUndeliverableItem(int index, string itemName)
        {
            try
            {
                if (!EnsureBridgeDir()) return;
                File.AppendAllText(UndeliverableItemsPath, $"#{index}\t{itemName}\n");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogWarning($"Could not record undeliverable item: {ex.Message}");
            }
        }
    }
}