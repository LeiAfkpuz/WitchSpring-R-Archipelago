using System;
using System.Collections.Generic;
using HarmonyLib;
using WS1RCLASS;

namespace WitchSpringRTestPlugin
{
    // Auto-completes tutorial quests that can hardlock an Archipelago run, using the
    // game's own NG+ skip recipe (see event_326, the "already know Ice Magic" skip:
    // AddQuest -> QuestOK -> info popup -> continue).
    //
    // "Even Better Magic!" (Make4thFireAndDouble) is the crafting tutorial for the
    // 4-Orb Flame Circle. Two confirmed hardlocks in AP runs:
    //   1) The circle arrived from the multiworld before the quest -> can't craft a
    //      duplicate -> tutorial can't proceed.
    //   2) AP-delivered circles inflate the spell list; the crafted circle lands on
    //      page 2 and the tutorial locks page navigation -> can't select it.
    // So in AP sessions we skip the tutorial outright the moment the quest is added.
    //
    // Vanilla completion runs the quest's Endevent (event_210), whose one critical
    // side effect is clearing the crafting LOCK switch (SwitchOnOff::LOCK_마법조합) -
    // the restricted tutorial mode of the craft UI. We replicate that here so the
    // player is left with the UI fully unlocked, as if the tutorial finished.
    //
    // The quest check itself needs nothing special: ScanQuests polls
    // CheckQuestIsCleared and sends the location once QuestOK flips it.
    [HarmonyPatch(typeof(DataSet), nameof(DataSet.AddQuest), typeof(string))]
    public static class QuestSkipHook
    {
        // MASTER SWITCH - false for public releases. The skip chain works (queue on
        // AddQuest -> complete when idle -> neutralize Endevent tutorial -> chain next
        // quest -> repair pass), BUT the chained quest's world state is incomplete:
        // LetsTestFire4's target enemy never spawns (2026-07-06 test), so something
        // beyond AddQuest sets up that beat (event_211 side effects or a spawn condition
        // we bypass). Do not enable until that's solved - see wsr-quest-skip-hook notes.
        public const bool Enabled = false;

        private struct QuestSkip
        {
            public string QuestId;
            public string ClearSwitch;   // switch to force OFF afterwards ("" = none)
            public string ChainQuestId;  // next quest to add ("" = none). The vanilla
                                         // follow-up trigger (event_211, "after setting
                                         // the circle") checks quest state we bypass, so
                                         // it never fires (confirmed 2026-07-06: craft +
                                         // slot did nothing). Chain explicitly - exactly
                                         // like the game's own ice skip AddQuests
                                         // GoToGiantIce as its final step.
            public string Message;       // popup shown to the player
        }

        private static readonly QuestSkip[] Skips =
        {
            new QuestSkip
            {
                QuestId = "Make4thFireAndDouble",
                // "LOCK_마법조합" (magic-crafting lock), written with \u escapes so
                // the compiled string is identical regardless of file encoding.
                ClearSwitch = "LOCK_\uB9C8\uBC95\uC870\uD569",
                ChainQuestId = "LetsTestFire4",
                Message = "Crafting tutorial skipped (Archipelago) - Even Better Magic! completed",
            },
        };

        private static readonly HashSet<string> skippedThisSession = new();

        // Endevents of skipped quests whose Tutorial commands must be neutralized
        // (rewritten to a self-advancing wait) by EventDoEventHook - see there for why.
        // event_210 = Make4thFireAndDouble's Endevent (Tutorial:makeMagic_step_2_1).
        public static readonly HashSet<string> NeutralizeTutorialEvents = new() { "event_210" };

        // AddQuest fires mid-event (event_78 m36 / event_209 m11). Completing the quest
        // right there runs its Endevent (event_210) NESTED inside the still-running
        // event - and event_210's EndEvent:DestroyEnd tears down the shared event state,
        // so the outer event never finishes -> UI never returns (confirmed freeze,
        // 2026-07-06: event_210 logged m0..m5 complete, game still locked). So the
        // postfix only QUEUES the skip; Pump() (called from the 1s Update tick) performs
        // it once the event system is idle, so the Endevent launches standalone exactly
        // like a vanilla quest completion.
        private static readonly Queue<QuestSkip> pending = new();
        private static int deferredTicks;

        public static void Postfix(DataSet __instance, string __0)
        {
            try
            {
                if (!Enabled)
                    return;

                string questId = __0;
                if (string.IsNullOrEmpty(questId))
                    return;

                // Only interfere when an AP session is live; with no session the mod
                // shouldn't change how a vanilla playthrough behaves.
                if (!BridgeClient.HasActiveSession())
                    return;

                foreach (QuestSkip skip in Skips)
                {
                    if (skip.QuestId != questId)
                        continue;

                    if (!skippedThisSession.Add(questId))
                        return; // already skipped once this session

                    pending.Enqueue(skip);
                    Plugin.LogRef.LogInfo(
                        $"[AP] Queued hardlock-prone tutorial quest for deferred auto-complete: {questId}");
                    return;
                }
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogError($"QuestSkipHook error: {ex}");
            }
        }

        // Called from WSRController.Update (1s cadence). Completes a queued skip only
        // when no event is playing (EventOperator.nowEventLoader is null). If the
        // busy-check stays true implausibly long (stale field), fire anyway after ~15
        // ticks - a nested completion risks a freeze, but never completing guarantees
        // the hardlock we're here to prevent.
        public static void Pump()
        {
            if (!Enabled)
                return;
            try
            {
                DataSet ds = UnityEngine.Object.FindObjectOfType<DataSet>();
                if (ds == null)
                    return;

                if (pending.Count == 0)
                {
                    RepairBrokenChains(ds);
                    return;
                }

                if (IsEventRunning() && ++deferredTicks < 15)
                {
                    Plugin.LogRef.LogDebug($"[AP] Quest skip deferred - event running ({deferredTicks})");
                    return;
                }

                QuestSkip skip = pending.Dequeue();
                deferredTicks = 0;

                Plugin.LogRef.LogInfo($"[AP] Auto-completing hardlock-prone tutorial quest: {skip.QuestId}");

                ds.QuestOK(skip.QuestId);

                if (!string.IsNullOrEmpty(skip.ClearSwitch))
                    ds.SetSwitchOff(skip.ClearSwitch);

                if (!string.IsNullOrEmpty(skip.ChainQuestId))
                {
                    Plugin.LogRef.LogInfo($"[AP] Chaining next quest: {skip.ChainQuestId}");
                    ds.AddQuest(skip.ChainQuestId);
                }

                if (!string.IsNullOrEmpty(skip.Message))
                    UIMessage.Show(skip.Message);
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogError($"QuestSkipHook.Pump error: {ex}");
            }
        }

        // Rescue saves that were skipped by an older build without chaining (or where a
        // crash landed between QuestOK and the chain): if a skip's quest is cleared but
        // its chain quest was never added, add it now. Runs once per skip per session;
        // no-ops on fresh saves (quest not cleared) and on vanilla-completed saves
        // (chain already present).
        private static readonly HashSet<string> repairedThisSession = new();

        private static void RepairBrokenChains(DataSet ds)
        {
            foreach (QuestSkip skip in Skips)
            {
                if (string.IsNullOrEmpty(skip.ChainQuestId))
                    continue;
                if (repairedThisSession.Contains(skip.QuestId))
                    continue;

                bool skippedCleared, chainCleared, chainKnown;
                try
                {
                    skippedCleared = ds.CheckQuestIsCleared(skip.QuestId);
                    chainCleared = ds.CheckQuestIsCleared(skip.ChainQuestId);
                    chainKnown = ds.CheckQuestIsDuplicated(skip.ChainQuestId);
                }
                catch
                {
                    continue; // quest tables not ready yet - retry next tick
                }

                if (!skippedCleared)
                    continue; // player hasn't reached / skipped this quest yet

                repairedThisSession.Add(skip.QuestId);

                if (chainCleared || chainKnown)
                    continue; // chain already progressed - nothing to repair

                Plugin.LogRef.LogInfo(
                    $"[AP] Repairing broken quest chain: {skip.QuestId} is cleared but " +
                    $"{skip.ChainQuestId} was never added - adding it now.");
                ds.AddQuest(skip.ChainQuestId);
                UIMessage.Show("Story repaired (Archipelago) - next quest added");
            }
        }

        private static bool IsEventRunning()
        {
            try
            {
                EventOperator op = UnityEngine.Object.FindObjectOfType<EventOperator>();
                if (op == null)
                    return false;
                object loader = HarmonyLib.AccessTools.Field(op.GetType(), "nowEventLoader")?.GetValue(op)
                             ?? HarmonyLib.AccessTools.Property(op.GetType(), "nowEventLoader")?.GetValue(op);
                return loader != null;
            }
            catch
            {
                return false; // can't tell - don't block the skip forever
            }
        }
    }

    // Completing "Even Better Magic!" fires its Endevent (event_210), whose
    // "Tutorial:makeMagic_step_2_1" command throws a NullReferenceException when the
    // crafting UI isn't open - which is exactly the situation after QuestSkipHook
    // auto-completes the quest in the field. The unhandled exception kills the event
    // runner mid-event (confirmed softlock, 2026-07-06 log). Suppress the exception so
    // the event continues to its EndEvent; successful tutorial calls are unaffected.
    // (The game's own NG+ ice-magic skip never hits this because MakeIceCircle has no
    // Endevent at all.)
    [HarmonyPatch(typeof(Tutorial), nameof(Tutorial.SetTutorial))]
    public static class TutorialCrashGuard
    {
        // Forensics: log every tutorial id as it fires. Cheap (tutorials are rare) and
        // it identifies exactly which guide was on screen when a freeze happens - e.g.
        // the 2026-07-06 "Combat Guide during the scripted mind-control fight" deadlock,
        // where AP pacing made a combat guide first-fire inside a scripted battle.
        public static void Prefix(string __0)
        {
            Plugin.LogRef.LogInfo($"[AP] Tutorial.SetTutorial('{__0}')");
        }

        public static Exception Finalizer(Exception __exception, string __0)
        {
            if (__exception != null)
            {
                Plugin.LogRef.LogWarning(
                    $"[AP] Suppressed Tutorial.SetTutorial('{__0}') exception " +
                    $"(no tutorial UI context): {__exception.Message}"
                );
            }
            return null; // swallow so the event runner keeps going
        }
    }
}
