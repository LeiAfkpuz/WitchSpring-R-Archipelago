# WitchSpring-R-Archipelago
Repository for my attempt at the WitchSpring R [Archipelago](https://archipelago.gg/) randomizer!<br>
Logic currently works through Chapter 1 and partially through Chapter 2. In theory any chapter goal setting should function, untested and Chapter 8 is questionable if it even exists in the coding or not. But I do not currently recommend going past Chapter 2 for stability. 

## Installation
1. Install [BepInEx Unity IL2CPP](https://builds.bepinex.dev/projects/bepinex_be) into the WitchSpring R game folder<br>
   ( Tested with [BepInEx 6.0.0-be.755](https://builds.bepinex.dev/projects/bepinex_be/755/BepInEx-Unity.IL2CPP-win-x64-6.0.0-be.755%2B3fab71a.zip) ) 
2. Launch the game once for the folders to be created
3. Place the WitchSpringRArchipelago.dll into the new BepInEx/plugins folder / Or replace the plugins folder with the one from the .zip
4. Install the .apworld - by default you should be able to double click this for your Archipelago setup to automatically place it. Otherwise, it goes into the custom worlds folder.

## Connecting to the game   
1. Launch the WitchSpring R Client from Archipelago
2. Connect to your slot in the client<br>
   **You must launch the WitchSpring R Client from Archipelago and connect to your slot BEFORE launching the game**
3. Launch WitchSpring R game
4. Start a new game

## What is randomized?
- Current logic only fully functional up until the Chapter 2 splash screen. Semi-functional throughout Chapter 2. 
- Magic circles, spellbooks, items, equipment and blessings are all in the item pool. <br>
- You still receive regular blessings at the normal part of the story, so you will end up with duplicate blessings for use, they do not share a timer, enjoy the extra power!<br>
- Overworld item checks give you a check for the multiworld on the first pickup, every subsequent pickup is the vanilla item.<br>
- Chests are randomized, and should not be granting their vanilla reward.<br>
