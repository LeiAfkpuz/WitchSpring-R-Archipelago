import typing
from collections.abc import Mapping
from typing import Any
from .options import GoalChoice
from dataclasses import dataclass
from Options import PerGameCommonOptions

import settings
from BaseClasses import Region, Entrance, Tutorial, LocationProgressType
from . import items, locations, regions, rules

from worlds.AutoWorld import World, WebWorld

#from . import options as wsr_options

class WSRSettings(settings.Group):
    class GamePath(settings.UserFolderPath):
        """
        Path to your WitchSpring R install folder (the folder that contains the game exe
        and the BepInEx folder). The client and the game mod exchange items through an
        "Archipelago" subfolder created inside it.
        """
        description = "WitchSpring R install folder"

    game_path: GamePath = GamePath("C:/Program Files (x86)/Steam/steamapps/common/WitchSpring R")

class WSRWeb(WebWorld):
    game = "Witchspring R"
    theme = "ice"
    setup_en = Tutorial(
        "Multiworld Setup Guide",
        "Setup guide",
        "English",
        "setup_en.md",
        "setup/en",
        "LeiAfkpuz",
    )
    tutorials = [setup_en]

@dataclass
class WSROptions(PerGameCommonOptions):
    goal_choice: GoalChoice

class WSRWorld(World):
    """
    Witchspring R is an RPG split into chapters where you are a witch, Pieberry, exploring the world after being hidden away in your corner of the forest away from the Witch Hunt of the human world
    """

    game = "Witchspring R"

    settings: typing.ClassVar[WSRSettings]
    origin_region_name = regions.WSRRegionName.HOME.value
    options_dataclass = GoalChoice
    options_dataclass = WSROptions
    item_name_to_id = items.item_name_to_id
    location_name_to_id = locations.location_name_to_id

    # Universal Tracker support: lets UT track this game without the player's yaml.
    # UT generates with default options, then interpret_slot_data hands it the real
    # slot data and triggers a regeneration where generate_early applies the real goal.
    ut_can_gen_without_yaml = True

    def fill_slot_data(self) -> dict[str, Any]:
        return{
            "goal_choice": int(self.options.goal_choice.value),
        }

    @staticmethod
    def interpret_slot_data(slot_data: dict[str, Any]) -> dict[str, Any]:
        return slot_data

    def generate_early(self) -> None:
        re_gen_passthrough = getattr(self.multiworld, "re_gen_passthrough", {})
        if re_gen_passthrough and self.game in re_gen_passthrough:
            slot_data = re_gen_passthrough[self.game]
            if "goal_choice" in slot_data:
                self.options.goal_choice.value = int(slot_data["goal_choice"])

    def create_regions(self) -> None:
        goal_chapter = int(self.options.goal_choice.value)
        #Create all regions
        for region_name in regions.WSRRegionName:
            required_chapter = regions.region_required_chapter.get(region_name, 9)
            if required_chapter >= goal_chapter:
                continue

            region = Region(region_name.value, self.player, self.multiworld)
            self.multiworld.regions.append(region)
        
        #Add locations to regions
        for location_name, location_data in locations.location_table.items():
            if not self.should_include_location(location_name, location_data):
                continue

            region = self.multiworld.get_region(location_data.region.value, self.player)
            location = locations.WSRLocation(
                self.player,
                location_name,
                location_data.code,
                region,
            )
            if getattr(location_data, "excluded", False):
                location.progress_type = LocationProgressType.EXCLUDED
            region.locations.append(location)
        
        for chapter in range(2, goal_chapter + 1):
            if chapter == 8:
                continue  # Chapter 8 doesn't exist in WitchSpring R (7 -> 9)
            self.multiworld.get_location(f"Reached Chapter {chapter}", self.player).place_locked_item(self.create_item(f"Chapter {chapter}"))
        #self.multiworld.get_location("Reached Chapter 2", self.player).place_locked_item(self.create_item("Chapter 2"))
        #self.multiworld.get_location("Reached Chapter 3", self.player).place_locked_item(self.create_item("Chapter 3"))
        #self.multiworld.get_location("Reached Chapter 4", self.player).place_locked_item(self.create_item("Chapter 4"))
        #self.multiworld.get_location("Reached Chapter 5", self.player).place_locked_item(self.create_item("Chapter 5"))
        #self.multiworld.get_location("Reached Chapter 6", self.player).place_locked_item(self.create_item("Chapter 6"))
        #self.multiworld.get_location("Reached Chapter 7", self.player).place_locked_item(self.create_item("Chapter 7"))
        #self.multiworld.get_location("Reached Chapter 8", self.player).place_locked_item(self.create_item("Chapter 8"))
        #self.multiworld.get_location("Reached Chapter 9", self.player).place_locked_item(self.create_item("Chapter 9"))
        
        #Connect regions
        for start_region, end_regions in regions.region_connections.items():
            if regions.region_required_chapter.get(start_region, 9) >= goal_chapter:
                continue

            start = self.multiworld.get_region(start_region.value, self.player)

            for end_region in end_regions:
                if regions.region_required_chapter.get(end_region, 9) >= goal_chapter:
                    continue

                end = self.multiworld.get_region(end_region.value, self.player)

                entrance = Entrance(
                    self.player,
                    f"{start_region.value} to {end_region.value}",
                    start,
                )
                start.exits.append(entrance)
                entrance.connect(end)

    def set_rules(self) -> None:
        rules.set_all_rules(self)

    def should_include_location(self, location_name: str, location_data) -> bool:
        goal_chapter = int(self.options.goal_choice.value)

        if location_name.startswith("Reached Chapter "):
            chapter = int(location_name.replace("Reached Chapter ", ""))
            return chapter <= goal_chapter
        
        required_chapter = regions.region_required_chapter.get(location_data.region, 9)
        min_chapter = getattr(location_data, "min_chapter", None)
        if min_chapter is not None:
            required_chapter = max(required_chapter, min_chapter)
        return required_chapter < goal_chapter

    def should_include_item(self, item_name: str) -> bool:
        goal_chapter = int(self.options.goal_choice.value)
        required_chapter = items.item_required_chapter.get(item_name)

        if required_chapter is None:
            return True
        return required_chapter < goal_chapter

    def create_item(self, name: str):
        data = items.item_table[name]
        return items.WSRItem(name, data.classification, data.code, self.player)
    
    def create_items(self) -> None:
        for item_name, data in items.item_table.items():
            if not self.should_include_item(item_name):
                continue
            for _ in range(data.pool_count):
                self.multiworld.itempool.append(self.create_item(item_name))