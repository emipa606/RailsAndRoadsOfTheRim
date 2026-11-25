using System.Linq;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace RailsAndRoadsOfTheRim.HarmonyPatches;

[StaticConstructorOnStartup]
public static class HarmonyPatches
{
    static HarmonyPatches()
    {
        new Harmony("Loconeko.Rimworld.RailsAndRoadsOfTheRim").PatchAll(Assembly.GetExecutingAssembly());

        // Initialise the list of terrains that are specific to built roads. Doing it here is hacky, but this is a quick way to use defs after they were loaded
        foreach (var thisDef in DefDatabase<RoadDef>.AllDefs)
        {
            if (!thisDef.HasModExtension<DefModExtension_RotR_RoadDef>() ||
                !thisDef.GetModExtension<DefModExtension_RotR_RoadDef>().built
               ) // Only add RoadDefs that are buildable, based on DefModExtension_RotR_RoadDef.built
            {
                continue;
            }

            foreach (var aStep in thisDef.roadGenSteps.OfType<RoadDefGenStep_Place>()
                    ) // Only get RoadDefGenStep_Place
            {
                var t = (TerrainDef)aStep.place; // Cast the buildableDef into a TerrainDef
                if (!RailsAndRoadsOfTheRim.builtRoadTerrains.Contains(t))
                {
                    RailsAndRoadsOfTheRim.builtRoadTerrains.Add(t);
                }
            }
        }
    }
}