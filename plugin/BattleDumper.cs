using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using HarmonyLib;
using BepInEx;
using UnityEngine.SceneManagement;
using WS1RCLASS;

namespace WitchSpringRTestPlugin
{
    // DEV DATA-GATHERING for the planned Bestiary + Battlesanity features. Writes plaintext
    // dumps to <game>/Archipelago/Dumps/.
    //   1) Bestiary roster  - read once from DataSet.enemyList (the full enemy table).
    //   2) Battle encounters - every unique battleID seen via DataSet.CheckBattleID/AddBattleID
    //      (CheckBattleID fires on every engaged battle, cleared or not, so running around and
    //      quick-battling each field enemy enumerates the full set). One line: scene\tbattleID.
    public static class BattleDumper
    {
        private static readonly string DumpDir =
            Path.Combine(Paths.GameRootPath, "Archipelago", "Dumps");

        // Dev data-gathering (roster/quest table dumps + unmapped-battle logging). OFF for
        // release so players don't get dump files written to their game folder. Flip to
        // true for a dev playthrough (e.g. to catch unmapped battles / re-dump rosters).
        private const bool DevDumps = false;

        private static bool bestiaryDumped;
        private static readonly HashSet<string> seenBattleIds = new HashSet<string>();
        private static readonly HashSet<long> sentBattleSanity = new HashSet<long>();

        // CheckBattleID fires when you ENGAGE a battle (not when you win), so we only
        // remember the id here and resolve it on a win (EndBattle / AddBattleID). A loss
        // or flee cancels the pending id so nothing sends.
        private static string pendingBattleId = "";

        private static readonly HashSet<long> sentBestiary = new HashSet<long>();
        private static readonly HashSet<long> sentQuests = new HashSet<long>();

        // Poll each mapped quest's cleared state and send when it flips to cleared. This
        // catches every completion path (NPC turn-in, story auto-complete, switch-based)
        // and also picks up quests already cleared in the save on the first scan.
        public static void ScanQuests()
        {
            if (Data.QuestChecks.Length == 0)
                return;
            try
            {
                DataSet ds = UnityEngine.Object.FindObjectOfType<DataSet>();
                if (ds == null)
                    return;
                foreach (QuestCheck check in Data.QuestChecks)
                {
                    if (sentQuests.Contains(check.LocationId))
                        continue;
                    bool cleared;
                    try { cleared = ds.CheckQuestIsCleared(check.QuestId); }
                    catch { continue; }
                    if (!cleared)
                        continue;
                    sentQuests.Add(check.LocationId);
                    Plugin.LogRef.LogInfo($"Sent AP quest check: {check.DisplayName} / {check.LocationId}");
                    BridgeClient.WriteCheckedLocation(check.LocationId);
                }
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogWarning($"[DUMP] quest scan failed: {ex.Message}");
            }
        }

        private static string File2(string name) => Path.Combine(DumpDir, name);

        // An enemy was defeated. Send its bestiary check if mapped.
        public static void RecordEnemyDefeated(string enemyId)
        {
            try
            {
                if (string.IsNullOrEmpty(enemyId))
                    return;

                foreach (BestiaryCheck check in Data.BestiaryChecks)
                {
                    if (check.EnemyId != enemyId)
                        continue;
                    if (sentBestiary.Add(check.LocationId))
                    {
                        Plugin.LogRef.LogInfo(
                            $"Sent AP bestiary check: {check.DisplayName} / {check.LocationId}");
                        BridgeClient.WriteCheckedLocation(check.LocationId);
                    }
                    return;
                }
                // An enemy with no mapped check (e.g. a special battle variant not in the
                // table). Debug-only so it's available when chasing stragglers, quiet for players.
                Plugin.LogRef.LogDebug($"[BESTIARY] no mapping for enemyID='{enemyId}'");
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogWarning($"[DUMP] bestiary record failed: {ex.Message}");
            }
        }

        public static void NoteBattleId(string battleId)
        {
            if (!string.IsNullOrEmpty(battleId))
                pendingBattleId = battleId;
        }

        public static void CancelPending()
        {
            pendingBattleId = "";
        }

        // Called on a battle WIN. Sends the mapped Battlesanity check (or dumps an unmapped
        // battle), then clears the pending id so it can't fire twice.
        public static void ResolveBattleWin()
        {
            try
            {
                string battleId = pendingBattleId;
                pendingBattleId = "";
                if (string.IsNullOrEmpty(battleId))
                    return;

                foreach (BattleSanityCheck check in Data.BattleSanityChecks)
                {
                    if (check.BattleId != battleId)
                        continue;
                    if (sentBattleSanity.Add(check.LocationId))
                    {
                        Plugin.LogRef.LogInfo(
                            $"Sent AP battlesanity check: {check.DisplayName} / {check.LocationId}");
                        BridgeClient.WriteCheckedLocation(check.LocationId);
                    }
                    return;
                }

                // Unmapped battle (won) - a battle not in the table. Debug log always; only
                // write the discovery file during a dev dump pass.
                if (!seenBattleIds.Add(battleId))
                    return;
                string scene = SceneManager.GetActiveScene().name;
                Plugin.LogRef.LogDebug($"[BATTLE] unmapped battle (won): {scene} / {battleId}");
                if (DevDumps)
                {
                    Directory.CreateDirectory(DumpDir);
                    File.AppendAllText(File2("battle_encounters.tsv"), $"{scene}\t{battleId}\n");
                }
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogWarning($"[DUMP] battle resolve failed: {ex.Message}");
            }
        }

        private static bool questsDumped;

        // One-shot dump of both quest tables (main QuestList + request-board HumanQuest).
        public static void TryDumpQuestsOnce()
        {
            if (questsDumped || !DevDumps)
                return;
            try
            {
                DataSet ds = UnityEngine.Object.FindObjectOfType<DataSet>();
                if (ds == null)
                    return;
                // The quest tables live on DataSet (fields 'quest' / 'humanQuest'), not as
                // findable scene objects.
                QuestList ql = ds.quest;
                HumanQuest hq = ds.humanQuest;
                if (ql == null && hq == null)
                    return;

                Directory.CreateDirectory(DumpDir);

                if (ql != null && ql.dataArray != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("ID\tChapter\tCategory\tName_EN\tEndEvent");
                    var arr = ql.dataArray;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        QuestListData q = arr[i];
                        if (q == null) continue;
                        string en = "";
                        try { if (ds != null) en = ds.GetName(q.ID) ?? ""; } catch { }
                        sb.AppendLine($"{q.ID}\t{q.Chapter}\t{q.QUESTCATEGORY}\t{en}\t{q.Endevent}");
                    }
                    File.WriteAllText(File2("quest_main.tsv"), sb.ToString());
                    Plugin.LogRef.LogInfo($"[DUMP] Main quests dumped: {arr.Length}");
                }

                if (hq != null && hq.dataArray != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("ID\tClient\tRank\tName_EN\tText_KR\tClearSwitch");
                    var arr = hq.dataArray;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        HumanQuestData h = arr[i];
                        if (h == null) continue;
                        string en = "";
                        try { if (ds != null) en = ds.GetName(h.ID) ?? ""; } catch { }
                        sb.AppendLine($"{h.ID}\t{h.Client}\t{h.RANK}\t{en}\t{h.Text_KR}\t{h.Clearswitch}");
                    }
                    File.WriteAllText(File2("quest_human.tsv"), sb.ToString());
                    Plugin.LogRef.LogInfo($"[DUMP] Human quests dumped: {arr.Length}");
                }

                questsDumped = true;
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogWarning($"[DUMP] quest dump failed (will retry): {ex.Message}");
            }
        }

        // Called every ~1s from WSRController.Update; dumps the full enemy roster the first
        // time a loaded DataSet/enemyList is available, then never again this session.
        public static void TryDumpBestiaryOnce()
        {
            if (bestiaryDumped || !DevDumps)
                return;

            try
            {
                DataSet ds = UnityEngine.Object.FindObjectOfType<DataSet>();
                if (ds == null)
                    return;

                EnemyList list = ds.enemyList;
                if (list == null || list.dataArray == null || list.dataArray.Length == 0)
                    return;

                Directory.CreateDirectory(DumpDir);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ID\tName_EN\tNameID\tName_KR\tRank\tJobGroup\tBattleEXP");
                var arr = list.dataArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    EnemyListData e = arr[i];
                    if (e == null)
                        continue;
                    // GetName resolves the Nameid key to the active language (English here).
                    string en = "";
                    try { en = ds.GetName(e.Nameid) ?? ""; } catch { }
                    sb.AppendLine($"{e.ID}\t{en}\t{e.Nameid}\t{e.Name_KR}\t{e.RANK}\t{e.JOBGROUP}\t{e.Battleexp}");
                }
                File.WriteAllText(File2("bestiary_enemies.tsv"), sb.ToString());
                Plugin.LogRef.LogInfo(
                    $"[DUMP] Bestiary roster dumped: {arr.Length} enemies -> {File2("bestiary_enemies.tsv")}");

                try
                {
                    EnemyReward rew = ds.enemyReward;
                    if (rew != null && rew.dataArray != null)
                    {
                        StringBuilder rb = new StringBuilder();
                        rb.AppendLine("ID\tReward0\tCount0\tReward1\tCount1\tReward2\tCount2\tReward3\tCount3");
                        var rarr = rew.dataArray;
                        for (int i = 0; i < rarr.Length; i++)
                        {
                            EnemyRewardData r = rarr[i];
                            if (r == null)
                                continue;
                            rb.AppendLine(
                                $"{r.ID}\t{r.Reward0}\t{r.Count0}\t{r.Reward1}\t{r.Count1}\t" +
                                $"{r.Reward2}\t{r.Count2}\t{r.Reward3}\t{r.Count3}");
                        }
                        File.WriteAllText(File2("bestiary_rewards.tsv"), rb.ToString());
                        Plugin.LogRef.LogInfo($"[DUMP] Reward table dumped: {rarr.Length} entries");
                    }
                }
                catch (Exception ex)
                {
                    Plugin.LogRef.LogWarning($"[DUMP] reward dump failed: {ex.Message}");
                }

                bestiaryDumped = true;
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogWarning($"[DUMP] bestiary dump failed (will retry): {ex.Message}");
            }
        }
    }

    // Fires when a battle is ENGAGED - remember the id, don't send yet.
    [HarmonyPatch(typeof(DataSet), nameof(DataSet.CheckBattleID))]
    public static class CheckBattleIDHook
    {
        public static void Postfix(string __0) => BattleDumper.NoteBattleId(__0);
    }

    // First clear of a battle - a confirmed win at battle-end, so resolve immediately.
    [HarmonyPatch(typeof(DataSet), nameof(DataSet.AddBattleID))]
    public static class AddBattleIDHook
    {
        public static void Postfix(string __0)
        {
            BattleDumper.NoteBattleId(__0);
            BattleDumper.ResolveBattleWin();
        }
    }

    // Battle won (fires for repeat clears too, where AddBattleID does not). Private method.
    [HarmonyPatch(typeof(BattleOperator), "EndBattle")]
    public static class EndBattleHook
    {
        public static void Postfix() => BattleDumper.ResolveBattleWin();
    }

    // Loss / flee - cancel the pending send so a non-win never checks the location.
    [HarmonyPatch(typeof(BattleOperator), nameof(BattleOperator.BattleLose))]
    public static class BattleLoseHook
    {
        public static void Postfix() => BattleDumper.CancelPending();
    }

    [HarmonyPatch(typeof(BattleOperator), nameof(BattleOperator.EscapeBattle))]
    public static class EscapeBattleHook
    {
        public static void Postfix() => BattleDumper.CancelPending();
    }

    // QuestSanity is handled by polling DataSet.CheckQuestIsCleared in WSRController.Update
    // (BattleDumper.ScanQuests), which catches every completion path - no per-method hooks.

    // An enemy was defeated (died) - send its Bestiary check. Lose fires on every kill
    // (not just the first catalog), so it works on existing saves too.
    [HarmonyPatch(typeof(EnemyBasic), "Lose")]
    public static class EnemyLoseHook
    {
        public static void Postfix(EnemyBasic __instance)
        {
            if (__instance != null)
                BattleDumper.RecordEnemyDefeated(__instance.enemyID);
        }
    }

    // Also catch the first-time-catalog path, in case Lose doesn't fire in some flows.
    [HarmonyPatch(typeof(EnemyBasic), "AddClearedEnemyInfoToData")]
    public static class AddClearedEnemyInfoToDataHook
    {
        public static void Postfix(EnemyBasic __instance)
        {
            if (__instance != null)
                BattleDumper.RecordEnemyDefeated(__instance.enemyID);
        }
    }
}
