using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DecreaseWeaponsDegradation
{
    [HarmonyPatch(typeof(BreakableItemComponent), nameof(BreakableItemComponent.Break))]
    internal class BreakableItemComponentPatch
    {
        private static bool Prefix(BreakableItemComponent __instance, ref int val)
        {

            if (!__instance.Unbreakable)
            {
                float num = (float)val * Plugin.Config.WeaponsDegradationMultiplier / 
                    (float) __instance.MaxDurability;

                __instance.CurrentPercent = Mathf.Clamp01(__instance.CurrentPercent - num);
            }

            return false;
        }

    }
}
