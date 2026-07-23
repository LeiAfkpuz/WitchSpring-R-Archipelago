using System;
using HarmonyLib;
using WS1RCLASS;

namespace WitchSpringRTestPlugin
{
    // Fixes the "Even Better Magic!" (and any similar) tutorial softlock.
    // Thank you to DodoBirb for the original idea for how to correct this! 

    [HarmonyPatch(typeof(GridButtonPanel), nameof(GridButtonPanel.PressActiveOnlyOneButton))]
    public static class GridButtonPanelFix
    {
        public static bool Prefix(GridButtonPanel __instance, string __0)
        {
            try
            {
                string id = __0;
                if (string.IsNullOrEmpty(id) || __instance == null)
                    return true;

                // Already on the visible page? Vanilla handles it.
                var visible = __instance.buttonList;
                if (visible != null)
                {
                    for (int i = 0; i < visible.Count; i++)
                    {
                        if (visible[i] != null && visible[i].buttonID == id)
                            return true;
                    }
                }

                // Find it in the full info list.
                var all = __instance.buttonInfoList;
                if (all == null)
                    return true;

                int index = -1;
                for (int i = 0; i < all.Count; i++)
                {
                    if (all[i] != null && all[i].buttonID == id)
                    {
                        index = i;
                        break;
                    }
                }
                if (index < 0)
                    return true; // not in this panel at all, let vanilla do its thing

                int columns = __instance.columnCount;
                if (columns <= 0)
                    return true;

                int row = index / columns;
                Plugin.LogRef.LogInfo(
                    $"[AP] Tutorial target button '{id}' is off-screen (index {index}); " +
                    $"scrolling panel to row {row} so the tutorial can find it.");
                __instance.SetButtonList(row, false);

                return true; // run the original the button is now visible
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogError($"GridButtonPanelFix error (falling through to vanilla): {ex}");
                return true;
            }
        }
    }
}
