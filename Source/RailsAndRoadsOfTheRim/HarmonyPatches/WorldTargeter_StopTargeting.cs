using HarmonyLib;
using RimWorld;

namespace RailsAndRoadsOfTheRim;

[HarmonyPatch(typeof(WorldTargeter), nameof(WorldTargeter.StopTargeting))]
public static class WorldTargeter_StopTargeting
{
    public static void Prefix()
    {
        if (RailsAndRoadsOfTheRim.RoadBuildingState.CurrentlyTargeting == null)
        {
            return;
        }

        //RailsAndRoadsOfTheRim.DebugLog("StopTargeting");
        RailsAndRoadsOfTheRim.FinaliseConstructionSite(RailsAndRoadsOfTheRim.RoadBuildingState.CurrentlyTargeting);
        RailsAndRoadsOfTheRim.RoadBuildingState.CurrentlyTargeting = null;
    }
}