using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using UnityEngine;
using HarmonyLib;

namespace WitchSpringRTestPlugin
{
    [BepInPlugin("witchspringr.archipelago", "WitchSpring R Archipelago", "0.4.0")]
    public class Plugin : BasePlugin
    {
        internal static ManualLogSource LogRef;
        public static ManualLogSource Log;

        public override void Load()
        {
            Log = base.Log;
            LogRef = Log;
            Log.LogInfo("=== WitchSpring R Plugin Loaded! ===");

            Harmony harmony = new Harmony("witchspringr.archipelago");
            harmony.PatchAll();
            Log.LogInfo("Harmony patches loaded!");

            AddComponent<WSRController>();
            Log.LogInfo("WSRController initialized");
        }
    }

    public class WSRController : MonoBehaviour
    {
        private float nextScanTime = 0f;
        private readonly EventContextScanner eventContextScanner = new();
        private readonly LocationScanner locationScanner = new();
        private readonly ReceivedItemScanner receivedItemScanner = new();
        //private readonly ProgressionScanner progressionScanner = new();
        

        private void Update()
        {
            // Drained every frame so queued AP popups emit at a paced rate (prevents the
            // DOTween "Max Tweens" burst that black-screened scene loads).
            UIMessage.Pump();

            if (Time.time < nextScanTime)
                return;

            nextScanTime = Time.time + 1f;

            BridgeClient.FlushPendingChecks();
            QuestSkipHook.Pump();
            //eventContextScanner.Scan();
            locationScanner.ScanFieldItems();
            receivedItemScanner.Scan();
            //progressionScanner.Scan();
            BattleDumper.TryDumpBestiaryOnce();
            BattleDumper.TryDumpQuestsOnce();
            BattleDumper.ScanQuests();
            
        }
    }

}