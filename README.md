# [Rails and Roads of the Rim (Continued)](https://steamcommunity.com/sharedfiles/filedetails/?id=3271115410)

![Image](https://i.imgur.com/buuPQel.png)

Update of Vampiresbanes mod https://steamcommunity.com/sharedfiles/filedetails/?id=2896163437

- Added scrollbar for road-types
- Added back the ISR2Gs

![Image](https://i.imgur.com/pufA0kM.png)
	
![Image](https://i.imgur.com/Z4GOv8H.png)

# Rails and Roads of the Rim


**RRotR - A Rimworld mod allowing rail and road construction on the world map.**

# Introduction


This is an continuation and expansion on Loconeko's "[Roads of the Rim](https://steamcommunity.com/sharedfiles/filedetails/?id=1613783924)" which was a successor to Jecrell's [RimRoads](https://steamcommunity.com/sharedfiles/filedetails/?id=1156492920) from beta Rimworld.  This expansion on Roads of the Rim adds buildable rail to the buildable road options. The rail portion of this mod is intended to be used alongside mods such as [SRTS Trains](https://steamcommunity.com/sharedfiles/filedetails/?id=2846959702) and/or [Decorative Railway Props](https://steamcommunity.com/sharedfiles/filedetails/?id=2844194752).  

# Features



  - Create Rail or Road Construction Sites on the world map
  - Send Caravans with skilled colonists, pack animals, and resources to build the rail or the road
  - Enjoy faster movement than the base game on high tier roads, including for all already existing roads (can be switched off in the settings)
  - Part or all of the biome, hills, swamps and season movement difficulty is also cancelled depending on the rail or road
  - Asphalt roads, glitter roads and rail tunnels can be built through impassable terrain
  - Get your allies to help you build



# Details


**Construct**
With RRotR, caravans can create a construction site on the world map, players can then select a type of rail or road, **<ins>left click</ins>** from neighbouring tile to neighbouring tile until they reach their desired goal and then right click to build. If you make a mistake, clicking on a planned section of rail or road will remove it and all sections after it. Clicking on the Construction Site or right-clicking anywhere will finalise the construction.

Do note that rail overpasses should not be used to go over more than one tile of road or rail.  Due to a limit to the core or mod coding, this does not render properly.

**Work**
By using resources and colonists with Construction skill, the current section (or leg) can be built. A progress bar is shown on the world map.  Once a leg is finished, the caravan automatically moves on to the next leg.
Note : Rail and road legs must be built in the order they were placed on the world map. 

Having all colonists down, resting during night time, or a moving caravan will prevent work. Similarly, some rail and roads require a certain percentage of the workforce to have a certain construction skill. If only a lower percentage is available, work will be reduced. If no colonist in the caravan has the required skill, work will be impossible. Prisoners don't work.

**Cancel construction**
A site can be removed by selecting it and clicking on the "Cancel Construction" button. A Caravan does not need to be there to do so. All resources spent so far will be lost.

**Building costs modifiers**
Construction costs have two components : base costs that depend on the road and modifiers that depend on the terrain. Rail and roads cost more at higher elevation, starting from 1000m. Hills and swamps also have an effect, which can be checked when clicking on a site. 

The total cost can be further reduced from 100% down to 10% in the settings. The original author, Loconeko, believed that anything lower than 100% is probably quite unrealistic, but I believe that 10% is actually realistic if playing with a small settlement or you want to be able to build a lot of roads and rail.  To adjust the cost settings be sure to turn off the setting for enabling ISR2G which I've disabled anyways due to the ISR2G causing too many bugs.  Adjust to your liking and taste.

**Important note**
It is not necessary to bring all resources at once in one caravan. A fraction is enough for a certain amount of work. However, it is necessary to bring each material with you. As an example a tenth of the asphalt road: 360 Stone, 60 Steel, 30 Chemfuel is enough material for a tenth of the work (180 work.) 

**Upgrade**
When building a road over an existing one that is slower, 30% of the cost of the existing road will be deducted from the cost of the new road, as long as both roads use that same resource (e.g. A dirt road will provide 120 work and 36 wood when upgrading to a Stone road.)
Note: Railroads cannot be upgraded.

**Allies help**
Allied factions can help building rail or roads.

**Impact on movement**
The roads of RRotR do not only provide a customized movement cost multiplier compared to the base game, they also cancel some or all of the movement cost of the terrain.  

Rails only provide a partial movement cost multiplier. This is because SRTS Trains, which provides loadable and usable trains, uses retextured drop pod sprites and so the trains ignore terrain on the world map and their speed is modifiable through SRTS Trains' settings.  Because of this, the buildable rails are for mostly aesthetic purposes only.  The general movement cost multiplier (60%) used for both railroad track and glitterrail is to reflect the general speed increase a person and/or animal would gain by walking on railroad track instead of normal terrain or a specifically built type of road.   

To see required resources for each type of road or rail, see construction menu preview above.     

See the Terrain Feature summary above to see what percentage of a specific terrain feature is cancelled, depending on the rail or road type. Note that these effects apply both to generated roads (from the base game) and built rail and roads from RRotR.  Lastly, both glitter roads, glitterrail, and railroad can be built over water, but no roads or rail of any kind, sadly, can be built on ice sheet or sea ice.  The base game does not allow for this and neither Loconeko nor I ever figured out a solution.

# Giving Feedback
 
       
Feedback is more than welcome on Steam.

You're welcome to also alter the base xml code that I added for the 

![Image](https://i.imgur.com/PwoNOj4.png)



-  See if the the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Post your error-log using [HugsLib](https://steamcommunity.com/workshop/filedetails/?id=818773962) or the standalone [Uploader](https://steamcommunity.com/sharedfiles/filedetails/?id=2873415404) and command Ctrl+F12
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.
-  Use [RimSort](https://github.com/RimSort/RimSort/releases/latest) to sort your mods



[![Image](https://img.shields.io/github/v/release/emipa606/RailsAndRoadsOfTheRim?label=latest%20version&style=plastic&color=9f1111&labelColor=black)](https://steamcommunity.com/sharedfiles/filedetails/changelog/3271115410)
