using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;
using Verse.Sound;

namespace RailsAndRoadsOfTheRim;
/*
Nice looking cartridge-style option picker
Layout : 1 vertical cartridge per type of buidalble road
Each cartridge has :
- A square image at the top, representing the type of road
- The name of the road below
- A list of costs, one per line :
> Work
> WoodLog
> Stone
> Steel
> Chemfuel
> etc.
Each line starts with the icon of the resource (work uses the construction site icon)
Upon clicking outside, the cartridge is closed with no further actions
Upon clicking on a road icon, we set the roaddef of the site to that road and start targeting the map to add legs

Check, among others :
* Widgets many methods
*/

public class ConstructionMenu(RoadConstructionSite site, Caravan caravan) : Window
{
    private static Vector2 scrollPosition;
    private readonly List<RoadDef> buildableRoads = [];

    // TO DO : Use the below to dynamically draw the window based on number of buildable roads (which could include technolcogy limits)
    // public bool resizeable = true ;
    // private bool resizeLater = true ;
    // private Rect resizeLaterRect ;


    // TO DO : COunt number of buildable roads, set the resize later rect based on that

    public override Vector2 InitialSize => new(676 + 128, 544 + 128);
    // trying to make the whole menu larger by making the x value above larger, original is 676+128, assuming 64 for legend, that's about 122.4 per road option -
    // 1469 is not quite large enough, but I was right, the x value above does change the whole menu width.  Let's try 1700.  Yes, that works! - Vamp

    public int CountBuildableRoads()
    {
        foreach (var thisDef in DefDatabase<RoadDef>.AllDefs)
        {
            // Only add RoadDefs that are buildable, based on DefModExtension_RotR_RoadDef.built
            if (!thisDef.HasModExtension<DefModExtension_RotR_RoadDef>() ||
                !thisDef.GetModExtension<DefModExtension_RotR_RoadDef>().built)
            {
                continue;
            }

            buildableRoads.Add(thisDef);
        }

        return buildableRoads?.Count ?? 0;
    }

    public override void DoWindowContents(Rect inRect)
    {
        if (Event.current.isKey && site != null)
        {
            RailsAndRoadsOfTheRim.DeleteConstructionSite(site.Tile);
            Close();
        }

        var availableBuildableRoads = buildableRoads.Where(def =>
        {
            var roadDefExtension = def.GetModExtension<DefModExtension_RotR_RoadDef>();

            // Check if a tech is necessary to build this road, don't display the road if it isn't researched yet
            var neededTech = roadDefExtension.techNeededToBuild;
            var techResearched = neededTech == null || neededTech.IsFinished;

            return techResearched;
        });

        var outerRect = new Rect(64, 0, inRect.width - 64, inRect.height);
        var innerRect = new Rect(0, 0, availableBuildableRoads.Count() * 144, outerRect.height - 16);

        //Resources icons
        for (var i = 0; i < 9; i++)
        {
            // Icon
            var resourceRect = new Rect(0, 202f + (i * 40f), 32f, 32f);
            ThingDef theDef;
            switch (i)
            {
                case 0:
                    theDef = ThingDefOf.Spark;
                    break;
                case 1:
                    theDef = ThingDefOf.WoodLog;
                    break;
                case 2:
                    theDef = ThingDefOf.BlocksGranite;
                    break;
                case 3:
                    theDef = ThingDefOf.Steel;
                    break;
                case 4:
                    theDef = ThingDefOf.Chemfuel;
                    break;
                case 5:
                    theDef = ThingDefOf.Plasteel;
                    break;
                case 6:
                    theDef = ThingDefOf.Uranium;
                    break;
                case 7:
                    theDef = ThingDefOf.ComponentIndustrial;
                    break;
                default:
                    theDef = ThingDefOf.ComponentSpacer;
                    break;
            }

            if (i == 0)
            {
                Widgets.ButtonImage(resourceRect, ContentFinder<Texture2D>.Get("UI/Commands/AddConstructionSite"));
            }
            else
            {
                Widgets.ThingIcon(resourceRect, theDef);
            }
        }

        Widgets.BeginScrollView(outerRect, ref scrollPosition, innerRect);

        // Sections : one per type of buildable road
        var nbOfSections = 0;
        var groupSize = new Vector2(144, 512 + 128);
        foreach (var aDef in availableBuildableRoads)
        {
            var roadDefExtension = aDef.GetModExtension<DefModExtension_RotR_RoadDef>();

            GUI.BeginGroup(new Rect(new Vector2(144 * nbOfSections, 32f), groupSize));

            // Buildable Road icon
            var theButton = ContentFinder<Texture2D>.Get($"UI/Commands/Build_{aDef.defName}");
            var buttonRect = new Rect(8, 8, 128, 128);
            if (Widgets.ButtonImage(buttonRect, theButton))
            {
                if (Event.current.button == 0)
                {
                    SoundDefOf.Tick_High.PlayOneShotOnCamera();
                    if (site != null)
                    {
                        site.roadDef = aDef;
                        Close();
                        RailsAndRoadsOfTheRim.RoadBuildingState.CurrentlyTargeting = site;
                        RailsAndRoadsOfTheRim.RoadBuildingState.Caravan = caravan;
                        RoadConstructionLeg.Target(site);
                    }
                }
            }

            // Buildable Road label
            Text.Anchor = TextAnchor.MiddleCenter;
            Text.Font = GameFont.Medium;
            var nameRect = new Rect(0, 144, 144f, 32f);
            Widgets.Label(nameRect, aDef.label);

            // Resources amounts
            Text.Font = GameFont.Small;
            var i = 0;
            foreach (var resourceName in DefModExtension_RotR_RoadDef.allResourcesAndWork)
            {
                var ResourceAmountRect = new Rect(0, 176f + (i++ * 40f), 144f, 32f);
                Widgets.Label(ResourceAmountRect,
                    roadDefExtension.GetCost(resourceName) > 0
                        ? (roadDefExtension.GetCost(resourceName) *
                           ((float)RailsAndRoadsOfTheRim.settings.BaseEffort / 10)).ToString()
                        : "-"
                );
            }

            GUI.EndGroup();
            nbOfSections++;
        }

        Text.Anchor = TextAnchor.UpperLeft;
        Widgets.EndScrollView();
    }

    public override void
        PostClose() // If the menu was somehow closed without picking a road, delete the construction site
    {
        try
        {
            if (site.roadDef != null)
            {
                return;
            }

            RailsAndRoadsOfTheRim.DeleteConstructionSite(site.Tile);
        }
        catch (Exception e)
        {
            RailsAndRoadsOfTheRim.DebugLog(null, e);
        }
    }
}