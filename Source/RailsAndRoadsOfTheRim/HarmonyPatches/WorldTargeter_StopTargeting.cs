using HarmonyLib;
using RimWorld;
using Verse;

namespace RailsAndRoadsOfTheRim;

[HarmonyPatch(typeof(WorldTargeter), nameof(WorldTargeter.StopTargeting))]
public static class WorldTargeter_StopTargeting
{
    public static void Prefix()
    {
        if (Current.ProgramState != ProgramState.Playing)
        {
            return;
        }

        if (RailsAndRoadsOfTheRim.RoadBuildingState.CurrentlyTargeting == null)
        {
            return;
        }

        //RailsAndRoadsOfTheRim.DebugLog("StopTargeting");
        RailsAndRoadsOfTheRim.FinaliseConstructionSite(RailsAndRoadsOfTheRim.RoadBuildingState.CurrentlyTargeting);
        RailsAndRoadsOfTheRim.RoadBuildingState.CurrentlyTargeting = null;
    }
}