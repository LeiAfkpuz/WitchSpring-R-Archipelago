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

def set_all_rules(world) -> None:
    set_location_rules(world)
    set_completion_condition(world)

def set_location_rules(world) -> None:
    set_rule(
        world.get_location("Arua Blessing"),
        #HAS_LIGHTNING_SPELLBOOK
        has(world, "Lightning Magic Spellbook")
    )

    #set_rule(
        #world.get_location("event_78 - Fire Spellbook"),
        #HAS_MIND_CONTROL
        #has(world, "Mind Control Circle")
    #)

    set_rule(
        world.get_entrance("South Island to Shipwreck"),
        #HAS_INSIGNIA
        has(world, "Chapter 3")
    )

    set_rule(
        world.get_entrance("Black Witch Forest to North Merchant Road"),
        #HAS_INSIGNIA
        has(world, "Chapter 2")
    )

    set_rule(
        world.get_entrance("North Merchant Road to Lalaque Forest"),
        has(world, "Boar Captain's Tooth")
    )

    set_rule(
        world.get_location("Reached Chapter 2"),
            has(world, "Fire Magic Spellbook")
    )

    set_rule(
        world.get_location("Reached Chapter 3"),
        lambda state:
            state.has("Chapter 2", world.player)
            and state.has("Lalaque Mine Key", world.player)
    )

    set_rule(
        world.get_location("Reached Chapter 4"),
        has(world, "Chapter 3")
    )

    set_rule(
        world.get_location("Reached Chapter 5"),
        has(world, "Chapter 4")
    )

    set_rule(
        world.get_location("Reached Chapter 6"),
        has(world, "Chapter 5")
    )

    set_rule(
        world.get_location("Reached Chapter 7"),
        has(world, "Chapter 6")
    )

    set_rule(
        world.get_location("Reached Chapter 8"),
        has(world, "Chapter 7")
    )

    set_rule(
        world.get_location("Reached Chapter 9"),
        has(world, "Chapter 8")
    )

def set_completion_condition(world) -> None:
    goal_choice = int(world.options.goal_choice.value)
    #world.set_completion_rule(HAS_ICE_SPELLBOOK)
    world.multiworld.completion_condition[world.player] = has(world, f"Chapter {goal_choice}")
    #world.multiworld.completion_rule(has(world, "Ice Magic Spellbook"))