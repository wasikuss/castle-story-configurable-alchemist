
using Brix.External.Factories;
using Brix.Game.AI;
using Brix.Game.Semantique;
using Brix.Lifecycle.Pooling;

using HarmonyLib;

using UnityEngine;
using System.Linq;

namespace CastleStory_ConfigurableAlchemist {
    [HarmonyPatch(typeof(Transaction), "ConvertToAmmo")]
    public class TransactionPatch { 
        
        static bool Prefix(ProjectileWeapon wepon, Recepteur target) {
            if(
                wepon.name.StartsWith("Backpack") && ConfigurableAlchemist.Instance != null && ConfigurableAlchemist.Instance.CurrentConfig.MaxAmmo > 0 &&
                (ConfigurableAlchemist.Instance.CurrentConfig.IsGlobal || wepon.faction.IsOwnedByMe)
            ) {
                int num = Mathf.Max(ConfigurableAlchemist.Instance.CurrentConfig.MaxAmmo - wepon.AmmoCountGetter, 0);
                int num2 = 0;
                for (int i = 0; i < num; i++) {
                    IDescriptor descriptor = target.StoredItems.FirstOrDefault((IDescriptor item) => item.AssetKey == BuildResources.Bomb);
                    if (descriptor != null) {
                        num2++;
                        ObjectPoolSingleton.Release(descriptor.GameObject);
                    }
                }
                wepon.AmmoCountGetter += num2;
                return false;
            }
            return true;
        }
    }
}
