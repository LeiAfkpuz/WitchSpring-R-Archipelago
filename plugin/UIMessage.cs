using System;
using WS1RCLASS;
using UnityEngine;

namespace WitchSpringRTestPlugin
{
    // Shows an Archipelago message ("Sent X to Player" / "Received X from Y") in the
    // game's left-up info bar. InfoMessage_LeftUp renders raw text; a null Sprite is fine.
    public static class UIMessage
    {
        // The left-up message stack is anchored at the very top-left, where it tucks
        // under the chapter badge. We nudge its panel (leftUpPanel) down so the stack
        // sits lower, nearer the item-pickup bar. anchoredPosition Y is up-positive, so
        // a negative value moves it DOWN. Tune this single number to taste.
        private const float LeftUpOffsetY = -300f;

        private static int leftUpPanelId = 0;
        private static Vector2 leftUpBasePos;

        public static void Show(string text)
        {
            try
            {
                var ui = UnityEngine.Object.FindObjectOfType<UIOperator>();
                if (ui == null)
                {
                    Plugin.LogRef.LogWarning($"[UIMSG] UIOperator not found; cannot show: {text}");
                    return;
                }

                // The bar renders one unwrapped line and lets long text run off the
                // right edge (verified with a 200+ char AP item name) - no clamping
                // needed, so the player sees as much of the name as fits.
                ui.InfoMessage_LeftUp(text, 3f, null);
                ApplyLeftUpOffset(ui);
                Plugin.LogRef.LogDebug($"[UIMSG] InfoMessage_LeftUp called with: {text}");
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogError($"[UIMSG] InfoMessage_LeftUp failed: {ex}");
            }
        }

        // Pin the left-up panel to (its natural position + our offset). We capture the
        // game's natural position once per panel instance so the offset never drifts or
        // compounds across messages or scene loads.
        private static void ApplyLeftUpOffset(UIOperator ui)
        {
            try
            {
                object panel = ui.leftUpPanel;
                if (panel == null)
                    return;

                Transform t =
                    (panel as GameObject)?.transform
                    ?? (panel as Component)?.transform;

                if (!(t is RectTransform rect))
                    return;

                if (rect.GetInstanceID() != leftUpPanelId)
                {
                    leftUpPanelId = rect.GetInstanceID();
                    leftUpBasePos = rect.anchoredPosition;
                }

                rect.anchoredPosition = new Vector2(
                    leftUpBasePos.x,
                    leftUpBasePos.y + LeftUpOffsetY
                );
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogWarning($"[UIMSG] Could not reposition left-up panel: {ex.Message}");
            }
        }
    }
}
