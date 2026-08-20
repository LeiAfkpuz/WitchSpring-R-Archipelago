import typing
from collections.abc import Mapping
from typing import Any
from .options import GoalChoice, Battlesanity, Bestiary, QuestSanity
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
    battlesanity: Battlesanity
    bestiary: Bestiary
    questsanity: QuestSanity

# Per-location overrides applied on top of the normal chapter/min_chapter inclusion, keyed
# by location name. Kept here (not in the generated tables) so it survives regeneration and
# doesn't touch the datapackage/codes (removal of a check is deferred to 0.4.0).
#   min_chapter: force a higher inclusion floor. required_chapter < goal_chapter is the rule,
#                and goals are {2,3,4,5,6,7,9} (no 8), so min_chapter=8 means "goal-9 only"
#                (8 < any real goal 2-7 is False; 8 < 9 is True). This is an INCLUSION gate
#                only - it does NOT add a "Chapter 8" item to the reachability rule (that
#                item doesn't exist), so where it IS included it stays reachable normally.
#   excluded:    never place progression here (so a phantom check can't strand the seed).
#
# "Bestiary - Leaf Golem": the LeafGolem enemy is unused/placeholder content - its name is an
# untranslated transliteration (리프골렘, vs the game's real word for leaf, 나뭇잎, used by
# Leaf Pudding), it has no Rank/JobGroup, and it never appears in the in-game Bestiary even on
# a fully-catalogued Epilogue save, so the check can't be earned. Gated to the (not-yet-
# recommended) Chapter 9 goal only, and excluded there so even goal-9 players can't strand
# progression on it. Goal <=7 players never see it.
#
# "Bestiary - Ancient Garden Wampleaf" (WampleafWaterWay, 500 EXP): an Epilogue (post-game)
# fight, reachable only AFTER the Chapter 9 goal. Same treatment - goal-9 only so most players
# never get it, and excluded so a goal-9 player who stops at the goal (before the epilogue)
# isn't blocked, while epilogue completionists can still earn the check.
LOCATION_OVERRIDES = {
    "Bestiary - Leaf Golem": {"min_chapter": 8, "excluded": True},
    "Bestiary - Ancient Garden Wampleaf": {"min_chapter": 8, "excluded": True},
}

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
            "battlesanity": int(self.options.battlesanity.value),
            "bestiary": int(self.options.bestiary.value),
            "questsanity": int(self.options.questsanity.value),
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
            if "battlesanity" in slot_data:
                self.options.battlesanity.value = int(slot_data["battlesanity"])
            if "bestiary" in slot_data:
                self.options.bestiary.value = int(slot_data["bestiary"])
            if "questsanity" in slot_data:
                self.options.questsanity.value = int(slot_data["questsanity"])

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
            if getattr(location_data, "excluded", False) or LOCATION_OVERRIDES.get(location_name, {}).get("excluded"):
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

        # Optional check categories are only present when their toggle is enabled.
        if location_data.group == locations.LocationGroup.BATTLE and not self.options.battlesanity.value:
            return False
        if location_data.group == locations.LocationGroup.BESTIARY and not self.options.bestiary.value:
            return False
        if location_data.group == locations.LocationGroup.QUEST and not self.options.questsanity.value:
            return False

        required_chapter = regions.region_required_chapter.get(location_data.region, 9)
        min_chapter = getattr(location_data, "min_chapter", None)
        if min_chapter is not None:
            required_chapter = max(required_chapter, min_chapter)
        override_min = LOCATION_OVERRIDES.get(location_name, {}).get("min_chapter")
        if override_min is not None:
            required_chapter = max(required_chapter, override_min)
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
    
    def get_filler_item_name(self) -> str:
        return self.random.choice(items.filler_item_names)

    def create_items(self) -> None:
        item_pool = []
        for item_name, data in items.item_table.items():
            if not self.should_include_item(item_name):
                continue
            for _ in range(data.pool_count):
                item_pool.append(self.create_item(item_name))

        # Optional check categories (battlesanity/bestiary) can add many more locations
        # than the base pool covers. Pad with filler so every location is fillable; AP
        # discards any leftover excess on the oversupplied side.
        unfilled = sum(
            1 for loc in self.multiworld.get_locations(self.player)
            if loc.address is not None and loc.item is None
        )
        while len(item_pool) < unfilled:
            item_pool.append(self.create_item(self.get_filler_item_name()))

        self.multiworld.itempool += item_pool