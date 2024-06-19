﻿using HarmonyLib;
using RimWorld;
using Verse;

namespace RailsAndRoadsOfTheRim;

[HarmonyPatch(typeof(GenConstruct), nameof(GenConstruct.CanBuildOnTerrain))]
public static class GenConstruct_CanBuildOnTerrain
{
    public static void Postfix(ref bool __result, BuildableDef entDef, IntVec3 c, Map map)
    {
        if (entDef != TerrainDefOf.ConcreteBridge && entDef != TerrainDefOf.AsphaltRecent &&
            entDef != TerrainDefOf.GlitterRoad)
        {
            return;
        }

        if (!map.terrainGrid.TerrainAt(c).IsWater)
        {
            return;
        }

        __result = true;
    }
}