# GitHub Copilot Instructions for Rails and Roads of the Rim (Continued) Mod

This guide provides instructions for using GitHub Copilot to assist in developing the Rails and Roads of the Rim (Continued) mod for RimWorld.

## Mod Overview and Purpose

The Rails and Roads of the Rim (Continued) mod is an update to the Vampiresbanes mod and continues the expansion on Loconeko's "Roads of the Rim." This mod adds buildable rail to the buildable road options, allowing for faster movement and improved construction sites on the world map. It also supports the SRTS Trains and Decorative Railway Props mods.

## Key Features and Systems

### Construction
- Caravans can create construction sites on the world map.
- Players can select rail or road types and plan routes.
- Mistakes can be corrected by clicking on planned sections.
- Construction sites can be cancelled at any time, with resources lost.

### Work
- Resources and skilled colonists are used to build construction sites.
- Progress is shown on the world map.
- Construction must be done in the order planned.
- Movement of caravans and colonist availability affect work progress.

### Building Costs
- Base costs depend on the type of road or rail.
- Terrain modifiers affect costs.
- Construction costs can be reduced in settings.

### Upgrades
- Existing roads can be upgraded to faster types.
- Rails cannot be upgraded.

### Allies Help
- Allied factions can assist in building rail or roads.

### Impact on Movement
- Roads and rails provide movement cost multipliers.
- Rails cancel some terrain movement costs.
- Glitter roads, glitterrail, and railroad can be built over water.

## Coding Patterns and Conventions

1. **Mod Structure**:
   - Follow the standard RimWorld mod structure with separate folders for XML and C# files.
   - Use meaningful naming conventions for classes, methods, and variables.

2. **C# Code**:
   - Use `HarmonyPatches` for modding.
   - Implement methods in classes that handle specific functionalities (e.g., `CaravanArrivalAction_StartWorkingOnRoad` for handling arrival actions).
   - Use `DefModExtension` for custom properties of definitions.

3. **XML Integration**:
   - Define XML files for game objects and settings.
   - Use `Defs` folders to organize different types of definitions (e.g., `ResearchProjectDefs`).

4. **Error Handling**:
   - Implement error handling and logging for better mod stability and troubleshooting.

## XML Integration

### XML Files

1. **GenStepDef**:
   - Define generation steps for roads and rails in the `MapGeneration` folder.

2. **DesignatorDropdownGroupDef**:
   - Define designator dropdown groups for easy access to road and rail construction tools.

3. **TerrainAffordanceDef**:
   - Define terrain affordances that allow roads and rails to be built on specific terrains.

4. **ResearchProjectDef**:
   - Define research projects related to roads and rails.

5. **ResearchTabDef**:
   - Define research tabs for organizing related research projects.

### XML Example

xml
<!-- E:\SteamLibrary\steamapps\common\RimWorld\Mods\RailsAndRoadsOfTheRim\1.6\Defs\ResearchProjectDefs\ResearchProject_RotR.xml -->
<Defs>
  <ResearchProjectDef>
    <defName>RotR_Railroads</defName>
    <label>Railroads</label>
    <description>Research railroads to build faster movement tracks.</description>
    <baseCost>5000</baseCost>
    <techLevel>Advanced</techLevel>
    <prerequisites>
      <li>RotR_Roads</li>
    </prerequisites>
    <effects>
      <li>ResearchEffectDef named="ResearchEffect_Railroads"</li>
    </effects>
  </ResearchProjectDef>
</Defs>


## Harmony Patching

### HarmonyPatches Example

csharp
// E:\SteamLibrary\steamapps\common\RimWorld\Mods\RailsAndRoadsOfTheRim\Source\RailsAndRoadsOfTheRim\HarmonyPatches\Caravan_GetGizmos.cs
using HarmonyLib;
using RimWorld;
using Verse;

namespace RailsAndRoadsOfTheRim.HarmonyPatches
{
    [HarmonyPatch(typeof(Caravan), nameof(Caravan.GetGizmos))]
    public static class Caravan_GetGizmos
    {
        public static void Postfix(Caravan __instance, ref IEnumerable<Gizmo> __result)
        {
            // Add custom gizmos for the caravan
            List<Gizmo> gizmos = __result.ToList();
            gizmos.Add(new Command_RotateRoad { caravan = __instance });
            __result = gizmos;
        }
    }
}


## Suggestions for Copilot

1. **Contextual Snippets**:
   - Use contextual snippets to generate code based on specific class or method requirements.
   - Example: Generate a `CaravanArrivalAction` method for handling arrival actions.

2. **Code Completion**:
   - Use code completion to quickly add methods and properties to existing classes.
   - Example: Add a new method to `CaravanState` for handling state transitions.

3. **XML Definition Generation**:
   - Use Copilot to generate XML definitions for new game objects.
   - Example: Generate an XML definition for a new road type.

4. **Harmony Patch Generation**:
   - Use Copilot to generate Harmony patches for modifying existing game behavior.
   - Example: Generate a patch for adding new gizmos to caravans.

5. **Error Handling and Logging**:
   - Use Copilot to generate error handling and logging code for better mod stability.
   - Example: Add try-catch blocks and logging statements to critical methods.

By following these guidelines and suggestions, developers can efficiently use GitHub Copilot to enhance the Rails and Roads of the Rim (Continued) mod for RimWorld.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Temporary files

- Do not create temporary files, build output, test artifacts, or Copilot session
  folders inside the mod root.
- Store temporary artifacts under `%USERPROFILE%\CopilotTemp\[modname]`.
- Direct build and test output there as well, without changing project settings.
- Clean up task-specific temporary artifacts when finished.

## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

