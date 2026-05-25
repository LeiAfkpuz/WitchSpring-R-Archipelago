using System;
using WS1RCLASS;

namespace WitchSpringRTestPlugin
{
    public static class ItemGranting
    {

        public static bool IsGrantingFromArchipelago = false;
        public static bool GrantItem(string apItemName)
        {

            //if (apItemName.EndsWith(" Blessing"))
            //{
            //    Plugin.LogRef.LogWarning($"{apItemName} received, but blessing grant method is not implemented yet. Marking processed.");
            //    return true;
            //}
            foreach (ItemGrant grant in Data.ItemGrants)
            {
                if (grant.ApItemName != apItemName)
                    continue;

                Plugin.LogRef.LogWarning(
                    $"Granting AP Item: {grant.ApItemName} -> AddItem:{grant.GameItemId}:{grant.Quantity}"
                );

                return GrantGameItem(grant.GameItemId, grant.Quantity);
            }

            Plugin.LogRef.LogWarning($"No grant mapping yet for AP item: {apItemName}");
            return true;
        }
    
        public static bool GrantGameItem(string gameItemId, int quantity)
        {
            try
            {
                var dataSet = UnityEngine.Object.FindObjectOfType<DataSet>();

                if (dataSet == null)
                {
                    Plugin.LogRef.LogError("Could not find DataSet instance");
                    return false;
                }

                if (gameItemId.StartsWith("Bless_"))
                {
                    return GrantBlessing(gameItemId);
                }
                try
                {
                    IsGrantingFromArchipelago = true;
                    dataSet.AddItem(gameItemId, quantity, GetItemType.NONE);
                }
                finally
                {
                    IsGrantingFromArchipelago = false;
                }

                Plugin.LogRef.LogWarning($"Granted game item: AddItem:{gameItemId}:{quantity}");
                return true;
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogError($"Failed to grant game item: {ex}");
                return false;
            }
        }
        private static bool GrantBlessing(string blessId)
        {
            try
            {
                DataSet dataSet = UnityEngine.Object.FindObjectOfType<DataSet>();

                if (dataSet == null)
                {
                    Plugin.LogRef.LogWarning("GrantBlessing failed: DataSet not found");
                    return false;
                }
                Plugin.LogRef.LogWarning($"Granting Blessing: NewBless:{blessId}");

                dataSet.AddSkill(blessId);

                Plugin.LogRef.LogWarning($"Granted blessing: {blessId}");
                return true;
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogError($"Failed to grant blessing {blessId}: {ex}");
                return false;
            }
        }
        public static bool PlayerAlreadyHasItem(string apItemName)
        {
            foreach (ItemGrant grant in Data.ItemGrants)
            {
                if (grant.ApItemName != apItemName)
                    continue;

                if (grant.GameItemId.StartsWith("Bless_"))
                    return PlayerHasBlessing(grant.GameItemId);

                return PlayerHasGameItem(grant.GameItemId, grant.Quantity);
            }

            return false;
        }

        public static bool PlayerHasGameItem(string gameItemId, int quantity)
        {
            try
            {
                DataSet dataSet = UnityEngine.Object.FindObjectOfType<DataSet>();

                if (dataSet == null)
                    return false;

                int currentCount = dataSet.GetItemCount(gameItemId);

                //Plugin.LogRef.LogWarning(
                //    $"Inventory check: {gameItemId} has {currentCount}, needs {quantity}"
                //);

                return currentCount >= quantity;
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogError($"PlayerHasGameItem failed for {gameItemId}: {ex}");
                return false;
            }
        }

        private static bool PlayerHasBlessing(string blessId)
        {
            try
            {
                DataSet dataSet = UnityEngine.Object.FindObjectOfType<DataSet>();

                if (dataSet == null)
                    return false;

                var skills = dataSet.GetSkillList_Special();

                if (skills == null)
                    return false;

                for (int i = 0; i < skills.Count; i++)
                {
                    string skillId = skills[i];

                    if (skillId == blessId)
                    {
                        Plugin.LogRef.LogWarning($"Blessing check: already has {blessId}");
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Plugin.LogRef.LogError($"PlayerHasBlessing failed for {blessId}: {ex}");
                return false;
            }
        }
    }
}