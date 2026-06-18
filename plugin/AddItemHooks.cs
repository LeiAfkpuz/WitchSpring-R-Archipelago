using System;
using System.Collections.Generic;
using HarmonyLib;
using WS1RCLASS;

namespace WitchSpringRTestPlugin
{
    [HarmonyPatch(typeof(DataSet), nameof(DataSet.AddItem))]
    public static class AddItemHook
    {
        private static readonly HashSet<long> sentEventLocations = new();
        private static readonly HashSet<long> sentBattleLocations = new();

        public static bool Prefix(string _id, int _count, GetItemType getType)
        {
            try
            {
                if (ItemGranting.IsGrantingFromArchipelago)
                    return true;

                if (getType == GetItemType.CHEST)
                {
                    Plugin.LogRef.LogDebug($"Blocked vanilla chest reward: {_id} x{_count}");
                    return false;
                }
                foreach (BattleRewardCheck check in Data.BattleRewardChecks)
                {
                    if (sentBattleLocations.Contains(check.LocationId))
                        continue;
                    if (check.VanillaItem != _id)
                        continue;
                    if (check.VanillaQuantity != _count)
                        continue;
                    
                    sentBattleLocations.Add(check.LocationId);
                    Plugin.LogRef.LogInfo(
                        $"Sent AP battle reward check: {check.DisplayName} / {check.LocationId} " + $"blocked vanilal reward: {_id} x{_count} type={getType}"
                    );
                    BridgeClient.WriteCheckedLocation(check.LocationId);
                    return false;
                }
                if (getType != GetItemType.EVENT)
                    return true;
                Plugin.LogRef.LogDebug(
                    $"Game AddItem hook fired: {_id} x{_count} type={getType} " +
                    $"event={EventContext.CurrentEventId} " +
                    $"method={EventContext.CurrentMethodId} " +
                    $"command={EventContext.CurrentCommand}"
                );

                foreach (EventRewardCheck check in Data.EventRewardChecks)
                {
                    if (sentEventLocations.Contains(check.LocationId))
                        continue;

                    if (check.EventId != EventContext.CurrentEventId)
                        continue;

                    if (check.MethodIndex != EventContext.CurrentMethodId)
                        continue;

                    if (check.VanillaItem != _id)
                        continue;

                    if (check.VanillaQuantity != _count)
                        continue;

                    sentEventLocations.Add(check.LocationId);

                    Plugin.LogRef.LogInfo(
                        $"Sent AP event check: {check.DisplayName} / {check.LocationId}"
                    );

                    BridgeClient.WriteCheckedLocation(check.LocationId);

                    if (check.BlockVanilla)
                        return false; // block vanilla reward (normal check)
                    return true; // non-blocking check: keep the vanilla item
                }

                return true; // allow normal reward
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogError($"AddItemHook error: {ex}");
                return true;
            }
        }
    }
}