﻿using HarmonyLib;
using RimWorld;
using Verse;

namespace RailsAndRoadsOfTheRim;

[HarmonyPatch(typeof(RoadDefGenStep_Place), nameof(RoadDefGenStep_Place.Place))]
public static class RoadDefGenStep_Place_Place
{
    public static bool IsGoodTerrain(TerrainDef terrain)
    {
        return terrain == TerrainDefOf.Mud || terrain == TerrainDefOf.MarshyTerrain;
    }

    public static void Postfix(ref RoadDefGenStep_Place __instance, Map map, IntVec3 position)
    {
        if (__instance.place == TerrainDefOf.ConcreteBridge && position.GetTerrain(map).IsWater)
        {
            map.terrainGrid.SetTerrain(position, TerrainDefOf.ConcreteBridge);
        }

        if (__instance.place == TerrainDefOf.GlitterRoad &&
            (IsGoodTerrain(position.GetTerrain(map)) || position.GetTerrain(map).IsWater))
        {
            map.terrainGrid.SetTerrain(position, TerrainDefOf.GlitterRoad);
        }

        if (__instance.place == TerrainDefOf.Railroad &&
            (IsGoodTerrain(position.GetTerrain(map)) || position.GetTerrain(map).IsWater))
        {
            map.terrainGrid.SetTerrain(position, TerrainDefOf.Railroad);
        }

        if (__instance.place == TerrainDefOf.Glitterrail &&
            (IsGoodTerrain(position.GetTerrain(map)) || position.GetTerrain(map).IsWater))
        {
            map.terrainGrid.SetTerrain(position, TerrainDefOf.Glitterrail);
        }

        if (__instance.place == TerrainDefOf.AsphaltRecent && IsGoodTerrain(position.GetTerrain(map)))
        {
            map.terrainGrid.SetTerrain(position, TerrainDefOf.AsphaltRecent);
        }

        if (__instance.place == TerrainDefOf.StoneRecent && IsGoodTerrain(position.GetTerrain(map)))
        {
            map.terrainGrid.SetTerrain(position, TerrainDefOf.StoneRecent);
        }
    }
}