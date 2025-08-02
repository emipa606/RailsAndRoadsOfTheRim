using System.Collections.Generic;
using HarmonyLib;
using RimWorld.Planet;

namespace RailsAndRoadsOfTheRim;

[HarmonyPatch(typeof(SurfaceTile), nameof(SurfaceTile.Roads), MethodType.Getter)]
public static class SurfaceTile_Roads
{
    public static void Postfix(SurfaceTile __instance, ref List<SurfaceTile.RoadLink> __result)
    {
        __result = __instance.potentialRoads;
    }
}