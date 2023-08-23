
using Brix.Game;
using Brix.Game.AI;
using Brix.Game.AI.Damage;

using HarmonyLib;

using System;

namespace CastleStory_ConfigurableAlchemist {
    [HarmonyPatch(typeof(SelectionCircle), "Stamina", new Type[] { typeof(Labor), typeof(BricktronDamageReceiver) })]
    public class SelectionCirclePatch { 
        
        static bool Prefix(SelectionCircle __instance, Labor labor) {
            if(labor.Occupation.CurrentJob == Occupation.Job.Alchemist && ConfigurableAlchemist.Instance != null && ConfigurableAlchemist.Instance.Config.MaxAmmo > 0) {
                __instance.SecondaryColor(SelectionCircle.SecondaryColors.Heat);
                __instance.Stamina(labor.GetComponent<CharacterState>().AmmoCount / (float)ConfigurableAlchemist.Instance.Config.MaxAmmo);
                __instance.ShowStamina(Affiliation.BelongsToAllied(labor.gameObject));
                return false;
            }
            return true;
        }
    }
}
