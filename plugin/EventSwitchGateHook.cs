using System;
using System.Reflection;
using HarmonyLib;
using WS1RCLASS;

namespace WitchSpringRTestPlugin
{
    // Postfix on EventLoader.CheckSwitch (the bool the loader uses to decide whether
    // its event may start). If a SwitchGate matches this loader's event and the
    // required AP item hasn't been received yet, force the result to false so the
    // event simply never starts - the game treats it as "not time yet" rather than
    // interrupting a running cutscene, so there is no hardlock. Read-only: we never
    // set switches, so there is no save-state risk.
    [HarmonyPatch(typeof(EventLoader), nameof(EventLoader.CheckSwitch))]
    public static class EventSwitchGateHook
    {
        public static void Postfix(EventLoader __instance, ref bool __result)
        {
            if (!__result)
                return; // the game already blocked it; nothing to add

            if (Data.SwitchGates.Length == 0)
                return; // no gates configured - stay out of the way entirely

            try
            {
                string eventId = ReadEventId(__instance);
                if (string.IsNullOrEmpty(eventId))
                    return;

                foreach (SwitchGate gate in Data.SwitchGates)
                {
                    if (gate.EventId != eventId)
                        continue;

                    if (!BridgeClient.HasReceivedItem(gate.RequiredItem))
                    {
                        __result = false;
                        Plugin.LogRef.LogWarning(
                            $"[AP] Gating event {eventId} ({gate.DisplayName}) - requires " +
                            $"{gate.RequiredItem}, not received yet."
                        );
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogError($"EventSwitchGateHook error: {ex}");
            }
        }

        private static string ReadEventId(EventLoader loader)
        {
            object info = ReadField(loader, "info")
                       ?? ReadField(loader, "eventInfo")
                       ?? ReadField(loader, "nowEventInfo");
            if (info == null)
                return "";

            object name = ReadField(info, "eventFileName");
            return name?.ToString() ?? "";
        }

        private static object ReadField(object obj, string name)
        {
            if (obj == null)
                return null;

            Type t = obj.GetType();

            FieldInfo f = t.GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (f != null)
                return f.GetValue(obj);

            PropertyInfo p = t.GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (p != null)
                return p.GetValue(obj);

            return null;
        }
    }
}
