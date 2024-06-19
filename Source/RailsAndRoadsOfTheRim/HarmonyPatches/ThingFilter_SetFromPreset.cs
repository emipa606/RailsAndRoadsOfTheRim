﻿using HarmonyLib;
using RimWorld;
using Verse;

namespace RailsAndRoadsOfTheRim;

[HarmonyPatch(typeof(ThingFilter), nameof(ThingFilter.SetFromPreset))]
//Remove Road equipment from Item tab when forming caravans
public static class ThingFilter_SetFromPreset
{
    public static void Postfix(ref ThingFilter __instance, StorageSettingsPreset preset)
    {
        if (preset != StorageSettingsPreset.DefaultStockpile)
        {
            return;
        }

        __instance.SetAllow(ThingCategoryDef.Named("RoadEquipment"), true);
    }
}