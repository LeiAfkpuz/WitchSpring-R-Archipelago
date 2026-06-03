from dataclasses import dataclass
from typing import TYPE_CHECKING
from BaseClasses import Item, ItemClassification

if TYPE_CHECKING:
    from .world import WSRWorld

class WSRItem(Item):
    game = "Witchspring R"

@dataclass
class WSRItemData:
    code: int
    classification: ItemClassification
    game_id: str
    quantity: int = 1
    pool_count: int = 1

item_table = {
    "Crisp Dry Leaves x3": WSRItemData(
        code=100001,
        classification=ItemClassification.filler,
        game_id="DryLeaf",
        quantity=3,
    ),

    "Sulfur Powder x3": WSRItemData(
        code=100002,
        classification=ItemClassification.filler,
        game_id="FireDust",
        quantity=3,
    ),

    "Lesser Magic Slab x3": WSRItemData(
        code=100003,
        classification=ItemClassification.filler,
        game_id="Stone_0",
        quantity=3,
    ),

    "Boar Meat": WSRItemData(
        code=100004,
        classification=ItemClassification.filler,
        game_id="Meat_Boar",
    ),

    #"Pieberry's Spellbook": WSRItemData(
    #    code=100005,
    #    classification=ItemClassification.COMMENT,
    #    game_id="Book_Level_0",
    #),

    "Secondary Circles Spellbook": WSRItemData(
        code=100006,
        classification=ItemClassification.useful,
        game_id="Book_Level_SubCircle",
        pool_count= 1,
    ),

    #"Red Spellbook": WSRItemData(
    #    code=100007,
    #    classification=ItemClassification.COMMENT,
    #    game_id="Book_Level_2",
    #),

    #"Green Spellbook": WSRItemData(
    #    code=100008,
    #    classification=ItemClassification.COMMENT,
    #    game_id="Book_Level_3",
    #),

    "Anna's Spellbook": WSRItemData(
        code=100009,
        classification=ItemClassification.useful,
        game_id="Book_Level_Anna",
        pool_count= 1,
    ),

    "Fire Magic Spellbook": WSRItemData(
        code=100010,
        classification=ItemClassification.progression,
        game_id="Book_Level_Fire",
        pool_count= 1,
    ),

    "Lightning Magic Spellbook": WSRItemData(
        code=100011,
        classification=ItemClassification.progression,
        game_id="Book_Level_Thunder",
        pool_count= 1,
    ),

    "Ice Magic Spellbook": WSRItemData(
        code=100012,
        classification=ItemClassification.progression,
        game_id="Book_Level_Ice",
        pool_count= 1,
    ),

    "Old Spellbook": WSRItemData(
        code=100013,
        classification=ItemClassification.useful,
        game_id="Book_Level_Old",
        pool_count= 1,
    ),

    "3-Orb Flame Circle": WSRItemData(
        code=100014,
        classification=ItemClassification.progression,
        game_id="MAGICCIRCLE_Fire_3",
        pool_count= 1,
    ),

    "4-Orb Flame Circle": WSRItemData(
        code=100015,
        classification=ItemClassification.progression,
        game_id="MAGICCIRCLE_Fire_4",
        pool_count= 1,
    ),

    "Raw Rabbit Meat": WSRItemData(
        code=100016,
        classification=ItemClassification.filler,
        game_id="Meat_Rabbit",
    ),

    "Strength Stimulant": WSRItemData(
        code=100017,
        classification=ItemClassification.useful,
        game_id="PowerStimulus",
    ),

    "HP Enhancer": WSRItemData(
        code=100018,
        classification=ItemClassification.useful,
        game_id="Meat_RabbitFood",
    ),

    "Lesser Flame Sigil": WSRItemData(
        code=100019,
        classification=ItemClassification.progression,
        game_id="MAGICCIRCLE_Fire_1",
        pool_count= 1,
    ),

    #"Mind Control Circle": WSRItemData(
    #    code=100020,
    #    classification=ItemClassification.progression,
    #    game_id="MAGICCIRCLE_MindControl",
    #    pool_count= 1,
    #),

    "Small Blue Magic Stones": WSRItemData(
        code=100021,
        classification=ItemClassification.filler,
        game_id="Stone_Small_Blue",
    ),

    #"Beginner Wizard's Staff": WSRItemData(
    #    code=100022,
    #    classification=ItemClassification.COMMENT,
    #    game_id="Weapon_Stick_1",
    #),

    #"Enchanted Staff Stage 1": WSRItemData(
    #    code=100023,
    #    classification=ItemClassification.COMMENT,
    #    game_id="Weapon_Stick_SP_1",
    #),

    "Dwarf Golem Grass": WSRItemData(
        code=100024,
        classification=ItemClassification.filler,
        game_id="Leaf_MiniGolem",
    ),

    "Dwarf Golem Essence": WSRItemData(
        code=100025,
        classification=ItemClassification.filler,
        game_id="Leaf_MiniGolem2",
    ),

    "Dried Pie": WSRItemData(
        code=100026,
        classification=ItemClassification.useful,
        game_id="DryBread",
    ),

    "Strength Enhancer": WSRItemData(
        code=100027,
        classification=ItemClassification.useful,
        game_id="RabbitBread",
    ),

    "Leaf Pudding Slice": WSRItemData(
        code=100028,
        classification=ItemClassification.filler,
        game_id="Item_LeafPudding",
    ),

    "Blue Booster Crystal": WSRItemData(
        code=100029,
        classification=ItemClassification.useful,
        game_id="IncreasingStoneBlue",
    ),

    "Dwarf Golem Magic Stone": WSRItemData(
        code=100030,
        classification=ItemClassification.filler,
        game_id="DwarfGolemStone",
    ),

    "Red Booster Crystal": WSRItemData(
        code=100031,
        classification=ItemClassification.useful,
        game_id="IncreasingStoneRed",
    ),

    "Sticky Bomb": WSRItemData(
        code=100032,
        classification=ItemClassification.filler,
        game_id="StickyPack",
    ),

    "Sticky Black Pudding": WSRItemData(
        code=100033,
        classification=ItemClassification.filler,
        game_id="BlackPuddingOil",
    ),

    "Mental Enhancer": WSRItemData(
        code=100034,
        classification=ItemClassification.useful,
        game_id="LeafBall",
    ),

    "Blue Absorption Stone": WSRItemData(
        code=100035,
        classification=ItemClassification.useful,
        game_id="BlueAbsorbStone",
    ),

    "Red Absorption Stone": WSRItemData(
        code=100036,
        classification=ItemClassification.useful,
        game_id="RedAbsorbStone",
    ),

    "Giant Frog Poison Pouch": WSRItemData(
        code=100037,
        classification=ItemClassification.filler,
        game_id="PoisonBall",
    ),

    "Poisonous Frog Gas Shell": WSRItemData(
        code=100038,
        classification=ItemClassification.filler,
        game_id="PoisonPocket",
    ),

    "Blade Fragment": WSRItemData(
        code=100039,
        classification=ItemClassification.filler,
        game_id="IronPart",
    ),

    "Life Staff Stage 1": WSRItemData(
        code=100040,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_LIFE_1",
        pool_count= 1,
    ),

    "Lesser Focus Circle": WSRItemData(
        code=100041,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Save_3",
        pool_count= 1,
    ),

    "Lesser Booster Circle": WSRItemData(
        code=100042,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Double_3",
        pool_count= 1,
    ),

    "Dried Strawberry": WSRItemData(
        code=100043,
        classification=ItemClassification.filler,
        game_id="DryBerry",
    ),

    "Basic Iron": WSRItemData(
        code=100044,
        classification=ItemClassification.filler,
        game_id="Iron_1",
    ),

    "Fine Iron": WSRItemData(
        code=100045,
        classification=ItemClassification.filler,
        game_id="Iron_2",
    ),

    "Advanced Iron": WSRItemData(
        code=100046,
        classification=ItemClassification.filler,
        game_id="Iron_3",
    ),

    #Superior Iron": WSRItemData(
    #    code=100047,
    #    classification=ItemClassification.filler,
    #    game_id="Iron_4",
    #),

    "Heartfelt Cookies": WSRItemData(
        code=100048,
        classification=ItemClassification.useful,
        game_id="GoodCookie",
    ),

    "3-Fork Lightning Circle": WSRItemData(
        code=100049,
        classification=ItemClassification.progression,
        game_id="MAGICCIRCLE_Thunder_3",
        pool_count= 1,
    ),

    "Life Staff Stage 2": WSRItemData(
        code=100050,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_LIFE_2",
        pool_count= 1,
    ),

    "Life Staff Stage 3": WSRItemData(
        code=100051,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_LIFE_3",
        pool_count= 1,
    ),

    "Life Staff Stage 4": WSRItemData(
        code=100052,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_LIFE_4",
        pool_count= 1,
    ),

    #"Strength Staff Stage 1": WSRItemData(
    #    code=100053,
    #    classification=ItemClassification.COMMENT,
    #    game_id="Weapon_Stick_STR_1",
    #),

    "Strength Staff Stage 2": WSRItemData(
        code=100054,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_STR_2",
        pool_count= 1,
    ),

    "Strength Staff Stage 3": WSRItemData(
        code=100055,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_STR_3",
        pool_count= 1,
    ),

    "Strength Staff Stage 4": WSRItemData(
        code=100056,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_STR_4",
        pool_count= 1,
    ),

    "Enchanted Staff Stage 2": WSRItemData(
        code=100057,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_SP_2",
        pool_count= 1,
    ),

    "Enchanted Staff Stage 3": WSRItemData(
        code=100058,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_SP_3",
        pool_count= 1,
    ),

    "Enchanted Staff Stage 4": WSRItemData(
        code=100059,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_SP_4",
        pool_count= 1,
    ),

    #"Hardwood Stick": WSRItemData(
    #    code=100060,
    #    classification=ItemClassification.COMMENT,
    #    game_id="Branch",
    #),

    "5-Orb Flame Circle": WSRItemData(
        code=100061,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Fire_5",
        pool_count= 1,
    ),

    "6-Orb Flame Circle": WSRItemData(
        code=100062,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Fire_6",
        pool_count= 1,
    ),

    "7-Orb Flame Circle": WSRItemData(
        code=100063,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Fire_7",
        pool_count= 1,
    ),

    "4-Fork Lightning Circle": WSRItemData(
        code=100064,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Thunder_4",
        pool_count= 1,
    ),

    "5-Fork Lightning Circle": WSRItemData(
        code=100065,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Thunder_5",
        pool_count= 1,
    ),

    "6-Fork Lightning Circle": WSRItemData(
        code=100066,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Thunder_6",
        pool_count= 1,
    ),

    "7-Fork Lightning Circle": WSRItemData(
        code=100067,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Thunder_7",
        pool_count= 1,
    ),

    "3-Pillar Ice Circle": WSRItemData(
        code=100068,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Ice_3",
        pool_count= 1,
    ),

    "4-Pillar Ice Circle": WSRItemData(
        code=100069,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Ice_4",
        pool_count= 1,
    ),

    "5-Pillar Ice Circle": WSRItemData(
        code=100070,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Ice_5",
        pool_count= 1,
    ),

    "6-Pillar Ice Circle": WSRItemData(
        code=100071,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Ice_6",
        pool_count= 1,
    ),

    "7-Pillar Ice Circle": WSRItemData(
        code=100072,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Ice_7",
        pool_count= 1,
    ),

    "Giant Frogspawn": WSRItemData(
        code=100073,
        classification=ItemClassification.filler,
        game_id="Frogspawn",
    ),

    "Electric Pufferfish Spike": WSRItemData(
        code=100074,
        classification=ItemClassification.filler,
        game_id="ThunderFish",
    ),

    "Agility Stimulant": WSRItemData(
        code=100075,
        classification=ItemClassification.useful,
        game_id="AgtStimulus",
    ),

    "Blue Crab Carapace": WSRItemData(
        code=100076,
        classification=ItemClassification.filler,
        game_id="BlueCrabCover",
    ),

    "Big Crab Hat": WSRItemData(
        code=100077,
        classification=ItemClassification.filler,
        game_id="BigCrabCover",
    ),

    "Fire Stone": WSRItemData(
        code=100078,
        classification=ItemClassification.filler,
        game_id="FireStone",
    ),

    "Boar Golem Branch": WSRItemData(
        code=100079,
        classification=ItemClassification.filler,
        game_id="BoarGolemBranch",
    ),

    "Boar Golem Fang": WSRItemData(
        code=100080,
        classification=ItemClassification.filler,
        game_id="BoarGolemTooth",
    ),

    "Weakened Dark Magic Stone Fragment": WSRItemData(
        code=100081,
        classification=ItemClassification.filler,
        game_id="WeakDrakStone",
    ),

    "Boar Captain's Tooth": WSRItemData(
        code=100082,
        classification=ItemClassification.progression,
        game_id="BoarBossTooth",
        pool_count= 1,
    ),

    "Gold": WSRItemData(
        code=100083,
        classification=ItemClassification.filler,
        game_id="Gold",
    ),

    "Kreytes Leaf": WSRItemData(
        code=100084,
        classification=ItemClassification.filler,
        game_id="CreichLeaf",
    ),

    "Kreytes Moisture": WSRItemData(
        code=100085,
        classification=ItemClassification.filler,
        game_id="CreichWater",
    ),

    "Kreytes Root": WSRItemData(
        code=100086,
        classification=ItemClassification.filler,
        game_id="CreichRoot",
    ),

    "Basic Ball Bomb": WSRItemData(
        code=100087,
        classification=ItemClassification.filler,
        game_id="SmallBomb",
    ),

    "Improved Ball Bomb": WSRItemData(
        code=100088,
        classification=ItemClassification.filler,
        game_id="SmallBomb2",
    ),

    "High-Power Ball Bomb": WSRItemData(
        code=100089,
        classification=ItemClassification.filler,
        game_id="SmallBomb3",
    ),

    "Buffalo Gorilla Horn": WSRItemData(
        code=100090,
        classification=ItemClassification.filler,
        game_id="BufaloGoriliaHorn",
    ),

    "Love Antler": WSRItemData(
        code=100091,
        classification=ItemClassification.useful,
        game_id="LoveAntlers",
    ),

    "Lalaque Berry": WSRItemData(
        code=100092,
        classification=ItemClassification.filler,
        game_id="LalaqueApple",
    ),

    "Aged Lalaque Berry": WSRItemData(
        code=100093,
        classification=ItemClassification.useful,
        game_id="LalaqueAppleDark",
    ),

    #"Mine Rat": WSRItemData(
    #    code=100094,
    #    classification=ItemClassification.COMMENT,
    #    game_id="MineMouse",
    #),

    "Rusty Commander's Cabin Key": WSRItemData(
        code=100095,
        classification=ItemClassification.progression,
        game_id="Key_WreckedCaptainRoom",
        pool_count= 1,
    ),

    "Staff Journal": WSRItemData(
        code=100096,
        classification=ItemClassification.useful,
        game_id="WeaponBook",
        pool_count= 1,
    ),

    #"Magic Nutrients": WSRItemData(
    #    code=100097,
    #    classification=ItemClassification.COMMENT,
    #    game_id="IngredientSP",
    #),

    #"Life Nutrients": WSRItemData(
    #    code=100098,
    #    classification=ItemClassification.COMMENT,
    #    game_id="IngredientLIFE",
    #),

    #"Strength Nutrients": WSRItemData(
    #    code=100099,
    #    classification=ItemClassification.COMMENT,
    #    game_id="IngredientSTR",
    #),

    "Wampleaf Petal": WSRItemData(
        code=100100,
        classification=ItemClassification.filler,
        game_id="WampleafPetal",
    ),

    "Wampleaf Leaf": WSRItemData(
        code=100101,
        classification=ItemClassification.filler,
        game_id="WampleafLeaf",
    ),

    "Flame Frog Fire Pouch": WSRItemData(
        code=100102,
        classification=ItemClassification.filler,
        game_id="FireFrogPocket",
    ),

    "Soggy Green Pudding Slice": WSRItemData(
        code=100103,
        classification=ItemClassification.filler,
        game_id="PunchPuddingPart",
    ),

    "Cracked Giant Golem Core": WSRItemData(
        code=100104,
        classification=ItemClassification.filler,
        game_id="OldIronMagicStone",
    ),

    "Hercules Stone": WSRItemData(
        code=100105,
        classification=ItemClassification.useful,
        game_id="PowerStone",
    ),

    "Rage Horn": WSRItemData(
        code=100106,
        classification=ItemClassification.filler,
        game_id="VolcanoHorn",
    ),

    "King Pudding": WSRItemData(
        code=100107,
        classification=ItemClassification.useful,
        game_id="KingPudding",
    ),

    "Queen Pudding": WSRItemData(
        code=100108,
        classification=ItemClassification.useful,
        game_id="QueenPudding",
    ),

    "Neutralized Poison Pouch": WSRItemData(
        code=100109,
        classification=ItemClassification.filler,
        game_id="RefreshedPoisonBall",
    ),

    "Glowing Pollen": WSRItemData(
        code=100110,
        classification=ItemClassification.filler,
        game_id="YellowSeed",
    ),

    "Wampleaf Seed": WSRItemData(
        code=100111,
        classification=ItemClassification.filler,
        game_id="WampleafSeed",
    ),

    "Pleaf": WSRItemData(
        code=100112,
        classification=ItemClassification.filler,
        game_id="Pleaf",
    ),

    "Blue Crab Extract": WSRItemData(
        code=100113,
        classification=ItemClassification.useful,
        game_id="Cronball",
    ),

    "Leaf Pudding Extract": WSRItemData(
        code=100114,
        classification=ItemClassification.useful,
        game_id="PuddingPie",
    ),

    "Aged Frogspawn": WSRItemData(
        code=100115,
        classification=ItemClassification.filler,
        game_id="FrogPie",
    ),

    "Leather Armor": WSRItemData(
        code=100116,
        classification=ItemClassification.useful,
        game_id="Armor_Leather",
        pool_count= 1,
    ),

    "Iron Armor": WSRItemData(
        code=100117,
        classification=ItemClassification.useful,
        game_id="Armor_IronLow",
        pool_count= 1,
    ),

    "Advanced Iron Armor": WSRItemData(
        code=100118,
        classification=ItemClassification.useful,
        game_id="Armor_IronHigh",
        pool_count= 1,
    ),

    "Crabber": WSRItemData(
        code=100119,
        classification=ItemClassification.useful,
        game_id="Armor_Crapper",
        pool_count= 1,
    ),

    "High Crabber": WSRItemData(
        code=100120,
        classification=ItemClassification.useful,
        game_id="Armor_CrapperHigh",
        pool_count= 1,
    ),

    "Mithril Armor": WSRItemData(
        code=100121,
        classification=ItemClassification.useful,
        game_id="Armor_Mithril",
        pool_count= 1,
    ),

    "Advanced Mithril Armor": WSRItemData(
        code=100122,
        classification=ItemClassification.useful,
        game_id="Armor_MithrilHigh",
        pool_count= 1,
    ),

    "Leather Boots": WSRItemData(
        code=100123,
        classification=ItemClassification.useful,
        game_id="Shoes_Leather",
        pool_count= 1,
    ),

    "Iron Boots": WSRItemData(
        code=100124,
        classification=ItemClassification.useful,
        game_id="Shoes_IronLow",
        pool_count= 1,
    ),

    "Improved Iron Boots": WSRItemData(
        code=100125,
        classification=ItemClassification.useful,
        game_id="Shoes_IronMiddle",
        pool_count= 1,
    ),

    "Advanced Iron Boots": WSRItemData(
        code=100126,
        classification=ItemClassification.useful,
        game_id="Shoes_IronHigh",
        pool_count= 1,
    ),

    "Lucca Spike": WSRItemData(
        code=100127,
        classification=ItemClassification.useful,
        game_id="Shoes_Ruka",
        pool_count= 1,
    ),

    "Wild Dog Tooth": WSRItemData(
        code=100128,
        classification=ItemClassification.filler,
        game_id="DogTooth",
    ),

    "Punch Rat Tail": WSRItemData(
        code=100129,
        classification=ItemClassification.filler,
        game_id="PunchTail",
    ),

    "Intermediate Focus Circle": WSRItemData(
        code=100130,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Save_5",
        pool_count= 1,
    ),

    "Intermediate Booster Circle": WSRItemData(
        code=100131,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Double_5",
        pool_count= 1,
    ),

    "Advanced Focus Circle": WSRItemData(
        code=100132,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Save_7",
        pool_count= 1,
    ),

    "Advanced Booster Circle": WSRItemData(
        code=100133,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Double_7",
        pool_count= 1,
    ),

    "Intermediate Magic Slab": WSRItemData(
        code=100134,
        classification=ItemClassification.filler,
        game_id="Stone_1",
        pool_count= 1,
    ),

    "Advanced Magic Slab": WSRItemData(
        code=100135,
        classification=ItemClassification.filler,
        game_id="Stone_2",
        pool_count= 1,
    ),

    "Lava Eye": WSRItemData(
        code=100136,
        classification=ItemClassification.filler,
        game_id="LavaEye",
    ),

    "Lavastein Core": WSRItemData(
        code=100137,
        classification=ItemClassification.filler,
        game_id="LavaCore",
    ),

    "Chaos Stone": WSRItemData(
        code=100138,
        classification=ItemClassification.progression,
        game_id="ConfuseStone",
        pool_count=1,
    ),

    "Barrier Stone": WSRItemData(
        code=100139,
        classification=ItemClassification.filler,
        game_id="LockStone",
    ),

    "Lightning Dragon Horn": WSRItemData(
        code=100140,
        classification=ItemClassification.filler,
        game_id="LightningDragonHorn",
    ),

    "Sparkor": WSRItemData(
        code=100141,
        classification=ItemClassification.filler,
        game_id="Sparkor",
    ),

    "Caric Vocal Chords": WSRItemData(
        code=100142,
        classification=ItemClassification.filler,
        game_id="CaricOrb",
    ),

    "Carico Tail": WSRItemData(
        code=100143,
        classification=ItemClassification.filler,
        game_id="CaricoTailNiddle",
    ),

    "Lightnoceros Horn": WSRItemData(
        code=100144,
        classification=ItemClassification.filler,
        game_id="ElectricRhinoHorn",
    ),

    "Giant Dark Magic Stone": WSRItemData(
        code=100145,
        classification=ItemClassification.filler,
        game_id="BigDarkStone",
    ),

    "Ferocious Soul Orb": WSRItemData(
        code=100146,
        classification=ItemClassification.filler,
        game_id="AngryStone",
    ),

    "Clear Crystal": WSRItemData(
        code=100147,
        classification=ItemClassification.filler,
        game_id="WhiteCrystal",
    ),

    "Glowing Claw": WSRItemData(
        code=100148,
        classification=ItemClassification.filler,
        game_id="BlueCrabHand",
    ),

    "High Elasticity Spring": WSRItemData(
        code=100149,
        classification=ItemClassification.filler,
        game_id="PowerSpring",
    ),

    "Warm Pie": WSRItemData(
        code=100150,
        classification=ItemClassification.useful,
        game_id="WarmBread",
    ),

    "Artisan Pie": WSRItemData(
        code=100151,
        classification=ItemClassification.useful,
        game_id="AnnaBread",
    ),

    "Strawberry Pudding Essence": WSRItemData(
        code=100152,
        classification=ItemClassification.useful,
        game_id="RedBerryPuddingWater",
    ),

    "Lalaque Berry Juice": WSRItemData(
        code=100153,
        classification=ItemClassification.useful,
        game_id="LalaqueAppleJuice",
    ),

    "Mint Pudding Essence": WSRItemData(
        code=100154,
        classification=ItemClassification.useful,
        game_id="MintPuddingWater",
    ),

    "Small Dark Magic Stone": WSRItemData(
        code=100155,
        classification=ItemClassification.filler,
        game_id="DarkStoneSmall",
    ),

    "Dark Magic Stone": WSRItemData(
        code=100156,
        classification=ItemClassification.filler,
        game_id="DarkStone",
    ),

    "Shipwreck Hold Key": WSRItemData(
        code=100157,
        classification=ItemClassification.progression,
        game_id="Key_ShipStoreKey",
        pool_count= 1,
    ),

    "Shipwreck Cannonball": WSRItemData(
        code=100158,
        classification=ItemClassification.progression,
        game_id="ShipCannonBomb",
        pool_count= 1,
    ),

    "Lalaque Mine Key": WSRItemData(
        code=100159,
        classification=ItemClassification.progression,
        game_id="Key_MineUnderDarkStone",
        pool_count= 1,
    ),

    "Matt's Garden Passage Key": WSRItemData(
        code=100160,
        classification=ItemClassification.progression,
        game_id="Key_CannaHouseIronDoor",
        pool_count= 1,
    ),

    "Low-Rank Warrior's Sword": WSRItemData(
        code=100161,
        classification=ItemClassification.useful,
        game_id="Sword_Basic",
        pool_count= 1,
    ),

    "Dispelling Stone": WSRItemData(
        code=100162,
        classification=ItemClassification.progression,
        game_id="FreeStone",
        pool_count= 4
    ),

    "Shieldstone": WSRItemData(
        code=100163,
        classification=ItemClassification.useful,
        game_id="ShieldStone",
    ),

    #"Blue Shieldstone": WSRItemData(
    #    code=100164,
    #    classification=ItemClassification.useful,
    #    game_id="ShieldStoneTween",
    #),

    "Carico Horn": WSRItemData(
        code=100165,
        classification=ItemClassification.filler,
        game_id="CaricoHorn",
    ),

    "Steam Gear": WSRItemData(
        code=100166,
        classification=ItemClassification.filler,
        game_id="SteamGear",
    ),

    "White Rhino Horn": WSRItemData(
        code=100167,
        classification=ItemClassification.filler,
        game_id="WhiteRhinoHorn",
    ),

    "Bomb Journal": WSRItemData(
        code=100168,
        classification=ItemClassification.useful,
        game_id="Book_Bomb",
        pool_count= 1,
    ),

    "Bomb Wick": WSRItemData(
        code=100169,
        classification=ItemClassification.filler,
        game_id="BombLine",
    ),

    "Combat Top": WSRItemData(
        code=100170,
        classification=ItemClassification.useful,
        game_id="TouchClothArmor",
        pool_count= 1,
    ),

    "White Fox Marble": WSRItemData(
        code=100171,
        classification=ItemClassification.useful,
        game_id="FoxOrb",
        pool_count= 1,
    ),

    "Fox Marble Shard": WSRItemData(
        code=100172,
        classification=ItemClassification.filler,
        game_id="FoxOrbPart",
    ),

    "Laque Peach": WSRItemData(
        code=100173,
        classification=ItemClassification.useful,
        game_id="SeraDressLaquePeach",
        pool_count= 1,
    ),

    "Skylake": WSRItemData(
        code=100174,
        classification=ItemClassification.useful,
        game_id="SeraDressLakeSky",
        pool_count= 1,
    ),

    "Blackberry Pink": WSRItemData(
        code=100175,
        classification=ItemClassification.useful,
        game_id="BlackberryPink",
        pool_count= 1,
    ),

    "Blackberry Bloom": WSRItemData(
        code=100176,
        classification=ItemClassification.useful,
        game_id="BlackberryBloom",
        pool_count= 1,
    ),

    "Laybiss": WSRItemData(
        code=100177,
        classification=ItemClassification.useful,
        game_id="Laybiss",
    ),

    "Life Stone": WSRItemData(
        code=100178,
        classification=ItemClassification.useful,
        game_id="LifeStone",
    ),

    "Small Powerstone": WSRItemData(
        code=100179,
        classification=ItemClassification.filler,
        game_id="GolemPowerStone1",
    ),

    "Medium Powerstone": WSRItemData(
        code=100180,
        classification=ItemClassification.filler,
        game_id="GolemPowerStone2",
    ),

    "Large Powerstone": WSRItemData(
        code=100181,
        classification=ItemClassification.filler,
        game_id="GolemPowerStone3",
    ),

    "Broken Large Powerstone": WSRItemData(
        code=100182,
        classification=ItemClassification.filler,
        game_id="GolemPowerStone3Broken",
    ),

    "Eilion": WSRItemData(
        code=100183,
        classification=ItemClassification.filler,
        game_id="Eyelion",
        pool_count= 1,
    ),

    "Wind Bangle": WSRItemData(
        code=100184,
        classification=ItemClassification.useful,
        game_id="WindBangle",
        pool_count= 1,
    ),

    "Barrier Bangle": WSRItemData(
        code=100185,
        classification=ItemClassification.useful,
        game_id="BarrierBangle",
        pool_count= 1,
    ),

    "Zircon": WSRItemData(
        code=100186,
        classification=ItemClassification.filler,
        game_id="Zircon",
    ),

    "Tail Sting": WSRItemData(
        code=100187,
        classification=ItemClassification.filler,
        game_id="TailNiddle",
    ),

    "Clear Droplet Bag": WSRItemData(
        code=100188,
        classification=ItemClassification.filler,
        game_id="CleanWaterBall",
    ),

    "Peanut Shark Signal Flare": WSRItemData(
        code=100189,
        classification=ItemClassification.useful,
        game_id="BirdSharkSign",
        pool_count= 1,
    ),

    "Compact Sun Shard": WSRItemData(
        code=100190,
        classification=ItemClassification.filler,
        game_id="SmallSun",
    ),

    "Quick Feather": WSRItemData(
        code=100191,
        classification=ItemClassification.filler,
        game_id="FastFeather",
    ),

    "White Feather Shoe": WSRItemData(
        code=100192,
        classification=ItemClassification.useful,
        game_id="FeatherShoose",
        pool_count= 1,
    ),

    "Ugly Laurel": WSRItemData(
        code=100193,
        classification=ItemClassification.filler,
        game_id="UglyBay",
    ),

    "Laurel Feather Shoes": WSRItemData(
        code=100194,
        classification=ItemClassification.useful,
        game_id="FeatherShoose2",
        pool_count= 1,
    ),

    "Mid-Rank Palace Warrior's Sword": WSRItemData(
        code=100195,
        classification=ItemClassification.useful,
        game_id="Sword_Mid",
        pool_count= 1,
    ),

    "High-Rank Palace Warrior's Sword": WSRItemData(
        code=100196,
        classification=ItemClassification.useful,
        game_id="Sword_High",
        pool_count= 1,
    ),

    "Redvic": WSRItemData(
        code=100197,
        classification=ItemClassification.useful,
        game_id="Sword_RedBig",
        pool_count= 1,
    ),

    #"Livya's Sword": WSRItemData(
    #    code=100198,
    #    classification=ItemClassification.useful,
    #    game_id="Sword_Livya",
    #    pool_count= 1,
    #),

    #"Justice's Sword": WSRItemData(
    #    code=100199,
    #    classification=ItemClassification.useful,
    #    game_id="Sword_Justice",
    #    pool_count= 1,
    #),

    "Faded Lightning Blade": WSRItemData(
        code=100200,
        classification=ItemClassification.useful,
        game_id="Sword_Thunder",
        pool_count=1,
    ),

    #"Lightning Blade": WSRItemData(
    #    code=100201,
    #    classification=ItemClassification.useful,
    #    game_id="Sword_Thunder2",
    #    pool_count= 1,
    #),

    "Sun Sword": WSRItemData(
        code=100202,
        classification=ItemClassification.useful,
        game_id="Sword_Fire",
        pool_count= 1,
    ),
    "Frozen Sword Handle": WSRItemData(
        code=100203,
        classification=ItemClassification.progression,
        game_id="Sword_Ice",
        pool_count= 1,
    ),

    "Ludina Blade": WSRItemData(
        code=100204,
        classification=ItemClassification.useful,
        game_id="Sword_Ice2",
        pool_count= 1,
    ),

    "Tainted Lesser Warrior's Blade": WSRItemData(
        code=100205,
        classification=ItemClassification.useful,
        game_id="Sword_Dark_Low",
        pool_count= 1,
    ),

    "Aged Leaf Pudding Slice": WSRItemData(
        code=100206,
        classification=ItemClassification.useful,
        game_id="OldLeafPuddingPart",
    ),

    "King Queen Pudding": WSRItemData(
        code=100207,
        classification=ItemClassification.useful,
        game_id="KingQueenPudding",
    ),

    "Tarnished Flame Sword": WSRItemData(
        code=100208,
        classification=ItemClassification.filler,
        game_id="Sword_FireOff",
        pool_count= 1,
    ),

    "Ancient Weapon Recipe": WSRItemData(
        code=100209,
        classification=ItemClassification.useful,
        game_id="Book_AcientWeapon",
        pool_count= 1,
    ),

    "Soul Sword": WSRItemData(
        code=100210,
        classification=ItemClassification.progression,
        game_id="Sword_Soul",
        pool_count= 1,
    ),

    "Tarnished Soul Sword": WSRItemData(
        code=100211,
        classification=ItemClassification.filler,
        game_id="Sword_SoulOff",
        pool_count= 1,
    ),

    "Aimhard's Necklace": WSRItemData(
        code=100212,
        classification=ItemClassification.progression,
        game_id="AimhardNecklace",
        pool_count= 1,
    ),

    "Protein Pudding": WSRItemData(
        code=100213,
        classification=ItemClassification.useful,
        game_id="PowerPudding",
    ),

    "Ancient Lightning Dragon Horn": WSRItemData(
        code=100214,
        classification=ItemClassification.useful,
        game_id="AcientLightningDragonHorn",
    ),

    "Giant Zirconia": WSRItemData(
        code=100215,
        classification=ItemClassification.useful,
        game_id="ZirconinaBig",
    ),

    "Zirconia": WSRItemData(
        code=100216,
        classification=ItemClassification.useful,
        game_id="Zirconina",
    ),

    "Secret Trader Key": WSRItemData(
        code=100217,
        classification=ItemClassification.progression,
        game_id="Key_RedBeard",
        pool_count= 1,
    ),

    "Ice Witch Scarf": WSRItemData(
        code=100218,
        classification=ItemClassification.progression,
        game_id="IceScarf",
        pool_count= 1,
    ),

    "Ice Giant Head": WSRItemData(
        code=100219,
        classification=ItemClassification.useful,
        game_id="IceHead",
    ),

    "Ice Core": WSRItemData(
        code=100220,
        classification=ItemClassification.useful,
        game_id="IceCore",
    ),

    "Schwitz's Arm": WSRItemData(
        code=100221,
        classification=ItemClassification.filler,
        game_id="IceSharpArm",
    ),

    "Frozen Claw": WSRItemData(
        code=100222,
        classification=ItemClassification.filler,
        game_id="IceNail",
    ),

    "Frozen Heart": WSRItemData(
        code=100223,
        classification=ItemClassification.progression,
        game_id="IceHeart",
    ),

    "Glittering Ice": WSRItemData(
        code=100224,
        classification=ItemClassification.filler,
        game_id="EternalIce",
    ),

    "Temar Summon Sigil": WSRItemData(
        code=100225,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Temar",
        pool_count= 1,
    ),

    "Promise Potion": WSRItemData(
        code=100226,
        classification=ItemClassification.useful,
        game_id="WarriorPortion1",
    ),

    "Anticipation Potion": WSRItemData(
        code=100227,
        classification=ItemClassification.useful,
        game_id="WarriorPortion2",
    ),

    "Miracle Potion": WSRItemData(
        code=100228,
        classification=ItemClassification.useful,
        game_id="WarriorPortion3",
    ),

    "Ruaret": WSRItemData(
        code=100229,
        classification=ItemClassification.useful,
        game_id="Ruaret",
    ),

    "Secondary Equipment Journal": WSRItemData(
        code=100230,
        classification=ItemClassification.useful,
        game_id="Book_Accessary",
        pool_count= 1,
    ),

    "Magic Enhancer": WSRItemData(
        code=100231,
        classification=ItemClassification.useful,
        game_id="SPGrowth",
    ),

    "Combat Aids Journal": WSRItemData(
        code=100232,
        classification=ItemClassification.useful,
        game_id="Book_BattleSub",
        pool_count= 1,
    ),

    "Chaos Stone Earrings": WSRItemData(
        code=100233,
        classification=ItemClassification.useful,
        game_id="OrangeConfusingStone",
        pool_count= 1,
    ),

    "Reforgeable Equipment Journal": WSRItemData(
        code=100234,
        classification=ItemClassification.useful,
        game_id="Book_Reforge",
        pool_count= 1,
    ),

    "Light Wooden Shield": WSRItemData(
        code=100235,
        classification=ItemClassification.useful,
        game_id="Shield_Wood",
        pool_count= 1,
    ),

    "Steel Shield": WSRItemData(
        code=100236,
        classification=ItemClassification.useful,
        game_id="Shield_Iron",
        pool_count= 1,
    ),

    "Owl Shield": WSRItemData(
        code=100237,
        classification=ItemClassification.useful,
        game_id="Shield_Wood_Owl",
        pool_count= 1,
    ),

    "Low-Rank Warrior Mark": WSRItemData(
        code=100238,
        classification=ItemClassification.filler,
        game_id="WarriorMark_Low",
        pool_count= 1,
    ),

    "Mid-Rank Warrior Mark": WSRItemData(
        code=100239,
        classification=ItemClassification.filler,
        game_id="WarriorMark_Mid",
        pool_count= 1,
    ),

    "High-Rank Warrior Mark": WSRItemData(
        code=100240,
        classification=ItemClassification.filler,
        game_id="WarriorMark_High",
        pool_count= 1,
    ),

    "Strength Ring": WSRItemData(
        code=100241,
        classification=ItemClassification.useful,
        game_id="PowerRing",
        pool_count= 1,
    ),

    "Enchanted Ring": WSRItemData(
        code=100242,
        classification=ItemClassification.useful,
        game_id="MagicRing",
        pool_count= 1,
    ),

    "Defense Ring": WSRItemData(
        code=100243,
        classification=ItemClassification.useful,
        game_id="DefenceRing",
        pool_count= 1,
    ),

    "Agility Ring": WSRItemData(
        code=100244,
        classification=ItemClassification.useful,
        game_id="AgilityRing",
        pool_count= 1,
    ),

    "Enhanced Mid-Rank Palace Warrior Sword": WSRItemData(
        code=100245,
        classification=ItemClassification.useful,
        game_id="Sword_Mid_2",
        pool_count= 1,
    ),

    "Antler Shield": WSRItemData(
        code=100246,
        classification=ItemClassification.useful,
        game_id="Shield_Iron_Horn",
        pool_count= 1,
    ),

    "Iron Ore": WSRItemData(
        code=100247,
        classification=ItemClassification.filler,
        game_id="IronOre",
    ),

    "Steam Pipe": WSRItemData(
        code=100248,
        classification=ItemClassification.filler,
        game_id="SteamPipe",
    ),

    "High-Rank Warrior Shield": WSRItemData(
        code=100249,
        classification=ItemClassification.useful,
        game_id="Shield_Iron_High",
        pool_count= 1,
    ),

    "Purification Necklace": WSRItemData(
        code=100250,
        classification=ItemClassification.useful,
        game_id="PureEaring",
        pool_count= 1,
    ),

    "Glorious Armor": WSRItemData(
        code=100251,
        classification=ItemClassification.useful,
        game_id="Armor_IronGlory",
        pool_count= 1,
    ),

    "Glorious Shield": WSRItemData(
        code=100252,
        classification=ItemClassification.useful,
        game_id="Shield_IronGlory",
        pool_count= 1,
    ),

    "Glorious Sword": WSRItemData(
        code=100253,
        classification=ItemClassification.useful,
        game_id="Sword_IronGlory",
        pool_count= 1,
    ),

    "Commander's Insignia": WSRItemData(
        code=100254,
        classification=ItemClassification.progression,
        game_id="LivyaMark",
        pool_count= 1,
    ),

    "Rich Pudding Juice": WSRItemData(
        code=100255,
        classification=ItemClassification.useful,
        game_id="PuddingApple",
    ),

    "Aromatic Meat Pie": WSRItemData(
        code=100256,
        classification=ItemClassification.useful,
        game_id="MeatPie",
    ),

    "Bane Herb": WSRItemData(
        code=100257,
        classification=ItemClassification.useful,
        game_id="DarkLeaf",
    ),

    "Zircon Armor": WSRItemData(
        code=100258,
        classification=ItemClassification.useful,
        game_id="Amor_Zircon",
        pool_count= 1,
    ),

    "Zirconia Armor": WSRItemData(
        code=100259,
        classification=ItemClassification.useful,
        game_id="Amor_Zirconia",
        pool_count= 1,
    ),

    "Lightning Blade": WSRItemData(
        code=100260,
        classification=ItemClassification.useful,
        game_id="Sword_Thunder3",
        pool_count= 1,
    ),

    "Dangerous Journal": WSRItemData(
        code=100261,
        classification=ItemClassification.useful,
        game_id="Book_Ban",
        pool_count= 1,
    ),

    "Ugly Bird Meat": WSRItemData(
        code=100262,
        classification=ItemClassification.filler,
        game_id="MeatUglyBird",
    ),

    "Lightning Blast": WSRItemData(
        code=100263,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_Thunder",
        pool_count= 1,
    ),

    "Narrel Flesh": WSRItemData(
        code=100264,
        classification=ItemClassification.useful,
        game_id="NarMeat",
    ),

    "Narrel Scale": WSRItemData(
        code=100265,
        classification=ItemClassification.useful,
        game_id="NarCover",
    ),

    "Lucca Claw": WSRItemData(
        code=100266,
        classification=ItemClassification.filler,
        game_id="RukaNail",
    ),

    "Carrot": WSRItemData(
        code=100267,
        classification=ItemClassification.filler,
        game_id="Carrot",
    ),

    "Bedos's Headband": WSRItemData(
        code=100268,
        classification=ItemClassification.useful,
        game_id="BedosHeadband",
        pool_count= 1,
    ),

    "Valor Ring": WSRItemData(
        code=100269,
        classification=ItemClassification.useful,
        game_id="WarriorRing",
        pool_count= 1,
    ),

    "Wisdom Ring": WSRItemData(
        code=100270,
        classification=ItemClassification.useful,
        game_id="WizardRing",
        pool_count= 1,
    ),

    "Eagle Pendant": WSRItemData(
        code=100271,
        classification=ItemClassification.useful,
        game_id="BraveStep",
        pool_count= 1,
    ),

    "Green Rally Pendant": WSRItemData(
        code=100272,
        classification=ItemClassification.useful,
        game_id="RallyNecklace1",
        pool_count= 1,
    ),

    "Blue Rally Pendant": WSRItemData(
        code=100273,
        classification=ItemClassification.useful,
        game_id="RallyNecklace2",
        pool_count= 1,
    ),

    "Awakening Pendant": WSRItemData(
        code=100274,
        classification=ItemClassification.useful,
        game_id="WakeUpPendent",
        pool_count= 1,
    ),

    "Lightning Needle": WSRItemData(
        code=100275,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_ThunderNiddle",
        pool_count= 1,
    ),

    "Flame Staff": WSRItemData(
        code=100276,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_Fire",
        pool_count= 1,
    ),

    "Dark Sword": WSRItemData(
        code=100277,
        classification=ItemClassification.useful,
        game_id="Sword_Dark",
        pool_count= 1,
    ),

    "Blue Moonstone Staff": WSRItemData(
        code=100278,
        classification=ItemClassification.useful,
        game_id="BlueMoonStick",
        pool_count= 1,
    ),

    "Big Pie": WSRItemData(
        code=100279,
        classification=ItemClassification.useful,
        game_id="BigPie",
    ),

    "Tough Soup": WSRItemData(
        code=100280,
        classification=ItemClassification.useful,
        game_id="StrengthSoup",
    ),

    "Nightmare Sword": WSRItemData(
        code=100281,
        classification=ItemClassification.useful,
        game_id="Sword_Nightmare",
        pool_count= 1,
    ),

    "Gravity Stone": WSRItemData(
        code=100282,
        classification=ItemClassification.useful,
        game_id="GravityStone",
    ),

    "Crew List": WSRItemData(
        code=100283,
        classification=ItemClassification.progression,
        game_id="ShipMemberList",
        pool_count= 1,
    ),

    "Shipwreck Brig Key": WSRItemData(
        code=100284,
        classification=ItemClassification.progression,
        game_id="Key_ShipPrison",
        pool_count= 1,
    ),

    "Shadow Shield": WSRItemData(
        code=100285,
        classification=ItemClassification.useful,
        game_id="Shield_Dark",
        pool_count= 1,
    ),

    "Miro's Headband": WSRItemData(
        code=100286,
        classification=ItemClassification.progression,
        game_id="MiroHairband",
        pool_count= 1,
    ),

    "Flame Pendant": WSRItemData(
        code=100287,
        classification=ItemClassification.useful,
        game_id="FirePendant",
        pool_count= 1,
    ),

    "Ice Shield": WSRItemData(
        code=100288,
        classification=ItemClassification.useful,
        game_id="Shield_Ice",
        pool_count= 1,
    ),

    "Red Gem": WSRItemData(
        code=100289,
        classification=ItemClassification.progression,
        game_id="RedJewel",
        pool_count= 1,
    ),

    "Protoype Steam Engine": WSRItemData(
        code=100290,
        classification=ItemClassification.progression,
        game_id="FirstSteamEngine",
        pool_count= 1,
    ),

    "Matt's Letter": WSRItemData(
        code=100291,
        classification=ItemClassification.progression,
        game_id="GolemBlueprintInfo",
        pool_count= 1,
    ),

    "Evolved Lightning Needle": WSRItemData(
        code=100292,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_ThunderNiddle2",
        pool_count= 1,
    ),

    "Evolved Flame Staff": WSRItemData(
        code=100293,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_Fire2",
        pool_count= 1,
    ),

    "White Wood Staff": WSRItemData(
        code=100294,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_WhiteTree",
        pool_count= 1,
    ),

    "Budding White Wood Staff": WSRItemData(
        code=100295,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_WhiteTree_LIFE",
        pool_count= 1,
    ),

    #"Broken Staff": WSRItemData(
    #    code=100296,
    #    classification=ItemClassification.COMMENT,
    #    game_id="Weapon_Stick_1Broken",
    #),

    "Water Balloon Frog Mucus": WSRItemData(
        code=100297,
        classification=ItemClassification.filler,
        game_id="BlueFrogMocus",
    ),

    "Rookveli Crest": WSRItemData(
        code=100298,
        classification=ItemClassification.useful,
        game_id="RukevalleyMark",
        pool_count= 1,
    ),

    "Enhanced High-Rank Warrior Sword": WSRItemData(
        code=100299,
        classification=ItemClassification.useful,
        game_id="Sword_High2",
        pool_count= 1,
    ),

    "Shipwreck Diary Page 1": WSRItemData(
        code=100300,
        classification=ItemClassification.filler,
        game_id="JadePaper1",
        pool_count= 1,
    ),

    "Shipwreck Diary Page 2": WSRItemData(
        code=100301,
        classification=ItemClassification.filler,
        game_id="JadePaper2",
        pool_count= 1,
    ),

    "Shipwreck Diary Page 3": WSRItemData(
        code=100302,
        classification=ItemClassification.filler,
        game_id="JadePaper3",
        pool_count= 1,
    ),

    "Shipwreck Diary Page 4": WSRItemData(
        code=100303,
        classification=ItemClassification.filler,
        game_id="JadePaper4",
        pool_count= 1,
    ),

    "Shipwreck Diary Page 5": WSRItemData(
        code=100304,
        classification=ItemClassification.filler,
        game_id="JadePaper5",
        pool_count= 1,
    ),

    "Shipwreck Diary": WSRItemData(
        code=100305,
        classification=ItemClassification.progression,
        game_id="JadePaper",
        pool_count= 1,
    ),

    "Shipwreck Diary Page 6": WSRItemData(
        code=100306,
        classification=ItemClassification.filler,
        game_id="JadePaper6",
        pool_count= 1,
    ),

    "Shipwreck Diary Page 7": WSRItemData(
        code=100307,
        classification=ItemClassification.filler,
        game_id="JadePaper7",
        pool_count= 1,
    ),

    "Ecarr Vertel": WSRItemData(
        code=100308,
        classification=ItemClassification.useful,
        game_id="MAGICCIRCLE_Ekar",
        pool_count= 1,
    ),

    "Bundle of Teleportation Talismans": WSRItemData(
        code=100309,
        classification=ItemClassification.progression,
        game_id="WarpPapers",
        pool_count= 1,
    ),

    #"Blue Horn Staff": WSRItemData(
    #    code=100310,
    #    classification=ItemClassification.useful,
    #    game_id="Weapon_Stick_WhiteWoodBlue",
    #    pool_count= 1,
    #),

    "Weapon Stimulant": WSRItemData(
        code=100311,
        classification=ItemClassification.useful,
        game_id="WeaponCooler",
    ),

    "Pick-me-up": WSRItemData(
        code=100312,
        classification=ItemClassification.useful,
        game_id="EnergyDrink",
    ),

    "Zirconia Dragon Egg": WSRItemData(
        code=100313,
        classification=ItemClassification.useful,
        game_id="ZirconiaEgg",
        pool_count= 1,
    ),

    "Zirconia Junior": WSRItemData(
        code=100314,
        classification=ItemClassification.useful,
        game_id="ZirconiaJunior",
        pool_count= 1,
    ),

    "Weapon Stimulant": WSRItemData(
        code=100315,
        classification=ItemClassification.useful,
        game_id="WeaponCooler2",
    ),

    "Flaming Budding White Wood Staff": WSRItemData(
        code=100316,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_WhiteTree_LIFE_FIRE",
        pool_count= 1,
    ),

    "Frozen Key": WSRItemData(
        code=100317,
        classification=ItemClassification.progression,
        game_id="Key_Ice",
        pool_count= 1,
    ),

    "Starlight White Wood Staff": WSRItemData(
        code=100318,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_WhiteTree_SP",
        pool_count= 1,
    ),

    "White Wood Club": WSRItemData(
        code=100319,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_WhiteTree_STR",
        pool_count= 1,
    ),

    "Flaming Starlight White Wood Staff": WSRItemData(
        code=100320,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_WhiteTree_SP_FIRE",
        pool_count= 1,
    ),

    "Flaming White Wood Club": WSRItemData(
        code=100321,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_WhiteTree_STR_FIRE",
        pool_count= 1,
    ),

    "Blue Firestone": WSRItemData(
        code=100322,
        classification=ItemClassification.filler,
        game_id="SoulFireStone",
    ),

    "Ra Za'rrel": WSRItemData(
        code=100323,
        classification=ItemClassification.useful,
        game_id="Sword_LaZarel",
        pool_count= 1,
    ),

    "Esteran": WSRItemData(
        code=100324,
        classification=ItemClassification.useful,
        game_id="Sword_Esteran",
        pool_count= 1,
    ),

    "Red Potion": WSRItemData(
        code=100325,
        classification=ItemClassification.useful,
        game_id="WarriorPotionHP",
    ),

    "Mind Cleanser": WSRItemData(
        code=100326,
        classification=ItemClassification.useful,
        game_id="WarriorPotionMP",
    ),

    "Great Key": WSRItemData(
        code=100327,
        classification=ItemClassification.progression,
        game_id="Key_Big",
        pool_count= 1,
    ),

    "Kreytes Berry": WSRItemData(
        code=100328,
        classification=ItemClassification.useful,
        game_id="CreichApple",
    ),

    "Magic Stimulant": WSRItemData(
        code=100329,
        classification=ItemClassification.useful,
        game_id="MagicStimulus",
    ),

    "Red Shieldstone": WSRItemData(
        code=100330,
        classification=ItemClassification.useful,
        game_id="ShieldStoneRed",
    ),

    "Genesis Blessing": WSRItemData(
        code=100331,
        classification=ItemClassification.useful,
        game_id="GuardianPendant",
        pool_count= 1,
    ),

    "Red Shieldstone": WSRItemData(
        code=100332,
        classification=ItemClassification.useful,
        game_id="ShieldStoneRed2",
    ),

    "Red Berry White": WSRItemData(
        code=100333,
        classification=ItemClassification.filler,
        game_id="RedBerryWhite",
        pool_count= 1,
    ),

    "Red Berry Blossom": WSRItemData(
        code=100334,
        classification=ItemClassification.filler,
        game_id="RedBerryBlossom",
        pool_count= 1,
    ),

    "Black Pearl Mini": WSRItemData(
        code=100335,
        classification=ItemClassification.filler,
        game_id="BlackPearlMini",
        pool_count= 1,
    ),

    "Deep Black Pearl": WSRItemData(
        code=100336,
        classification=ItemClassification.filler,
        game_id="BlackPearlDeep",
        pool_count= 1,
    ),

    "Silver Rose Seed": WSRItemData(
        code=100337,
        classification=ItemClassification.filler,
        game_id="RoseIronSeed",
        pool_count= 1,
    ),

    "Silver Rose Knight": WSRItemData(
        code=100338,
        classification=ItemClassification.filler,
        game_id="RoseIronKnight",
        pool_count= 1,
    ),

    "Shining Dawn Princess": WSRItemData(
        code=100339,
        classification=ItemClassification.filler,
        game_id="ShiningDawnPrincess",
        pool_count= 1,
    ),

    "Shining Dawn Angel": WSRItemData(
        code=100340,
        classification=ItemClassification.filler,
        game_id="ShiningDawnAngel",
        pool_count= 1,
    ),

    "Strength Amplifier": WSRItemData(
        code=100341,
        classification=ItemClassification.useful,
        game_id="PowerStimuler",
    ),

    "Mind Stimulator": WSRItemData(
        code=100342,
        classification=ItemClassification.useful,
        game_id="MagicStimuler",
    ),

    "Silver Feather": WSRItemData(
        code=100343,
        classification=ItemClassification.useful,
        game_id="CloudShoes",
        pool_count= 1,
    ),

    "Flower of Repose": WSRItemData(
        code=100344,
        classification=ItemClassification.useful,
        game_id="RestFlower",
        pool_count= 1,
    ),

    "Gilded Chalice": WSRItemData(
        code=100345,
        classification=ItemClassification.useful,
        game_id="GoldenGrail",
        pool_count= 1,
    ),

    "Extreme Ludina Blade": WSRItemData(
        code=100346,
        classification=ItemClassification.useful,
        game_id="Sword_Ice3",
        pool_count= 1,
    ),

    "Blazing Sun Sword": WSRItemData(
        code=100347,
        classification=ItemClassification.useful,
        game_id="Sword_Fire2",
        pool_count= 1,
    ),

    "Rampaging Nightmare Blade": WSRItemData(
        code=100348,
        classification=ItemClassification.useful,
        game_id="Sword_Nightmare2",
        pool_count= 1,
    ),

    "Assembly of Tainted Souls": WSRItemData(
        code=100349,
        classification=ItemClassification.useful,
        game_id="RedFreeStone",
    ),

    "Black Horn Club": WSRItemData(
        code=100350,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_WhiteTree_STR_2",
        pool_count= 1,
    ),

    "Earth Staff": WSRItemData(
        code=100351,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_WhiteTree_SP_2",
        pool_count= 1,
    ),

    "Blue Flower Staff": WSRItemData(
        code=100352,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_WhiteTree_LIFE_2",
        pool_count= 1,
    ),

    "Lightning Lance": WSRItemData(
        code=100353,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_ThunderNiddle3",
        pool_count= 1,
    ),

    "Fire Wings": WSRItemData(
        code=100354,
        classification=ItemClassification.useful,
        game_id="Weapon_Stick_Fire3",
        pool_count= 1,
    ),

    "Small Guardian Shards": WSRItemData(
        code=100355,
        classification=ItemClassification.useful,
        game_id="SmalGuardian",
    ),

    "Heart of Fury": WSRItemData(
        code=100356,
        classification=ItemClassification.useful,
        game_id="AngryHeart",
    ),

    "Binding Gloves": WSRItemData(
        code=100357,
        classification=ItemClassification.useful,
        game_id="GuardianGlove",
    ),

    "Guardian Stone": WSRItemData(
        code=100358,
        classification=ItemClassification.useful,
        game_id="BigGuardian",
    ),

    "Nessie's Egg": WSRItemData(
        code=100359,
        classification=ItemClassification.filler,
        game_id="NeciEgg",
    ),

    "Deepstone": WSRItemData(
        code=100360,
        classification=ItemClassification.filler,
        game_id="WhiteDeepStone",
    ),

    "White Rhino's Black Horn": WSRItemData(
        code=100361,
        classification=ItemClassification.filler,
        game_id="BlackRihnoHorn",
    ),

    "Blue Flower Seed": WSRItemData(
        code=100362,
        classification=ItemClassification.filler,
        game_id="BlueFlowerSeed",
    ),

    "Eiger": WSRItemData(
        code=100363,
        classification=ItemClassification.useful,
        game_id="Shield_Eiger",
        pool_count= 1,
    ),

    "Onyx": WSRItemData(
        code=100364,
        classification=ItemClassification.useful,
        game_id="Shield_Onix",
        pool_count= 1,
    ),

    "Lightning Crystal": WSRItemData(
        code=100365,
        classification=ItemClassification.useful,
        game_id="LightningCrystal",
    ),

    "Flame Vessel": WSRItemData(
        code=100366,
        classification=ItemClassification.useful,
        game_id="FireCrystal",
    ),

    "Livya's Special Uniform": WSRItemData(
        code=100367,
        classification=ItemClassification.filler,
        game_id="LivyaDress",
        pool_count= 1,
    ),

    "Dragon Taming Rod": WSRItemData(
        code=100368,
        classification=ItemClassification.useful,
        game_id="DragonStick",
        pool_count= 1,
    ),

    #"Thief's Key": WSRItemData(
    #    code=100369,
    #    classification=ItemClassification.COMMENT,
    #    game_id="Key_Thief",
    #),

    #"Guardian Head": WSRItemData(
    #    code=100370,
    #    classification=ItemClassification.COMMENT,
    #    game_id="GuardianHead",
    #),

    "Nivisus Horn": WSRItemData(
        code=100371,
        classification=ItemClassification.filler,
        game_id="NavisusHorn",
    ),

    "Blue Twin Moonstone Staff": WSRItemData(
        code=100372,
        classification=ItemClassification.useful,
        game_id="BlueMoonStick2",
        pool_count= 1,
    ),

    "Silver Esteran": WSRItemData(
        code=100373,
        classification=ItemClassification.useful,
        game_id="EsteranSpecial",
        pool_count= 1,
    ),

    "Wolf Meat": WSRItemData(
        code=100374,
        classification=ItemClassification.filler,
        game_id="WolfMeat",
    ),

    "Scorpion Tail": WSRItemData(
        code=100375,
        classification=ItemClassification.filler,
        game_id="ScorpionTail",
    ),

    "Giant Scorpion Tail": WSRItemData(
        code=100376,
        classification=ItemClassification.filler,
        game_id="ScorpionTailBig",
    ),

    "Magic Dew": WSRItemData(
        code=100377,
        classification=ItemClassification.filler,
        game_id="BallBatOrb",
    ),

    "Gold Nugget": WSRItemData(
        code=100378,
        classification=ItemClassification.filler,
        game_id="Massgold",
    ),

    "Kentz Stone": WSRItemData(
        code=100379,
        classification=ItemClassification.filler,
        game_id="KenchStone",
    ),

    "Kentz Luster": WSRItemData(
        code=100380,
        classification=ItemClassification.filler,
        game_id="KenLights",
    ),

    "Kentz Leaf": WSRItemData(
        code=100381,
        classification=ItemClassification.filler,
        game_id="KenchStoneLeaf",
    ),

    #"Thin Journal": WSRItemData(
    #    code=100382,
    #    classification=ItemClassification.COMMENT,
    #    game_id="LightBook",
    #),

    "Brilliant Blue Crystal": WSRItemData(
        code=100383,
        classification=ItemClassification.filler,
        game_id="BrightBlueCrystal",
    ),

    "Mintgel Fragment": WSRItemData(
        code=100384,
        classification=ItemClassification.filler,
        game_id="MintJellPortion",
    ),

    "Redgel Fragment": WSRItemData(
        code=100385,
        classification=ItemClassification.filler,
        game_id="RedJellPortion",
    ),

    "Lambette Peach": WSRItemData(
        code=100386,
        classification=ItemClassification.filler,
        game_id="Lambette",
        pool_count= 1,
    ),

    "Sheeplie Peach": WSRItemData(
        code=100387,
        classification=ItemClassification.filler,
        game_id="Sheeplie",
        pool_count= 1,
    ),

    "Aimhard Blessing": WSRItemData(
        code=100388,
        classification=ItemClassification.progression,
        game_id="Bless_Aimhard",
        pool_count= 1,
    ),
    "Durok Blessing": WSRItemData(
        code=100389,
        classification=ItemClassification.progression,
        game_id="Bless_Durok",
        pool_count=1,
    ),
    "Elision Blessing": WSRItemData(
        code=100390,
        classification=ItemClassification.progression,
        game_id="Bless_Elicion",
        pool_count=1,
    ),
    "Arua Arrow Blessing": WSRItemData(
        code=100391,
        classification=ItemClassification.progression,
        game_id="Bless_AruaArrow",
        pool_count=1,
    ),
    "Arua Thunder Blessing": WSRItemData(
        code=100392,
        classification=ItemClassification.progression,
        game_id="Bless_AruaThunder2",
        pool_count=1,
    ),
    "Chapter 2": WSRItemData(
        code=100393,
        classification=ItemClassification.progression,
        game_id="",
        pool_count=0,
    ),
    "Chapter 3": WSRItemData(
        code=100394,
        classification=ItemClassification.progression,
        game_id="",
        pool_count=0,
    ),
    "Chapter 4": WSRItemData(
        code=100395,
        classification=ItemClassification.progression,
        game_id="",
        pool_count=0,
    ),
    "Chapter 5": WSRItemData(
        code=100396,
        classification=ItemClassification.progression,
        game_id="",
        pool_count=0,
    ),
    "Chapter 6": WSRItemData(
        code=100397,
        classification=ItemClassification.progression,
        game_id="",
        pool_count=0,
    ),
    "Chapter 8": WSRItemData(
        code=100399,
        classification=ItemClassification.progression,
        game_id="",
        pool_count=0,
    ),
    "Chapter 7": WSRItemData(
        code=100400,
        classification=ItemClassification.progression,
        game_id="",
        pool_count=0,
    ),
    "Chapter 9": WSRItemData(
        code=100401,
        classification=ItemClassification.progression,
        game_id="",
        pool_count=0,
    ),

}

item_required_chapter = {
    "Chapter 2": 2,
    "Chapter 3": 3,
    "Chapter 4": 4,
    "Chapter 5": 5,
    "Chapter 6": 6,
    "Chapter 7": 7,
    "Chapter 8": 8,
    "Chapter 9": 9,

    "Fire Magic Spellbook": 1,
    "Lightning Magic Spellbook": 1,
    "3-Orb Flame Circle": 1,
    "3-Fork Lightning Circle": 1,
    "Arua Arrow Blessing": 1,
    "Arua Thunder Blessing": 2,
    "4-Orb Flame Circle": 2,
    "Boar Captain's Tooth": 2,
    "Lalaque Mine Key": 2,
    "Rusty Commander's Cabin Key": 3,
    "Shipwreck Hold Key": 3,
    "Shipwreck Brig Key": 3,
    "Shipwreck Cannonball": 3,
    "Crew List": 3,
    "Shipwreck Diary": 3,
    "Miro's Headband": 3,
    "Aimhard's Necklace": 3,
    "Soul Sword": 3,
    "Aimhard Blessing": 3,
    "Commander's Insignia": 3,
    "Bundle of Teleportation Talismans": 3,
    "Matt's Garden Passage Key": 4,
    "Elision Blessing": 4,
    "Secret Trader Key": 5,
    "Great Key": 5,
    "Red Gem": 5,
    "Prototype Steam Engine": 5,
    "Matt's Letter": 5,
    "Frozen Sword Handle": 6,
    "Frozen Key": 6,
    "Ice Magic Spellbook": 6,
    "Ice Witch Scarf": 6,
    "Frozen Heart": 6,
    "Durok Blessing": 6,
    "Dispelling Stone": 6,

}

item_name_to_id = {
    name: data.code
    for name, data in item_table.items()
}