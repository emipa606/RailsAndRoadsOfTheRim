﻿using System.Text;
using HarmonyLib;
using RimWorld;
using Verse;

namespace RailsAndRoadsOfTheRim;

[HarmonyPatch(typeof(Alert_CaravanIdle), nameof(Alert_CaravanIdle.GetExplanation))]
public static class Alert_CaravanIdle_GetExplanation
{
    public static void Postfix(ref TaggedString __result)
    {
        var stringBuilder = new StringBuilder();
        foreach (var caravan in Find.WorldObjects.Caravans)
        {
            var caravanComp = caravan.GetComponent<WorldObjectComp_Caravan>();
            if (!caravan.Spawned || !caravan.IsPlayerControlled || caravan.pather.MovingNow || caravan.CantMove ||
                caravanComp.currentlyWorkingOnSite)
            {
                continue;
            }

            stringBuilder.AppendLine($"  - {caravan.Label}");
        }

        __result = "CaravanIdleDesc".Translate(stringBuilder.ToString());
    }
}