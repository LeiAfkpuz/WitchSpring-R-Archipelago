using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WS1RCLASS;

namespace WitchSpringRTestPlugin
{
    public class LocationScanner
    {
        private readonly HashSet<long> sentLocations = new();

        public void ScanFieldItems()
        {
            string currentScene = SceneManager.GetActiveScene().name;

            foreach (FieldItemCheck check in Data.FieldItemChecks)
            {
                if (sentLocations.Contains(check.LocationId))
                    continue;

                if (check.Scene != currentScene)
                    continue;
                
                GameObject obj = GameObject.Find(check.ObjectName);
                if (obj == null)
                {
                    //Plugin.LogRef.LogWarning($"FIELD DEBUG missing object: scene={currentScene} object={check.ObjectName} display={check.DisplayName}");

                    continue;
                }
                ChestAndFieldItemBox box = obj.GetComponent<ChestAndFieldItemBox>();
                if (box == null)
                {
                    //Plugin.LogRef.LogWarning($"FIELD DEBUG missing ChestAndFieldItemBox: scene={currentScene} object={check.ObjectName} display={check.DisplayName}");

                    continue;
                }
                //Plugin.LogRef.LogWarning($"FIELD DEBUG found: scene={currentScene} object={check.ObjectName} display={check.DisplayName} gotItem={box.gotItem}");
                if (box.gotItem)
                {
                    sentLocations.Add(check.LocationId);

                    BridgeClient.WriteCheckedLocation(check.LocationId);

                    Plugin.LogRef.LogInfo(
                        $"Sent AP check: {check.DisplayName} / {check.LocationId}"
                    );
                }
            }
        }
    }
}