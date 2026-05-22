using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WitchSpringRTestPlugin
{
    public static class BridgeClient
    {
        private static readonly string RootDir =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Archipelago",
                "WitchspringR"
            );

        private static readonly string ActiveSessionPath =
            Path.Combine(RootDir, "active_session.json");

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

                Match match = Regex.Match(
                    json,
                    "\"bridge_dir\"\\s*:\\s*\"([^\"]+)\""
                );

                if (!match.Success)
                    return "";

                string bridgeDir = match.Groups[1].Value;

                // JSON escapes Windows paths as \\ so turn them back into \
                bridgeDir = bridgeDir.Replace("\\\\", "\\");
                Plugin.Log.LogInfo($"Using bridge dir: {bridgeDir}");

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

        public static void WriteCheckedLocation(long locationId)
        {
            if (!EnsureBridgeDir())
                return;

            HashSet<long> checkedLocations = new HashSet<long>();

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

            checkedLocations.Add(locationId);
            Plugin.Log.LogInfo($"Sent AP location check: {locationId}");

            string json = "{\n  \"checked_locations\": [" + string.Join(", ", checkedLocations) + "]\n}";
            File.WriteAllText(CheckedLocationsPath, json);
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
    }
}