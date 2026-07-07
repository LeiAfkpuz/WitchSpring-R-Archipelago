using System;
using HarmonyLib;
using System.Collections.Generic;

namespace WitchSpringRTestPlugin
{
    [HarmonyPatch(typeof(EventOperator), nameof(EventOperator.DoEvent))]
    public static class EventDoEventHook
    {
        private static readonly System.Collections.Generic.HashSet<long> sentBlessLocations = new();

        public static bool Prefix(EventOperator __instance, ref string mathodInfo)
        {
            try
            {
                string eventId = "";
                object info = null;

                object loader = ReadValue(__instance, "nowEventLoader");
                if (loader != null)
                {
                    info = ReadValue(loader, "info");
                    if (info == null) info = ReadValue(loader, "eventInfo");
                    if (info == null) info = ReadValue(loader, "nowEventInfo");

                    if (info != null)
                        eventId = ReadString(info, "eventFileName");
                }

                int methodIndex = FindMethodIndex(info, eventId, mathodInfo);

                EventContext.Set(eventId, methodIndex, mathodInfo);

                // Tutorial commands inside a skipped quest's Endevent crash (no tutorial
                // UI context) and, even with the exception suppressed, never register the
                // "tutorial done -> continue" callback, so the event runner waits forever
                // (confirmed freeze, 2026-07-06). Rewrite the command into a harmless
                // self-advancing wait BEFORE the game parses it - the event then proceeds
                // to its remaining commands natively.
                if (QuestSkipHook.Enabled && QuestSkipHook.NeutralizeTutorialEvents.Contains(eventId))
                {
                    Plugin.LogRef.LogInfo($"[AP] {eventId} command m{methodIndex}: {mathodInfo}");
                    if (!string.IsNullOrEmpty(mathodInfo) && mathodInfo.Contains(":Tutorial:"))
                    {
                        Plugin.LogRef.LogInfo($"[AP] Neutralized {eventId} Tutorial command -> WaitSecond 0.1");
                        mathodInfo = ":WaitSecond:0.1";
                    }
                }

                foreach (EventGate gate in Data.EventGates)
                {
                    if (gate.EventId != eventId)
                        continue;
                    
                    if (gate.MethodIndex != methodIndex)
                        continue;
                    
                    if (!HasReceivedApItem(gate.RequiredItem))
                    {
                        Plugin.LogRef.LogWarning(
                            $"Blocked event gate: {gate.DisplayName} requires {gate.RequiredItem}"
                        );
                        return false; //blocks this event command
                    }
                }

                // Blessing checks: the NewBless event command (e.g. ":NewBless:Bless_Aimhard:")
                // doesn't resolve a usable method index, so match the command string directly
                // and parse the bless id from it. Our own received-blessing grants go through
                // DataSet.AddSkill (not an event command), so they never reach here.
                if (!string.IsNullOrEmpty(mathodInfo) && mathodInfo.Contains("NewBless"))
                {
                    string[] parts = mathodInfo.Split(':');
                    string blessId = "";
                    for (int i = 0; i < parts.Length - 1; i++)
                    {
                        if (parts[i] == "NewBless") { blessId = parts[i + 1]; break; }
                    }

                    foreach (EventRewardCheck bless in Data.BlessRewardChecks)
                    {
                        if (sentBlessLocations.Contains(bless.LocationId))
                            continue;
                        if (bless.VanillaItem != blessId)
                            continue;

                        sentBlessLocations.Add(bless.LocationId);
                        Plugin.LogRef.LogInfo(
                            $"Sent AP bless check: {bless.DisplayName} / {bless.LocationId}"
                        );
                        BridgeClient.WriteCheckedLocation(bless.LocationId);
                    }
                }

                Plugin.LogRef.LogDebug(
                    $"EVENT DOEVENT HOOK: event={eventId} method={methodIndex} command={mathodInfo}"
                );
                return true;
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogError($"EventDoEventHook error: {ex}");
                return true;
            }
        }

        private static bool HasReceivedApItem(string itemName)
        {
            string json = BridgeClient.ReadReceivedItemsJson();

            if (string.IsNullOrWhiteSpace(json))
                return false;
            
            return json.Contains($"\"item\": \"{itemName}\"")
                || json.Contains($"\"item\":\"{itemName}\"");
        }

        private static readonly Dictionary<string, int> commandOccurrence = new();

        private static int FindMethodIndex(object info, string eventId, string mathodInfo)
        {
            if (info == null || string.IsNullOrEmpty(mathodInfo))
                return -1;

            object listObj = ReadValue(info, "mathodList");
            if (listObj == null)
                return -1;

            string key = $"{eventId}|{mathodInfo}";

            if (!commandOccurrence.ContainsKey(key))
                commandOccurrence[key] = 0;

            int wantedOccurrence = commandOccurrence[key];
            int seenOccurrence = 0;

            try
            {
                dynamic list = listObj;
                int count = list.Count;

                for (int i = 0; i < count; i++)
                {
                    string line = list[i]?.ToString() ?? "";

                    if (line != mathodInfo)
                        continue;

                    if (seenOccurrence == wantedOccurrence)
                    {
                        commandOccurrence[key] = wantedOccurrence + 1;
                        return i;
                    }

                    seenOccurrence++;
                }
            }
            catch
            {
                return -1;
            }

            return -1;
        }

        private static object ReadValue(object obj, string name)
        {
            if (obj == null)
                return null;

            var type = obj.GetType();
            var field = type.GetField(name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (field != null)
                return field.GetValue(obj);

            var prop = type.GetProperty(name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (prop != null)
                return prop.GetValue(obj);

            return null;
        }

        private static string ReadString(object obj, string name)
        {
            object value = ReadValue(obj, name);
            return value?.ToString() ?? "";
        }
    }
}