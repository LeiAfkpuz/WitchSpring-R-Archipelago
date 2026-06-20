from enum import Enum

class WSRRegionName(str, Enum):
    VAVELIA_VILLAGE = "Vavelia Village"
    LALAQUE_VILLAGE = "Lalaque Village"
    ARUA_TEMPLE = "Arua Temple"
    BLACK_WITCH_FOREST = "Black Witch Forest"
    PUDDING_CAVE = "Pudding Cave"
    PUDDING_CAVE_2 = "Pudding Cave 2"
    HOME = "Home"
    SHIPWRECK = "Shipwreck"
    SOUTH_ISLAND = "South Island"
    ELYSION_PLAIN = "Elysion Plain"
    DARKSTONE_CAVE = "Darkstone Cave"
    DUROK_TEMPLE = "Durok Temple"
    AIMHARD_TEMPLE = "Aimhard Temple"
    ELYSION_TEMPLE = "Elysion Temple"
    BLACKHILL_GOLEM_CAVE = "Backhill Golem Cave"
    SWAMP = "Swamp"
    SNOW_FIELD = "Snow Field"
    DEATH_SQUAD = "Death Squad"
    LAOBA_MOUNTAIN = "Laoba Mountain"
    LIONS_PLAIN = "Lions Plain"
    LALAQUE_FOREST = "Lalaque Forest"
    LALAQUE_MINE = "Lalaque Mine"
    NORTH_MERCHANT_ROAD = "North Merchant Road"
    VAVELIA_ROAD = "Vavelia Road"
    BLACKHILL_GOLEM_CAVE_FOX = "Backhill Golem Cave Fox"
    BLACKHILL_GOLEM_CAVE_FIRE = "Backhill Golem Cave Volcano Road"
    BLACKHILL_GOLEM_CAVE_FIRE_2 = "Backhill Golem Cave Volcano Road 2"
    BLACKHILL_GOLEM_CAVE_FIRE_3 = "Backhill Golem Cave Volcano Road 3"
    PUDDING_CAVE_3 = "Pudding Cave - Royal Pudding"
    BOAR_PLAIN = "Boar Plain"
    REDBEARD_CAVE = "RedBeard's Cave"
    KANNA_HOUSE = "Kanna's House"
    LUNA_HOUSE = "Luna's House"
    ICE_CAVE = "Ice Cave"
    FROZEN_ALTAR = "Frozen Altar"
    # Virtual region holding Bestiary (defeat-each-enemy) checks. Always reachable from
    # Home; individual checks are gated by each enemy's min_chapter + a Chapter rule.
    BESTIARY = "Bestiary"
    # Virtual region holding QuestSanity (quest-complete) checks. Same pattern as Bestiary.
    QUESTS = "Quests"


starting_region = WSRRegionName.HOME

region_connections = {
    WSRRegionName.HOME: [
        WSRRegionName.BLACK_WITCH_FOREST,
        WSRRegionName.BESTIARY,
        WSRRegionName.QUESTS,
    ],
    WSRRegionName.BLACK_WITCH_FOREST: [
        WSRRegionName.PUDDING_CAVE,
        WSRRegionName.SWAMP,
        WSRRegionName.NORTH_MERCHANT_ROAD,
        WSRRegionName.BLACKHILL_GOLEM_CAVE,
        WSRRegionName.SOUTH_ISLAND,
        WSRRegionName.HOME
    ],
    WSRRegionName.SOUTH_ISLAND: [
        WSRRegionName.SHIPWRECK,
        WSRRegionName.ARUA_TEMPLE,
    ],
    WSRRegionName.SWAMP: [
        WSRRegionName.BLACK_WITCH_FOREST,
    ],
    WSRRegionName.BLACKHILL_GOLEM_CAVE: [
        WSRRegionName.BLACK_WITCH_FOREST,
        WSRRegionName.BLACKHILL_GOLEM_CAVE_FOX,
        WSRRegionName.BLACKHILL_GOLEM_CAVE_FIRE,
        WSRRegionName.ELYSION_PLAIN,
    ],
    WSRRegionName.BLACKHILL_GOLEM_CAVE_FOX: [
        WSRRegionName.BLACKHILL_GOLEM_CAVE,
    ],
    WSRRegionName.BLACKHILL_GOLEM_CAVE_FIRE: [
        WSRRegionName.BLACKHILL_GOLEM_CAVE,
        WSRRegionName.BLACKHILL_GOLEM_CAVE_FIRE_2,
    ],
    WSRRegionName.BLACKHILL_GOLEM_CAVE_FIRE_2: [
        WSRRegionName.BLACKHILL_GOLEM_CAVE_FIRE,
        WSRRegionName.BLACKHILL_GOLEM_CAVE_FIRE_3,
    ],
    WSRRegionName.BLACKHILL_GOLEM_CAVE_FIRE_3: [
        WSRRegionName.BLACKHILL_GOLEM_CAVE_FIRE_2,
    ],
    WSRRegionName.PUDDING_CAVE: [
        WSRRegionName.BLACK_WITCH_FOREST,
        WSRRegionName.PUDDING_CAVE_2,
    ],
    WSRRegionName.PUDDING_CAVE_2: [
        WSRRegionName.PUDDING_CAVE,
        WSRRegionName.PUDDING_CAVE_3,
    ],
    WSRRegionName.PUDDING_CAVE_3: [
        WSRRegionName.PUDDING_CAVE_2,
    ],
    WSRRegionName.NORTH_MERCHANT_ROAD: [
        WSRRegionName.LALAQUE_FOREST,
        WSRRegionName.BOAR_PLAIN,
        WSRRegionName.BLACK_WITCH_FOREST,
    ],
    WSRRegionName.LALAQUE_FOREST: [
        WSRRegionName.LALAQUE_MINE,
        WSRRegionName.LALAQUE_VILLAGE,
        WSRRegionName.NORTH_MERCHANT_ROAD,
        WSRRegionName.LIONS_PLAIN,
        WSRRegionName.KANNA_HOUSE,
    ],
    WSRRegionName.LALAQUE_VILLAGE: [
        WSRRegionName.LALAQUE_FOREST,
    ],
    WSRRegionName.LALAQUE_MINE: [
        WSRRegionName.LALAQUE_FOREST,
    ],
    WSRRegionName.LIONS_PLAIN: [
        WSRRegionName.LALAQUE_FOREST,
        WSRRegionName.AIMHARD_TEMPLE,
    ],
    WSRRegionName.AIMHARD_TEMPLE: [
        WSRRegionName.LIONS_PLAIN,
    ],
    WSRRegionName.BOAR_PLAIN: [
        WSRRegionName.NORTH_MERCHANT_ROAD,
        WSRRegionName.LAOBA_MOUNTAIN,
        WSRRegionName.DEATH_SQUAD,
        WSRRegionName.SNOW_FIELD,
    ],
    WSRRegionName.LAOBA_MOUNTAIN: [
        WSRRegionName.BOAR_PLAIN,
        WSRRegionName.VAVELIA_ROAD,
    ],
    WSRRegionName.VAVELIA_ROAD: [
        WSRRegionName.LAOBA_MOUNTAIN,
        WSRRegionName.VAVELIA_VILLAGE,
    ],
    WSRRegionName.VAVELIA_VILLAGE: [
        WSRRegionName.VAVELIA_ROAD,
        WSRRegionName.REDBEARD_CAVE,
    ],
    WSRRegionName.ELYSION_PLAIN: [
        WSRRegionName.BLACKHILL_GOLEM_CAVE,
        WSRRegionName.DARKSTONE_CAVE,
    ],
    WSRRegionName.DARKSTONE_CAVE: [
        WSRRegionName.ELYSION_PLAIN,
        WSRRegionName.ELYSION_TEMPLE,
    ],
    WSRRegionName.ELYSION_TEMPLE: [
        WSRRegionName.DARKSTONE_CAVE,
    ],
    WSRRegionName.DEATH_SQUAD: [
        WSRRegionName.BOAR_PLAIN,
    ],
    WSRRegionName.SNOW_FIELD: [
        WSRRegionName.BOAR_PLAIN,
        WSRRegionName.DUROK_TEMPLE,
        WSRRegionName.ICE_CAVE,
        WSRRegionName.LUNA_HOUSE,
    ],
    WSRRegionName.DUROK_TEMPLE: [
        WSRRegionName.SNOW_FIELD,
    ],
    WSRRegionName.REDBEARD_CAVE: [
        WSRRegionName.VAVELIA_VILLAGE,
    ],
    WSRRegionName.KANNA_HOUSE: [
        WSRRegionName.LALAQUE_FOREST,
    ],
    WSRRegionName.LUNA_HOUSE: [
        WSRRegionName.SNOW_FIELD,
    ],
    WSRRegionName.ICE_CAVE: [
        WSRRegionName.SNOW_FIELD,
        WSRRegionName.FROZEN_ALTAR,
    ],
    WSRRegionName.FROZEN_ALTAR: [
        WSRRegionName.ICE_CAVE,
    ],
}

region_required_chapter = {
    WSRRegionName.HOME: 1,
    WSRRegionName.BESTIARY: 1,
    WSRRegionName.QUESTS: 1,
    WSRRegionName.BLACK_WITCH_FOREST: 1,
    WSRRegionName.PUDDING_CAVE: 1,
    WSRRegionName.SWAMP: 1,
    WSRRegionName.BLACKHILL_GOLEM_CAVE: 1,
    WSRRegionName.BLACKHILL_GOLEM_CAVE_FOX: 1,
    WSRRegionName.ARUA_TEMPLE: 1,
    WSRRegionName.PUDDING_CAVE_2: 1,
    WSRRegionName.SOUTH_ISLAND: 1,
    WSRRegionName.BLACKHILL_GOLEM_CAVE_FIRE: 1,


    WSRRegionName.NORTH_MERCHANT_ROAD: 2,
    WSRRegionName.LALAQUE_FOREST: 2,
    WSRRegionName.LALAQUE_MINE: 2,
    WSRRegionName.LALAQUE_VILLAGE: 2,
    WSRRegionName.BOAR_PLAIN: 2,

    WSRRegionName.LAOBA_MOUNTAIN: 2,
    WSRRegionName.SHIPWRECK: 3,
    WSRRegionName.AIMHARD_TEMPLE: 3,
    WSRRegionName.LIONS_PLAIN: 3,

    WSRRegionName.ELYSION_TEMPLE: 4,
    WSRRegionName.ELYSION_PLAIN: 4,
    WSRRegionName.DARKSTONE_CAVE: 4,
    WSRRegionName.BLACKHILL_GOLEM_CAVE_FIRE_2: 4,
    WSRRegionName.BLACKHILL_GOLEM_CAVE_FIRE_3: 4,
    WSRRegionName.PUDDING_CAVE_3: 4,

    WSRRegionName.DEATH_SQUAD: 5,
    WSRRegionName.VAVELIA_ROAD: 5,
    WSRRegionName.VAVELIA_VILLAGE: 5,
    WSRRegionName.KANNA_HOUSE: 2,      # off Lalaque Forest; holds ch2 (Chaos Stone) + ch5 (Red Gem) checks
    WSRRegionName.REDBEARD_CAVE: 5,    # off Vavelia Village, gated by Secret Trader Key

    WSRRegionName.SNOW_FIELD: 6,
    WSRRegionName.DUROK_TEMPLE: 6,
    WSRRegionName.ICE_CAVE: 6,
    WSRRegionName.FROZEN_ALTAR: 6,

    WSRRegionName.LUNA_HOUSE: 7,       # Blue Moonstone Staff is ch7 content
}