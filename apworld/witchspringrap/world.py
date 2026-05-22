from collections.abc import Mapping
from typing import Any
from .options import GoalChoice
from dataclasses import dataclass
from Options import PerGameCommonOptions

from BaseClasses import Region, Entrance, Tutorial
from . import items, locations, regions, rules

from worlds.AutoWorld import World, WebWorld

#from . import options as wsr_options

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

    origin_region_name = regions.WSRRegionName.HOME.value
    options_dataclass = GoalChoice
    options_dataclass = WSROptions
    item_name_to_id = items.item_name_to_id
    location_name_to_id = locations.location_name_to_id

    def fill_slot_data(self) -> dict[str, Any]:
        return{
            "goal_choice": int(self.options.goal_choice.value),
        }

    def create_regions(self) -> None:
        #Create all regions
        for region_name in regions.WSRRegionName:
            region = Region(region_name.value, self.player, self.multiworld)
            self.multiworld.regions.append(region)
        
        #Add locations to regions
        for location_name, location_data in locations.location_table.items():
            region = self.multiworld.get_region(location_data.region.value, self.player)
            location = locations.WSRLocation(
                self.player,
                location_name,
                location_data.code,
                region,
            )
            region.locations.append(location)
        
        self.multiworld.get_location("Reached Chapter 2", self.player).place_locked_item(self.create_item("Chapter 2"))
        self.multiworld.get_location("Reached Chapter 3", self.player).place_locked_item(self.create_item("Chapter 3"))
        self.multiworld.get_location("Reached Chapter 4", self.player).place_locked_item(self.create_item("Chapter 4"))
        self.multiworld.get_location("Reached Chapter 5", self.player).place_locked_item(self.create_item("Chapter 5"))
        self.multiworld.get_location("Reached Chapter 6", self.player).place_locked_item(self.create_item("Chapter 6"))
        self.multiworld.get_location("Reached Chapter 7", self.player).place_locked_item(self.create_item("Chapter 7"))
        self.multiworld.get_location("Reached Chapter 8", self.player).place_locked_item(self.create_item("Chapter 8"))
        self.multiworld.get_location("Reached Chapter 9", self.player).place_locked_item(self.create_item("Chapter 9"))
        
        #Connect regions
        for start_region, end_regions in regions.region_connections.items():
            start = self.multiworld.get_region(start_region.value, self.player)

            for end_region in end_regions:
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

    def create_item(self, name: str):
        data = items.item_table[name]
        return items.WSRItem(name, data.classification, data.code, self.player)
    
    def create_items(self) -> None:
        for item_name, data in items.item_table.items():
            for _ in range(data.pool_count):
                self.multiworld.itempool.append(self.create_item(item_name))