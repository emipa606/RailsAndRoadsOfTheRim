﻿using RimWorld.Planet;
using UnityEngine;
using Verse;

namespace RailsAndRoadsOfTheRim;

[StaticConstructorOnStartup]
internal static class RotR_StaticConstructorOnStartup
{
    public static readonly Texture2D ConstructionLeg_MouseAttachment =
        ContentFinder<Texture2D>.Get("UI/Overlays/ConstructionLeg");

    public static readonly Material ConstructionLegLast_Material = MaterialPool.MatFrom(
        "World/WorldObjects/ConstructionLegLast", ShaderDatabase.WorldOverlayTransparentLit,
        WorldMaterials.DynamicObjectRenderQueue);
}