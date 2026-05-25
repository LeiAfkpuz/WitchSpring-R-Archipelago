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
    BLACKHILL_GOLEM_CAVE = "Blackhill Golem Cave"
    SWAMP = "Swamp"
    SNOW_FIELD = "Snow Field"
    DEATH_SQUAD = "Death Squad"
    LAOBA_MOUNTAIN = "Laoba Mountain"
    LIONS_PLAIN = "Lions Plain"
    LALAQUE_FOREST = "Lalaque Forest"
    LALAQUE_MINE = "Lalaque Mine"
    NORTH_MERCHANT_ROAD = "North Merchant Road"
    VAVELIA_ROAD = "Vavelia Road"
    BLACKHILL_GOLEM_CAVE_FOX = "Blackhill Golem Cave Fox"
    BLACKHILL_GOLEM_CAVE_FIRE = "Blackhill Golvem Cave Volcano Road"
    BLACKHILL_GOLEM_CAVE_FIRE_2 = "Blackhill Golvem Cave Volcano Road"
    BLACKHILL_GOLEM_CAVE_FIRE_3 = "Blackhill Golvem Cave Volcano Road"
    PUDDING_CAVE_3 = "Pudding Cave - Royal Pudding"
    BOAR_PLAIN = "Boar Plain"


starting_region = WSRRegionName.HOME

region_connections = {
    WSRRegionName.HOME: [
        WSRRegionName.BLACK_WITCH_FOREST,
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
    ],
    WSRRegionName.LALAQUE_VILLAGE: [
        WSRRegionName.LALAQUE_FOREST,
    ],
    WSRRegionName.LALAQUE_MINE: [
        WSRRegionName.LALAQUE_MINE,
    ],
    WSRRegionName.BOAR_PLAIN: [
        WSRRegionName.NORTH_MERCHANT_ROAD,
        WSRRegionName.LAOBA_MOUNTAIN,
    ],
}

region_required_chapter = {
    WSRRegionName.HOME: 1,
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

    WSRRegionName.LAOBA_MOUNTAIN: 3,
    WSRRegionName.SHIPWRECK: 3,
    WSRRegionName.AIMHARD_TEMPLE: 3,

    WSRRegionName.ELYSION_TEMPLE: 4,
    WSRRegionName.ELYSION_PLAIN: 4,
    WSRRegionName.DARKSTONE_CAVE: 4,
    WSRRegionName.BLACKHILL_GOLEM_CAVE_FIRE_2: 4,
    WSRRegionName.BLACKHILL_GOLEM_CAVE_FIRE_3: 4,

    WSRRegionName.DEATH_SQUAD: 5,

    WSRRegionName.SNOW_FIELD: 6,
    WSRRegionName.DUROK_TEMPLE: 6,
}