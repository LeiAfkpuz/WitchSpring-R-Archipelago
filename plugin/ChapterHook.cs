using System;
using System.Collections.Generic;
using HarmonyLib;
using WS1RCLASS;

namespace WitchSpringRTestPlugin
{
    [HarmonyPatch(typeof(DataSet), nameof(DataSet.SetNewChapter))]
    public static class ChapterHook
    {
        private static readonly HashSet<long> sentThisSession = new();

        public static void Postfix(int num)
        {
            try
            {
                Plugin.LogRef.LogDebug($"SetNewChapter hook fired: {num}");

                foreach (ChapterEventCheck check in Data.ChapterEventChecks)
                {
                    if (check.ChapterNumber != num)
                        continue;
                    
                    if (sentThisSession.Contains(check.LocationId))
                        return;

                    sentThisSession.Add(check.LocationId);

                    BridgeClient.WriteCheckedLocation(check.LocationId);

                    Plugin.LogRef.LogInfo($"Sent AP chapter event check: {check.DisplayName} / {check.LocationId}");
                }
            }
            catch(Exception ex)
            {
                Plugin.LogRef.LogError($"ChapterHook error: {ex}");
            }
        }

    }
}