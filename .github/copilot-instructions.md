# Copilot Instructions for "Rails and Roads of the Rim (Continued)" Mod

## Mod Overview and Purpose
"Rails and Roads of the Rim (Continued)" (RRotR) is an expansion and continuation of the popular "Roads of the Rim" mod, originally developed by Loconeko and further building upon Jecrell's "RimRoads" from the beta version of RimWorld. The primary purpose of this mod is to facilitate the construction of roads and railways on the world map, enhancing transportation efficiency and aesthetic visual appeal in the game. The mod supports integration with other transportation-related mods such as SRTS Trains and Decorative Railway Props.

## Key Features and Systems
- **Construction Sites:** Players can establish construction sites on the world map for building roads and railways by sending caravans equipped with skilled colonists and necessary resources.
- **Road/Rail Types:** Includes various road types such as asphalt and glitter roads, as well as rail tunnels capable of traversing impassable terrain.
- **Movement Enhancements:** Roads and rails reduce biome, hills, swamps, and season movement difficulties, enhancing caravan speed.
- **Upgrade Mechanism:** Roads can be upgraded to higher tier roads, offering partial reimbursement of existing road resources.
- **Ally Assistance:** Allied factions can contribute to construction efforts, speeding up project completion.
- **Cost and Difficulty Settings:** Construction costs vary based on terrain and can be adjusted within mod settings to reflect different levels of realism.

## Coding Patterns and Conventions
- **Static Classes:** Extensively used for utility functions and static methods.
- **Public Classes and Methods:** Ensures accessibility across the mod's architecture, providing flexibility to integrate with Harmony patches and other mods.
- **Consistent Naming:** Names follow C# standards with PascalCasing for classes and methods, improving code readability and maintainability.

## XML Integration
- **Def Mod Extensions:** Custom XML definitions are used to configure road and rail properties (e.g., `DefModExtension_RotR_RoadDef`).
- **XML Parsing:** The mod employs XML to JSON serialization for mod configuration, ensuring efficient data management (e.g., `RotR_cost` class).

## Harmony Patching
- **Patch Implementation:** Harmony patches are used to alter core game functionalities for compatibility with RRotR features. The `HarmonyPatches` class and `Patch_WorldLayer_Paths_AddPathEndpoint` provide seamless integration.
- **Method Patching:** Patches modify game methods to adapt the base movement and construction logic to accommodate new transportation systems.

## Suggestions for Copilot
- **Leverage Code Templates:** Utilize existing static classes as templates when adding new utility functions.
- **Harmony Patch Templates:** Employ patch method patterns for expanding mod compatibility with future game updates.
- **XML Handling:** Use defined XML parsing methods for integrating additional configurable options or road types.
- **Consistent Naming:** Maintain standardized naming conventions to improve mod code integration and future scalability.
- **Documentation Comments:** Encourage comprehensive XML and C# documentation comments to assist in mod debugging and collaboration.

With these instructions and insights into the mod's architecture, GitHub Copilot can assist developers in maintaining and expanding the RRotR functionality for the RimWorld player community.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.
