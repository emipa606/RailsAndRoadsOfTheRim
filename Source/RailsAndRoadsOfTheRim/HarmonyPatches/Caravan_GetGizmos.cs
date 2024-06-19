using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace RailsAndRoadsOfTheRim;

[HarmonyPatch(typeof(Caravan), nameof(Caravan.GetGizmos))]
public static class Caravan_GetGizmos
{
    public static void Postfix(ref IEnumerable<Gizmo> __result, Caravan __instance)
    {
        var isThereAConstructionSiteHere =
            Find.WorldObjects.AnyWorldObjectOfDefAt(DefDatabase<WorldObjectDef>.GetNamed("RoadConstructionSite"),
                __instance.Tile);
        var isTheCaravanWorkingOnASite = true;
        try
        {
            isTheCaravanWorkingOnASite = __instance.GetComponent<WorldObjectComp_Caravan>().currentlyWorkingOnSite;
        }
        catch (Exception e)
        {
            RailsAndRoadsOfTheRim.DebugLog(null, e);
        }

        __result = __result.Concat([RailsAndRoadsOfTheRim.AddConstructionSite(__instance)])
            .Concat([RailsAndRoadsOfTheRim.RemoveConstructionSite(__instance.Tile)]);
        if (isThereAConstructionSiteHere & !isTheCaravanWorkingOnASite &&
            RailsAndRoadsOfTheRim.RoadBuildingState.CurrentlyTargeting == null)
        {
            __result = __result.Concat([RailsAndRoadsOfTheRim.WorkOnSite(__instance)]);
        }

        if (isTheCaravanWorkingOnASite)
        {
            __result = __result.Concat([RailsAndRoadsOfTheRim.StopWorkingOnSite(__instance)]);
        }
    }
}