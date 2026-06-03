from typing import TYPE_CHECKING
#from rule_builder.rules import Has, HasAll, HasAny, Rule
from BaseClasses import CollectionState
import dataclasses

from worlds.generic.Rules import set_rule
from .items import item_table
from .locations import location_table

if TYPE_CHECKING:
    from .world import WSRWorld

#HAS_FIRE_SPELLBOOK = Has("Fire Magic Spellbook")
#HAS_LIGHTNING_SPELLBOOK = Has("Lightning Magic Spellbook")
#HAS_ICE_SPELLBOOK = Has("Ice Magic Spellbook")
#HAS_MIND_CONTROL = Has("Mind Control Circle")
#HAS_THUNDER_SLAB = Has("3-Fork Lightning Circle")
#HAS_INSIGNIA = Has("Commander's Insignia")

def has(world, item_name: str):
    return lambda state: state.has(item_name, world.player)

def safe_set_location_rule(world, location_name: str, rule):
    try:
        set_rule(world.get_location(location_name), rule)
    except KeyError:
        pass

def safe_set_entrance_rule(world, entrance_name: str, rule):
    try:
        set_rule(world.get_entrance(entrance_name), rule)
    except KeyError:
        pass

def set_all_rules(world) -> None:
    set_location_rules(world)
    set_completion_condition(world)

def set_location_rules(world) -> None:

    safe_set_location_rule(world, "Arua Blessing", has(world, "Lightning Magic Spellbook"))
    safe_set_location_rule(world, "Reached Chapter 2", has(world, "Fire Magic Spellbook"))
    safe_set_location_rule(world, "Ralph - Boar Captains Tooth Reward", has(world, "Boar Captain's Tooth"))
    safe_set_location_rule(world, "Anna's House - Chaos Stone Earrings", has(world, "Chaos Stone"))
    safe_set_location_rule(world, "Anna's House - Lalaque Mine Key", has(world, "Chaos Stone"))
    safe_set_location_rule(world, "Reached Chapter 3", lambda state: state.has("Chapter 2", world.player) and state.has("Lalaque Mine Key", world.player))
    safe_set_location_rule(world, "Reached Chapter 4", has(world, "Chapter 3"))
    safe_set_location_rule(world, "Reached Chapter 5", has(world, "Chapter 4"))
    safe_set_location_rule(world, "Reached Chapter 6", has(world, "Chapter 5"))
    safe_set_location_rule(world, "Reached Chapter 7", has(world, "Chapter 6"))
    safe_set_location_rule(world, "Reached Chapter 8", has(world, "Chapter 7"))
    safe_set_location_rule(world, "Reached Chapter 9", has(world, "Chapter 8"))
    #set_rule(
        #world.get_location("event_78 - Fire Spellbook"),
        #HAS_MIND_CONTROL
        #has(world, "Mind Control Circle")
    #)
    safe_set_entrance_rule(world, "South Island to Shipwreck", has(world, "Chapter 3"))
    safe_set_entrance_rule(world, "Black Witch Forest to North Merchant Road", has(world, "Chapter 2"))
    safe_set_entrance_rule(world, "North Merchant Road to Lalaque Forest", has(world, "Boar Captain's Tooth"))


def set_completion_condition(world) -> None:
    goal_choice = int(world.options.goal_choice.value)
    #world.set_completion_rule(HAS_ICE_SPELLBOOK)
    world.multiworld.completion_condition[world.player] = has(world, f"Chapter {goal_choice}")
    #world.multiworld.completion_rule(has(world, "Ice Magic Spellbook"))