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

    # "Arua Blessing" is the Ch1 Arua's Arrow (Bless_Arua, event_84) - granted at a Black
    # Witch Forest battle after the Arua Temple sequence. The Lightning Magic Spellbook is
    # granted in Arua Temple before that fight, so gating on it keeps the order correct.
    safe_set_location_rule(world, "Arua Blessing", has(world, "Lightning Magic Spellbook"))
    # Finishing Chapter 1 requires crossing the Swamp/South Island, which needs the Mind
    # Control Circle - so reaching Chapter 2 depends on MCC, not just the Fire Spellbook.
    # Without this, the fill can stash MCC in a Chapter 2+ location (it landed in Lalaque
    # Mine once), which is unreachable until after the point you actually need it.
    safe_set_location_rule(world, "Reached Chapter 2", lambda state: state.has("Fire Magic Spellbook", world.player) and state.has("Mind Control Circle", world.player))
    safe_set_location_rule(world, "Ralph - Boar Captain's Tooth Reward", has(world, "Boar Captain's Tooth"))
    safe_set_location_rule(world, "Anna's House - Chaos Stone Earrings", has(world, "Chaos Stone"))
    safe_set_location_rule(world, "Anna's House - Lalaque Mine Key", has(world, "Chaos Stone"))
    # Reaching Chapter 3 means completing the Lalaque Mine, which is only reachable through
    # Lalaque Forest (needs Boar Captain's Tooth). Without the Tooth requirement the fill can
    # mark Chapter 3 reachable as soon as it hands you the Mine Key - before you can enter the
    # Lalaque area at all (which is why the tracker showed Reached Chapter 3 but no mine checks).
    safe_set_location_rule(world, "Reached Chapter 3", lambda state: state.has("Chapter 2", world.player) and state.has("Boar Captain's Tooth", world.player) and state.has("Lalaque Mine Key", world.player))
    # Chapter 3 main story (in order): Shipwreck then Aimhard. The Rusty Commander's Cabin
    # Key opens the Shipwreck boss; beating it continues the story to Aimhard / Chapter 4.
    # (Cannonball is NOT in this chain - it only opens the Armory loot.)
    safe_set_location_rule(world, "Reached Chapter 4", lambda state: state.has("Chapter 3", world.player) and state.has("Rusty Commander's Cabin Key", world.player))
    safe_set_location_rule(world, "Reached Chapter 5", has(world, "Chapter 4"))
    # Reaching Chapter 6 requires the Prototype Steam Engine (story-critical to trigger the
    # transition), so the fill can't stash it in a Chapter 6+ location.
    safe_set_location_rule(world, "Reached Chapter 6", lambda state: state.has("Chapter 5", world.player) and state.has("Prototype Steam Engine", world.player))
    safe_set_location_rule(world, "Reached Chapter 7", has(world, "Chapter 6"))
    # Chapter 8 doesn't exist in-game (7 -> 9), so Chapter 9 follows directly from 7.
    safe_set_location_rule(world, "Reached Chapter 9", has(world, "Chapter 7"))
    # Shipwreck interior chests are locked behind their keys.
    safe_set_location_rule(world, "Shipwreck - Brig - Chest 1", has(world, "Shipwreck Brig Key"))
    safe_set_location_rule(world, "Shipwreck - Brig - Chest 2", has(world, "Shipwreck Brig Key"))
    safe_set_location_rule(world, "Shipwreck - Armory - Chest 1", has(world, "Shipwreck Hold Key"))
    safe_set_location_rule(world, "Shipwreck - Armory - Chest 2", has(world, "Shipwreck Hold Key"))
    safe_set_location_rule(world, "Shipwreck - Armory - Chest 3", has(world, "Shipwreck Hold Key"))
    safe_set_location_rule(world, "Shipwreck - Armory - Chest 4", has(world, "Shipwreck Hold Key"))
    # The Cabin Key drops from the Armory enemy fight, so it also sits behind the Hold Key.
    safe_set_location_rule(world, "Shipwreck - Armory - Commander's Cabin Key", has(world, "Shipwreck Hold Key"))
    # The Red Gem cutscene happens at Kanna's House (reachable from Ch2 Lalaque Forest) but
    # only fires in Chapter 5, so gate the check on Chapter 5 even though the region is earlier.
    safe_set_location_rule(world, "Kanna's House - Red Gem", has(world, "Chapter 5"))
    # The Fire Spellbook is handed over only after the Mind-Control swamp sequence in-game,
    # so this location can't be checked until the player has the Mind Control Circle.
    safe_set_location_rule(world, "event_78 - Fire Spellbook", has(world, "Mind Control Circle"))
    # Boar_Junior (the Mind Control Circle, gated in-game on event_13) is required to
    # reach the Swamp, and to ride through it to BlackJoe and on to South Island.
    safe_set_entrance_rule(world, "Black Witch Forest to Swamp", has(world, "Mind Control Circle"))
    # South Island is reached by riding through the swamp past Black Joe, who hands over the
    # Fire Magic Spellbook - so you must already have it (plus MCC) to get there. Without
    # this, the fill could place the Fire Spellbook behind South Island and softlock.
    safe_set_entrance_rule(world, "Black Witch Forest to South Island", lambda state: state.has("Mind Control Circle", world.player) and state.has("Fire Magic Spellbook", world.player))
    safe_set_entrance_rule(world, "South Island to Shipwreck", has(world, "Chapter 3"))
    # South Island - Chest 1 is on a swim-only islet, reached with Eison (the swimming mount,
    # awakened by the Aged Lalaque Berry in Chapter 2). Gate on Chapter 2 + the berry as the
    # swim-pet proxy until pets are in logic. (Big Crab Island chest is reachable on foot.)
    safe_set_location_rule(world, "South Island - Chest 1", lambda state: state.has("Chapter 2", world.player) and state.has("Aged Lalaque Berry", world.player))
    # Lions Plain -> Aimhard Temple is the Chapter 3 branch off Lalaque Forest.
    safe_set_entrance_rule(world, "Lalaque Forest to Lions Plain", has(world, "Chapter 3"))
    # The Shipwreck boss (opened by the Cabin Key) must be beaten to reach Aimhard.
    safe_set_entrance_rule(world, "Lions Plain to Aimhard Temple", has(world, "Rusty Commander's Cabin Key"))
    # Pudding Cave - Royal Pudding is Chapter 4 content off Pudding Cave 2.
    safe_set_entrance_rule(world, "Pudding Cave 2 to Pudding Cave - Royal Pudding", has(world, "Chapter 4"))
    # Elysion Plain -> Darkstone Cave -> Elysion Temple is the Chapter 4 branch off Blackhill Golem Cave.
    safe_set_entrance_rule(world, "Blackhill Golem Cave to Elysion Plain", has(world, "Chapter 4"))
    # Vavelia Road/Village are Chapter 5 content off Laoba Mountain.
    safe_set_entrance_rule(world, "Laoba Mountain to Vavelia Road", has(world, "Chapter 5"))
    # Death Squad (Boar Mountain lair) is Chapter 5 content off Boar Plain.
    safe_set_entrance_rule(world, "Boar Plain to Death Squad", has(world, "Chapter 5"))
    # RedBeard's Cave (off Vavelia Village) is gated by the Secret Trader Key.
    safe_set_entrance_rule(world, "Vavelia Village to RedBeard's Cave", has(world, "Secret Trader Key"))
    # Snow Field -> Durok Temple is Chapter 6 content off Boar Plain.
    # The Ice Witch Scarf is required to enter Snow Field at all.
    safe_set_entrance_rule(world, "Boar Plain to Snow Field", lambda state: state.has("Chapter 6", world.player) and state.has("Ice Witch Scarf", world.player))
    # The Ice Magic Spellbook is needed to get through the Ice Cave, and the same Ice magic
    # gates Durok Temple. (Durok currently hangs off Snow Field, so we require it on both
    # entrances directly; if Durok is ever re-routed through the Ice Cave the Ice Cave gate
    # alone would cover it.)
    safe_set_entrance_rule(world, "Snow Field to Ice Cave", has(world, "Ice Magic Spellbook"))
    safe_set_entrance_rule(world, "Snow Field to Durok Temple", has(world, "Ice Magic Spellbook"))
    # The Laoba Mountain Warrior Camp opens up once you've beaten the Boar Captain (i.e. have
    # the Boar Captain's Tooth), so gate it on the Tooth rather than Chapter 3 - it's reachable
    # in Chapter 2 in practice. (Deeper Laoba->Vavelia content stays gated at Chapter 5 below.)
    safe_set_entrance_rule(world, "Boar Plain to Laoba Mountain", has(world, "Boar Captain's Tooth"))
    # The Fire Cave / Volcano Road branch can't be entered until the Mind Control Circle quest
    # is done (UT-confirmed); this also covers the deeper Volcano Road 2/3 beyond it.
    safe_set_entrance_rule(world, "Blackhill Golem Cave to Blackhill Golem Cave Volcano Road", has(world, "Mind Control Circle"))
    # Entrance Chest 1 specifically is blocked behind Mind Control (its sibling chests aren't).
    safe_set_location_rule(world, "Blackhill Golem Cave - Entrance - Chest 1", has(world, "Mind Control Circle"))
    # Volcano Road 2/3 technically enterable in Ch3 but underleveled - gate the deeper stretch at Ch4.
    safe_set_entrance_rule(world, "Blackhill Golem Cave Volcano Road to Blackhill Golem Cave Volcano Road 2", has(world, "Chapter 4"))
    safe_set_entrance_rule(world, "Black Witch Forest to North Merchant Road", has(world, "Chapter 2"))
    safe_set_entrance_rule(world, "North Merchant Road to Lalaque Forest", has(world, "Boar Captain's Tooth"))

    # ----- Event-reward check rules generated from the Chapter triage worksheet -----
    # (build_event_checks.py, INCLUDE=Y batch). See Events Full Dump/out/REPORT.txt.
    safe_set_location_rule(world, "Luna – Blue Moonstone Staff", lambda state: state.has('Chapter 7', world.player))
    safe_set_location_rule(world, "Ludina Blade", lambda state: state.has('Chapter 6', world.player) and state.has('Frozen Key', world.player))
    safe_set_location_rule(world, "Melina – Bedo's Headband", lambda state: state.has('Chapter 6', world.player))
    safe_set_location_rule(world, "Luna – Ice Magic Spellbook", lambda state: state.has('Chapter 6', world.player))
    safe_set_location_rule(world, "Balt – Life Stone", lambda state: state.has('Chapter 5', world.player))
    safe_set_location_rule(world, "Royal Pudding Party 1", lambda state: state.has('Chapter 4', world.player) and state.has('Aged Lalaque Berry', world.player))
    safe_set_location_rule(world, "Royal Pudding Party 2", lambda state: state.has('Chapter 4', world.player) and state.has('Aged Lalaque Berry', world.player))
    safe_set_location_rule(world, "Blast – Sun Sword", lambda state: state.has('Chapter 6', world.player))
    safe_set_location_rule(world, "Kanna – Peanut Shark", lambda state: state.has('Chapter 3', world.player) and state.has("Rusty Commander's Cabin Key", world.player))
    safe_set_location_rule(world, "Livya – Commander's Insignia", lambda state: state.has('Chapter 3', world.player))
    safe_set_location_rule(world, "Sarah – Sera's Dress", lambda state: state.has('Chapter 2', world.player))
    safe_set_location_rule(world, "Ralph – Gem Payment", lambda state: state.has('Chapter 2', world.player))
    safe_set_location_rule(world, "Kanna's House – Chaos Stone", lambda state: state.has('Chapter 2', world.player))
    safe_set_location_rule(world, "Ralph - Boar Captain's Tooth Reward 2", lambda state: state.has('Chapter 2', world.player))
    # The Weapon Upgrade Materials handout needs both the Fire Magic Spellbook and the Mind
    # Control Circle in-game (UT-confirmed), so require both.
    safe_set_location_rule(world, "Weapon Upgrade Materials 1", lambda state: state.has('Fire Magic Spellbook', world.player) and state.has('Mind Control Circle', world.player))
    safe_set_location_rule(world, "Weapon Upgrade Materials 2", lambda state: state.has('Fire Magic Spellbook', world.player) and state.has('Mind Control Circle', world.player))
    safe_set_location_rule(world, "Weapon Upgrade Materials 3", lambda state: state.has('Fire Magic Spellbook', world.player) and state.has('Mind Control Circle', world.player))
    safe_set_location_rule(world, "Weapon Upgrade Materials 4", lambda state: state.has('Fire Magic Spellbook', world.player) and state.has('Mind Control Circle', world.player))
    safe_set_location_rule(world, "Weapon Upgrade Materials 5", lambda state: state.has('Fire Magic Spellbook', world.player) and state.has('Mind Control Circle', world.player))

    # Blessing checks (NewBless events).
    safe_set_location_rule(world, "Aimhard's Blessing", lambda state: state.has("Chapter 3", world.player) and state.has("Rusty Commander's Cabin Key", world.player))
    safe_set_location_rule(world, "Elysion Blessing", has(world, "Chapter 4"))


def set_completion_condition(world) -> None:
    goal_choice = int(world.options.goal_choice.value)
    #world.set_completion_rule(HAS_ICE_SPELLBOOK)
    world.multiworld.completion_condition[world.player] = has(world, f"Chapter {goal_choice}")
    #world.multiworld.completion_rule(has(world, "Ice Magic Spellbook"))