using System;
using System.Collections.Generic;
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

        // AP messages can arrive in bursts - a backlog of received items plus several checks
        // the instant you enter an area. Each popup animates via DOTween, so firing a whole
        // burst in one frame can exhaust the game's tween pool ("Max Tweens" -> the scene-load
        // fade can't allocate -> black screen). Queue them and emit at most one per MinInterval
        // so the added tween load stays small and bounded. Pump() is driven from Update().
        private static readonly Queue<string> queue = new Queue<string>();
        private const int MaxQueued = 300;       // hard cap so a flood can't grow unbounded
        private const float MinInterval = 0.3f;  // ~3/sec -> peak ~9 concurrent popups (3s each)
        private static float nextShowTime;

        public static void Show(string text)
        {
            if (!string.IsNullOrEmpty(text) && queue.Count < MaxQueued)
                queue.Enqueue(text);
        }

        // Call every frame; shows the next queued message once enough time has passed.
        public static void Pump()
        {
            if (queue.Count == 0 || Time.time < nextShowTime)
                return;
            nextShowTime = Time.time + MinInterval;
            ShowNow(queue.Dequeue());
        }

        private static void ShowNow(string text)
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
