using System.Collections.Generic;
using System.Text;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace RailsAndRoadsOfTheRim;

public class DefModExtension_RotR_RoadDef : DefModExtension
{
    public static readonly string[] allResources =
        ["WoodLog", "Stone", "Steel", "Chemfuel", "Plasteel", "Uranium", "ComponentIndustrial", "ComponentSpacer"];

    public static readonly string[] allResourcesAndWork =
    [
        "Work", "WoodLog", "Stone", "Steel", "Chemfuel", "Plasteel", "Uranium", "ComponentIndustrial",
        "ComponentSpacer"
    ];

    public static readonly string[] allResourcesWithoutModifiers = [];
    // testing if removing this makes it so Uranium and Components are affected by mod settings. -Vamp 12102022
    // Removed "  "Uranium", "ComponentIndustrial", "ComponentSpacer" " so mod settings would affect them.  Might put Uranimu back in if this does not work.

    // Base roads (DirtPath, DirtRoad, StoneRoad, AncientAsphaltRoad, AncientAsphaltHighway) will have this set to false, 
    // Built roads (DirtPath+, DirtRoad+, StoneRoad+, AsphaltRoad+, GlitterRoad) will have this set to true
    // Built roads will prevent rocks from being generated on top of them on maps

    public readonly float biomeModifier = 0f;
    public readonly bool built = false; // Whether this road is built or generated

    public readonly bool canBuildOnImpassable = false;

    public readonly bool canBuildOnWater = false;

    public readonly List<RotR_cost> costs = [];

    public readonly float hillinessModifier = 0f;

    public readonly float minConstruction = 0f;

    public readonly float percentageOfminConstruction = 0f;

    public readonly TechLevel techlevelToBuild = TechLevel.Neolithic;

    public readonly ResearchProjectDef techNeededToBuild = null;

    public readonly float winterModifier = 0f;

    public string GetCosts()
    {
        var s = new StringBuilder();
        s.Append($"The road is {(built ? "" : "not")} built. Costs : ");
        foreach (var c in costs)
        {
            s.Append($"{c.count} {c.name}, ");
        }

        return s.ToString();
    }

    public int GetCost(string name)
    {
        var aCost = costs.Find(c => c.name == name);
        return aCost?.count ?? 0;
    }

    public static bool GetInSituModifier(string resourceName, int ISR2G)
    {
        var result = false;
        switch (resourceName)
        {
            case "WoodLog":
                result = ISR2G > 0;
                break;
            case "Stone":
                result = ISR2G > 0;
                break;
            case "Steel":
                result = ISR2G > 1;
                break;
            case "Chemfuel":
                result = ISR2G > 1;
                break;
            case "Plasteel":
                result = ISR2G > 1;
                break;
            case "Uranium":
                result = ISR2G > 1;
                break;
        }

        return result;
    }

    public static bool BiomeAllowed(int tile, RoadDef roadDef, out BiomeDef biomeHere)
    {
        var RoadDefMod = roadDef.GetModExtension<DefModExtension_RotR_RoadDef>();
        biomeHere = Find.WorldGrid.tiles[tile].biome;
        if (RoadDefMod.canBuildOnWater && (biomeHere.defName == "Ocean" || biomeHere.defName == "Lake"))
        {
            return true;
        }

        return biomeHere.allowRoads;
    }

    public static bool ImpassableAllowed(int tile, RoadDef roadDef)
    {
        var RoadDefMod = roadDef.GetModExtension<DefModExtension_RotR_RoadDef>();
        var hillinnessHere = Find.WorldGrid.tiles[tile].hilliness;
        if (RoadDefMod.canBuildOnImpassable && hillinnessHere == Hilliness.Impassable)
        {
            return true;
        }

        return hillinnessHere != Hilliness.Impassable;
    }
}