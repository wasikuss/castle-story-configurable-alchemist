using Brix.Game.AI;
using Brix.Game.Components;

using System.Collections.Generic;
using UnityEngine;
using HarmonyLib;

namespace CastleStory_ConfigurableAlchemist {
    [HarmonyPatch(typeof(Recipe), "SpawnAll")]
    public class RecipePatch { 
        static void Postfix(List<GameObject> gos, Vector3 pos) {
            gos.ForEach((obj) => {
                if (obj.name.StartsWith("Backpack") && ConfigurableAlchemist.Instance != null && ConfigurableAlchemist.Instance.CurrentConfig.MaxAmmo > 0) {
                    var projectileWeapon = obj.GetComponent<ProjectileWeapon>();
                    if (ConfigurableAlchemist.Instance.CurrentConfig.IsGlobal || projectileWeapon.faction.IsAlliedOrNeutralToMe) {
                        projectileWeapon.AmmoCountGetter = ConfigurableAlchemist.Instance.CurrentConfig.DefaultAmmo;
                    }
                }
            });
        }
    }
}
