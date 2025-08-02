# GitHub Copilot Instructions for "Rails and Roads of the Rim (Continued)"

## Mod Overview
"Rails and Roads of the Rim (Continued)" is a continuation and expansion of Loconeko's "Roads of the Rim", providing players the ability to construct buildable rails and roads on the world map in RimWorld. This mod enables seamless integration with other transport and aesthetic mods such as SRTS Trains and Decorative Railway Props, enriching the gameplay with advanced transportation structures.

## Key Features and Systems
- **Construction Sites**: Players can create rail or road construction sites on the world map. Caravans with skilled colonists and necessary resources can be sent to construct these infrastructures.
- **Variety of Roads and Rails**: Offers different tiers such as asphalt roads, glitter roads, and rail tunnels, which can bypass difficult terrains, including impassable regions.
- **Movement Enhancement**: High-tier roads increase caravan movement speed, and some terrain difficulties can be nullified.
- **Realistic Resource Management**: Construction costs vary by terrain and elevation, and resources can be transported incrementally.
- **Upgradeability**: Existing roads can be upgraded for reduced costs.
- **Allied Assistance**: Allied factions can contribute to construction efforts.

## Coding Patterns and Conventions
- **Static Classes for Utility Functions**: Usage of static classes, such as `Alert_CaravanIdle_GetExplanation`, to encapsulate methods related to specific game alerts and gizmos enhances readability and code organization.
- **Naming Conventions**: CamelCase for methods and PascalCase for class definitions ensure clarity and consistency across the codebase.
- **Extended Classes**: Usage of Mod-specific extensions in classes, e.g., `DefModExtension_RotR_RoadDef`, enables specific mod functionality without altering base game mechanics.

## XML Integration
- XML files are used for defining road and rail types, resource costs, and construction parameters. 
- The method `LoadDataFromXmlCustom(XmlNode xmlRoot)` in `RotR_cost` facilitates custom XML loading, allowing dynamic resource cost configurations.

## Harmony Patching
- The `HarmonyPatches` class includes patches for enhancing game functionality and integrating the mod seamlessly with existing game mechanics.
- `Patch_WorldLayer_Paths_AddPathEndpoint` represents a typical Harmony patch structure, allowing for greater customization of the world map rendering process.
- Use Harmony's Prefix and Postfix methods to maintain compatibility with other mods and minimize conflicts.

## Suggestions for Copilot
- **Suggested Method Implementations**: When working on new feature additions, suggest method stubs or utility functions based on existing patterns in the codebase, e.g., adding more railroad types or custom caravan behaviors using patterns seen in `Caravan_GetInspectString`.
- **Example XML Definitions**: Recommend XML snippet examples for defining new roads and their properties, leveraging patterns seen in existing XML integrations.
- **Harmony Usage**: When implementing new game modifications, suggest appropriate Harmony patch templates to ensure compatibility and maintain the game's logic integrity.
- **Debugging and Optimization Tips**: Propose debug logging implementations or performance optimizations for areas like world path calculations or large data handling to assist in robust mod development.
- **Code Documentation Suggestions**: Recommend inline documentation enhancements for complex methods within classes like `CaravanArrivalAction_StartWorkingOnRoad` for better understanding and maintainability.
