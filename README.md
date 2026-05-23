# WitchSpring-R-Archipelago
Repository for my attempt at the WitchSpring R [Archipelago](https://archipelago.gg/) randomizer!<br>
**Disclaimer** I had a friend helping me with the mod and they even helped fix up my portion that I wrote before they offered. They are no longer helping out. I am not a dev by any means and my coding knowledge I know isn't up to par with many of our fine people from the Archipelago community. So if there is anyone else who knows more and is willing to help out, or take over, then please don't hesitate! This also means that I will take some time to work out any bugs or anything that crop up when it comes to the client/mod side of things. I mostly handled item/location data before they joined in.<br>
<br>
Logic currently works through Chapter 1 and partially through Chapter 2. In theory any chapter goal setting should function, untested and Chapter 8 is questionable if it even exists in the coding or not. But I do not currently recommend going past Chapter 2 for stability. 

## Installation
1. Install [BepInEx Unity IL2CPP](https://builds.bepinex.dev/projects/bepinex_be) into the [WitchSpring R](https://store.steampowered.com/app/1958220/WitchSpring_R/) game folder<br>
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

## Known Bugs
- Game may hard-lock if you attempt to initiate a convo when they are expecting you to have a certain item. IE; If you are supposed to have the Prototype Steam Engine and initiate the conversation to hand it over, the game will lock up forcing you to Alt+F4
- There are items in the pool that aren't real or not usable. They will show up in your inventory with a placeholder icon. Some of these can be used, but most of these will just take up a spot in your inventory.
- Blessings and special abilities will be unusable until you fight the Mid-Rank Warrior near Pieberry's House
- You will have duplicate Blessings. The ones received from the multiworld will not have the turn timer shown, but will be usable when their specific timer is allowed. The ones received from cutscenes will have the normal turn timer shown. Both will function independantly of each other - I had issues replacing the granting during the cutscene with another item as it would just lock up the cutscene. 
