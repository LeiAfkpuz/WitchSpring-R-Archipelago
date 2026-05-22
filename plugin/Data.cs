using WS1RCLASS;

namespace WitchSpringRTestPlugin
{
    public class FieldItemCheck
    {
        public string Scene = "";
        public string ObjectName = "";
        public long LocationId;
        public string DisplayName = "";
    }

    public class ItemGrant
    {
        public string ApItemName = "";
        public string GameItemId = "";
        public int Quantity = 1;
    }

    public class EventRewardCheck
    {
        public string EventId = "";
        public int MethodIndex;
        public string VanillaItem = "";
        public int VanillaQuantity = 1;
        public long LocationId;
        public string DisplayName = "";
    }

    public class ChapterEventCheck
    {
        public int ChapterNumber;
        public long LocationId;
        public string DisplayName = "";
    }

    public class EventGate
    {
        public string Scene = "";
        public string EventId = "";
        public int MethodIndex;
        public string RequiredItem = "";
        public string DisplayName = "";
    }

    //public class ChapterCheck
    //{
    //   public Chapters Chapter;
    //    public long LocationId;
    //   public string DisplayName = "";
    //}

    public static class Data
    {

        //Tried many different moments here and I keep hardlocking the game in cutscenes forcing an Alt+F4. Will revisit in the future maybe.
        public static readonly EventGate[] EventGates = 
        {
        //    new EventGate
        //    {
        //        Scene = "Forest_BlackWitch",
        //        EventId = "event_13",
        //        MethodIndex = 0,
        //        RequiredItem = "Mind Control Circle",
        //        DisplayName = "Black Witch Forest Mind Control Gate",
        //    },
        };
        public static readonly EventRewardCheck[] EventRewardChecks = 
        {
            new EventRewardCheck
            {
                EventId = "event_9",
                MethodIndex = 37,
                VanillaItem = "DryBread",
                VanillaQuantity = 1,
                LocationId = 200150,
                DisplayName = "Event 9 - Item 1",
            },
            new EventRewardCheck
            {
                EventId = "event_9",
                MethodIndex = 41,
                VanillaItem = "DryBread",
                VanillaQuantity = 1,
                LocationId = 200151,
                DisplayName = "Event 9 - Item 2",
            },
            new EventRewardCheck
            {
                EventId = "event_9",
                MethodIndex = 45,
                VanillaItem = "DryBread",
                VanillaQuantity = 1,
                LocationId = 200152,
                DisplayName = "Event 9 - Item 3",
            },
            //Returning Mind Control Slab to vanilla - will cause larger Sphere1 but won't hard lock players forcing them to Alt+F4 their game.
            //new EventRewardCheck
            //{
            //    EventId = "event_14",
            //    MethodIndex = 138,
            //    VanillaItem = "DryBread",
            //    VanillaQuantity = 1,
            //    LocationId = 200153,
            //    DisplayName = "Event 14 - Mind Control Slab",
            //},
            new EventRewardCheck
            {
                EventId = "event_78",
                MethodIndex = 25,
                VanillaItem = "Book_Level_Fire",
                VanillaQuantity = 1,
                LocationId = 200154,
                DisplayName = "event_78 - Fire Spellbook",
            },
            new EventRewardCheck
            {
                EventId = "event_214",
                MethodIndex = 11,
                VanillaItem = "MAGICCIRCLE_Thunder_3",
                VanillaQuantity = 1,
                LocationId = 200155,
                DisplayName = "event_214 - Thunder Slab",
            },
        };

        public static readonly ChapterEventCheck[] ChapterEventChecks =
        {
            new ChapterEventCheck
            {
                ChapterNumber = 2,
                LocationId = 201002,
                DisplayName = "Reached Chapter 2",
            },
            new ChapterEventCheck
            {
                ChapterNumber = 3,
                LocationId = 201003,
                DisplayName = "Reached Chapter 3",
            },
            new ChapterEventCheck
            {
                ChapterNumber = 4,
                LocationId = 201004,
                DisplayName = "Reached Chapter 4",
            },
            new ChapterEventCheck
            {
                ChapterNumber = 5,
                LocationId = 201005,
                DisplayName = "Reached Chapter 5",
            },
            new ChapterEventCheck
            {
                ChapterNumber = 6,
                LocationId = 201006,
                DisplayName = "Reached Chapter 6",
            },
            new ChapterEventCheck
            {
                ChapterNumber = 7,
                LocationId = 201007,
                DisplayName = "Reached Chapter 7",
            },
            new ChapterEventCheck
            {
                ChapterNumber = 8,
                LocationId = 201008,
                DisplayName = "Reached Chapter 8",
            },
            new ChapterEventCheck
            {
                ChapterNumber = 9,
                LocationId = 201009,
                DisplayName = "Reached Chapter 9",
            },
        };
        public static readonly FieldItemCheck[] FieldItemChecks =
        {
            new FieldItemCheck
            {
                Scene = "Temple_Arua_Room1",
                ObjectName = "ChestItem",
                LocationId = 200001,
                DisplayName = "Arua Temple – Room Behind Sealing Stone",
            },
            new FieldItemCheck
            {
                Scene = "House_LalauqeVillageSet",
                ObjectName = "FieldItem_LalaqueApple (1)",
                LocationId = 200002,
                DisplayName = "Lalaque Village - Brida House",
            },
            new FieldItemCheck
            {
                Scene = "House_LalauqeVillageSet",
                ObjectName = "FieldItem_LalaqueApple",
                LocationId = 200003,
                DisplayName = "Lalaque Village - Novel House Floor",
            },
            new FieldItemCheck
            {
                Scene = "House_LalauqeVillageSet",
                ObjectName = "FieldItem_LalaqueApple (2)",
                LocationId = 200004,
                DisplayName = "Lalaque Village - Sara House",
            },
            new FieldItemCheck
            {
                Scene = "House_LalauqeVillageSet",
                ObjectName = "ChestItem (3)",
                LocationId = 200005,
                DisplayName = "Lalaque Village - Novel House Chest",
            },
            new FieldItemCheck
            {
                Scene = "Village_Lalaque_North",
                ObjectName = "Item_Carrot",
                LocationId = 200006,
                DisplayName = "Lalaque Village - Farm 1",
            },
            new FieldItemCheck
            {
                Scene = "Village_Lalaque_North",
                ObjectName = "Item_Carrot (1)",
                LocationId = 200007,
                DisplayName = "Lalaque Village - Farm 2",
            },
            new FieldItemCheck
            {
                Scene = "Village_Lalaque_North",
                ObjectName = "Item_Carrot (2)",
                LocationId = 200008,
                DisplayName = "Lalaque Village - Farm 3",
            },
            new FieldItemCheck
            {
                Scene = "House_Anna",
                ObjectName = "ChestItem",
                LocationId = 200009,
                DisplayName = "Lalaque Village - Anna's House",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine",
                ObjectName = "Item_Sparkor",
                LocationId = 200010,
                DisplayName = "Lalaque Mine - Entrance - Item Across Bridge",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine",
                ObjectName = "Item_Sparkor2",
                LocationId = 200011,
                DisplayName = "Lalaque Mine - Entrance - Item East of Spawn",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine",
                ObjectName = "Item_Sparkor2 (1)",
                LocationId = 200012,
                DisplayName = "Lalaque Mine - Entrance - North West Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_1",
                ObjectName = "Item_Sparkor3 (3)",
                LocationId = 200013,
                DisplayName = "Lalaque Mine - Zone 1 - Middle Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_1",
                ObjectName = "Item_Sparkor3",
                LocationId = 200014,
                DisplayName = "Lalaque Mine - Zone 1 - West Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_1",
                ObjectName = "Item_Sparkor3 (1)",
                LocationId = 200015,
                DisplayName = "Lalaque Mine - Zone 1 - East Bottom Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_1",
                ObjectName = "Item_IronOre (1)",
                LocationId = 200016,
                DisplayName = "Lalaque Mine - Zone 1 - North Carts",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_1",
                ObjectName = "Item_Sparkor3 (2)",
                LocationId = 200017,
                DisplayName = "Lalaque Mine - Zone 1 - East Top Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_1",
                ObjectName = "Item_IronOre (2)",
                LocationId = 200018,
                DisplayName = "Lalaque Mine - Zone 1 - West Carts",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_1",
                ObjectName = "Item_IronOre (3)",
                LocationId = 200019,
                DisplayName = "Lalaque Mine - Zone 1 - East Carts",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_1",
                ObjectName = "Item_IronOre",
                LocationId = 200020,
                DisplayName = "Lalaque Mine - Zone 1 - Before Carts",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_1",
                ObjectName = "ChestItem",
                LocationId = 200021,
                DisplayName = "Lalaque Mine - Zone 1 - Carts Chest",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_2",
                ObjectName = "Item_IronOre (1)",
                LocationId = 200022,
                DisplayName = "Lalaque Mine - Zone 2 - Back Center Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_2",
                ObjectName = "Item_IronOre (4)",
                LocationId = 200023,
                DisplayName = "Lalaque Mine - Zone 2 - Right Item Across Chasm",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_2",
                ObjectName = "Item_IronOre",
                LocationId = 200024,
                DisplayName = "Lalaque Mine - Zone 2 - Back Right Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_2",
                ObjectName = "Item_IronOre (5)",
                LocationId = 200025,
                DisplayName = "Lalaque Mine - Zone 2 - Left Item Across Chasm",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_2",
                ObjectName = "Item_IronOre (3)",
                LocationId = 200026,
                DisplayName = "Lalaque Mine - Zone 2 - Near Entrance Across Chasm",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_2",
                ObjectName = "Item_IronOre (2)",
                LocationId = 200027,
                DisplayName = "Lalaque Mine - Zone 2 - Near Teleport",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_2",
                ObjectName = "ChestItem (1)",
                LocationId = 200028,
                DisplayName = "Lalaque Mine - Zone 2 - Chest Across Chasm",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_3",
                ObjectName = "Item_IronOre (3)",
                LocationId = 200029,
                DisplayName = "Lalaque Mine - Zone 3 - Right Top Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_3",
                ObjectName = "Item_IronOre (2)",
                LocationId = 200030,
                DisplayName = "Lalaque Mine - Zone 3 - Right Bottom Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_3",
                ObjectName = "Item_IronOre (1)",
                LocationId = 200031,
                DisplayName = "Lalaque Mine - Zone 3 - Far Left Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_3",
                ObjectName = "Item_IronOre",
                LocationId = 200032,
                DisplayName = "Lalaque Mine - Zone 3 - Closer Left Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_3",
                ObjectName = "ChestItem",
                LocationId = 200033,
                DisplayName = "Lalaque Mine - Zone 3 - Left Chest",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_4",
                ObjectName = "Item_IronOre (2)",
                LocationId = 200034,
                DisplayName = "Lalaque Mine - Zone 4 - Puzzle Start",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_4",
                ObjectName = "Item_IronOre (1)",
                LocationId = 200035,
                DisplayName = "Lalaque Mine - Zone 4 - Puzzle Item 2",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_4",
                ObjectName = "Item_IronOre (3)",
                LocationId = 200036,
                DisplayName = "Lalaque Mine - Zone 4 - Puzzle End",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_4",
                ObjectName = "Item_IronOre",
                LocationId = 200037,
                DisplayName = "Lalaque Mine - Zone 4 - Puzzle Item 3",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_4",
                ObjectName = "ChestItem",
                LocationId = 200038,
                DisplayName = "Lalaque Mine - Zone 4 - Chest 1",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_4",
                ObjectName = "ChestItem (1)",
                LocationId = 200039,
                DisplayName = "Lalaque Mine - Zone 4 - Chest 2",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_Store",
                ObjectName = "Item_IronOre (5)",
                LocationId = 200040,
                DisplayName = "Lalaque Mine - Ore Storehouse - Left Closer Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_Store",
                ObjectName = "Item_IronOre (6)",
                LocationId = 200041,
                DisplayName = "Lalaque Mine - Ore Storehouse - Right Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_Store",
                ObjectName = "Item_IronOre (4)",
                LocationId = 200042,
                DisplayName = "Lalaque Mine - Ore Storehouse - Back Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_Store",
                ObjectName = "Item_IronOre (3)",
                LocationId = 200043,
                DisplayName = "Lalaque Mine - Ore Storehouse - Left Further Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_Store",
                ObjectName = "ChestItem (3)",
                LocationId = 200044,
                DisplayName = "Lalaque Mine - Ore Storehouse - Chest 1",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Lalaque_Mine_CannaArea_Store",
                ObjectName = "ChestItem (2)",
                LocationId = 200045,
                DisplayName = "Lalaque Mine - Ore Storehouse - Chest 2",
            },
            new FieldItemCheck
            {
                Scene = "Forest_Lalaque",
                ObjectName = "FieldItem_WarriorTent",
                LocationId = 200046,
                DisplayName = "Lalaque Forest - Warriors Tent - Top Item",
            },
            new FieldItemCheck
            {
                Scene = "Forest_Lalaque",
                ObjectName = "FieldItem_WarriorTent",
                LocationId = 200047,
                DisplayName = "Lalaque Forest - Warriors Tent - Bottom Item",
            },
            new FieldItemCheck
            {
                Scene = "Forest_Lalaque",
                ObjectName = "FieldItem_WarriorTent",
                LocationId = 200048,
                DisplayName = "Lalaque Forest - Warriors Tent - Middle Item",
            },
            new FieldItemCheck
            {
                Scene = "Forest_Lalaque_EastSouth",
                ObjectName = "FieldItem_LalaqueApple",
                LocationId = 200049,
                DisplayName = "Lalaque Forest - Southeast - Middle Item",
            },
            new FieldItemCheck
            {
                Scene = "Forest_Lalaque_EastSouth",
                ObjectName = "FieldItem_LalaqueApple",
                LocationId = 200050,
                DisplayName = "Lalaque Forest - Southeast - Bottom Item",
            },
            new FieldItemCheck
            {
                Scene = "Forest_Lalaque_EastSouth",
                ObjectName = "FieldItem_LalaqueApple",
                LocationId = 200051,
                DisplayName = "Lalaque Forest - Southeast - Top Item",
            },
            new FieldItemCheck
            {
                Scene = "Forest_LionField_Mid",
                ObjectName = "Item_Water (2)",
                LocationId = 200052,
                DisplayName = "Lions Plain - Central - Right Item",
            },
            new FieldItemCheck
            {
                Scene = "Forest_LionField_Mid",
                ObjectName = "Item_Water (1)",
                LocationId = 200053,
                DisplayName = "Lions Plain - Central - Top Item",
            },
            new FieldItemCheck
            {
                Scene = "Forest_LionField_Mid",
                ObjectName = "Item_Water",
                LocationId = 200054,
                DisplayName = "Lions Plain - Central - Bottom Item",
            },
            new FieldItemCheck
            {
                Scene = "Temple_Aimhard_UnderPrison2",
                ObjectName = "ChestItem1",
                LocationId = 200055,
                DisplayName = "Aimhard Temple - Prison - Chest 1",
            },
            new FieldItemCheck
            {
                Scene = "Temple_Aimhard_UnderPrison2",
                ObjectName = "ChestItem2",
                LocationId = 200056,
                DisplayName = "Aimhard Temple - Prison - Chest 2",
            },
            new FieldItemCheck
            {
                Scene = "Temple_Aimhard_UnderPrison3",
                ObjectName = "ChestItem1",
                LocationId = 200057,
                DisplayName = "Aimhard Temple - Prison - Chest 3",
            },
            new FieldItemCheck{
                Scene = "Temple_Aimhard_UnderPrison3",
                ObjectName = "ChestItem1 (1)",
                LocationId = 200058,
                DisplayName = "Aimhard Temple - Prison - Chest 4",
            },
            new FieldItemCheck{
                Scene = "Forest_Boar2",
                ObjectName = "Item_DryLeaf_3 (4)",
                LocationId = 200059,
                DisplayName = "Laoba Mountain - Warrior Camp - Back Right Corner",
            },
            new FieldItemCheck{
                Scene = "Forest_Boar2",
                ObjectName = "Item_DryLeaf_3 (5)",
                LocationId = 200060,
                DisplayName = "Laoba Mountain - Warrior Camp - Inbetween Tents",
            },
            new FieldItemCheck{
                Scene = "Forest_Boar2",
                ObjectName = "Item_DryLeaf_3 (2)",
                LocationId = 200061,
                DisplayName = "Laoba Mountain - Warrior Camp - Tree Near Water",
            },
            new FieldItemCheck{
                Scene = "Forest_Boar2",
                ObjectName = "Item_DryLeaf_3 (3)",
                LocationId = 200062,
                DisplayName = "Laoba Mountain - Warrior Camp - Behind Command Tent",
            },
            new FieldItemCheck{
                Scene = "Forest_Boar2",
                ObjectName = "ChestItem2 (2)",
                LocationId = 200063,
                DisplayName = "Laoba Mountain - Warrior Camp - Chest 1",
            },
            new FieldItemCheck{
                Scene = "Forest_Boar2",
                ObjectName = "ChestItem2 (4)",
                LocationId = 200064,
                DisplayName = "Laoba Mountain - Warrior Camp - Chest 2",
            },
            new FieldItemCheck{
                Scene = "Forest_Boar2",
                ObjectName = "ChestItem2 (3)",
                LocationId = 200065,
                DisplayName = "Laoba Mountain - Warrior Camp - Chest 3",
            },
            //new FieldItemCheck{
            //    Scene = "Road_Babellia_WarriorCamp",
            //    ObjectName = "Item_DryLeaf_3 (4)",
            //    LocationId = 200066,
            //    DisplayName = "CHECK ME",
            //},
            new FieldItemCheck{
                Scene = "Road_Babellia_WarriorCamp",
                ObjectName = "Item_DryLeaf_3 (3)",
                LocationId = 200067,
                DisplayName = "Vavelia Road - Warrior Camp - Command Tent",
            },
            //new FieldItemCheck{
            //    Scene = "Road_Babellia_WarriorCamp",
            //    ObjectName = "Item_DryLeaf_3 (2)",
            //    LocationId = 200068,
            //    DisplayName = "CHECK ME",
            //},
            new FieldItemCheck{
                Scene = "Road_Babellia_WarriorCamp",
                ObjectName = "Item_DryLeaf_3 (6)",
                LocationId = 200069,
                DisplayName = "Vavelia Road - Warrior Camp - By Tents",
            },
            //new FieldItemCheck{
            //    Scene = "Road_Babellia_WarriorCamp",
            //    ObjectName = "Item_DryLeaf_3 (5)",
            //    LocationId = 200070,
            //    DisplayName = "CHECK ME",
            //},
            new FieldItemCheck{
                Scene = "Road_Babellia_WarriorCamp",
                ObjectName = "ChestItem2 (4)",
                LocationId = 200071,
                DisplayName = "Vavelia Road - Warrior Camp - Command Chest 1",
            },
            new FieldItemCheck{
                Scene = "Road_Babellia_WarriorCamp",
                ObjectName = "ChestItem2 (3)",
                LocationId = 200072,
                DisplayName = "Vavelia Road - Warrior Camp - Command Chest 2",
            },
            new FieldItemCheck
            {
                Scene = "Cave_BoarMountain",
                ObjectName = "ChestItem",
                LocationId = 200073,
                DisplayName = "Death Squad Lair - Sleeping Quarters - Chest Behind Beds",
            },
            new FieldItemCheck
            {
                Scene = "Forest_Elicion_Blocked",
                ObjectName = "ChestItem",
                LocationId = 200074,
                DisplayName = "Elysion Plain - Blocked Path - Chest",
            },
            new FieldItemCheck
            {
                Scene = "Village_Vabellia_Enter",
                ObjectName = "Field_item_BigKey",
                LocationId = 200075,
                DisplayName = "Vavelia Village - Village Proper - Ground by Bridge",
            },
            new FieldItemCheck
            {
                Scene = "Village_Vabellia_InnerSet",
                ObjectName = "Field_item_BigKey",
                LocationId = 200076,
                DisplayName = "Vavelia Village - Village Proper - Ground by Other Bridge",
            },
            new FieldItemCheck
            {
                Scene = "Village_Vabellia_InnerSet",
                ObjectName = "FieldItem_LalaqueApple",
                LocationId = 200077,
                DisplayName = "Vavelia Village - Houses - Tavern?",
            },
            new FieldItemCheck
            {
                Scene = "Village_Vabellia_InnerSet",
                ObjectName = "ChestItem (4)",
                LocationId = 200078,
                DisplayName = "Vavelia Village - Houses - Chest 1",
            },
            new FieldItemCheck
            {
                Scene = "Village_Vabellia_InnerSet",
                ObjectName = "ChestItem",
                LocationId = 200079,
                DisplayName = "Vavelia Village - Houses - Chest 2",
            },
            new FieldItemCheck
            {
                Scene = "Village_Vabellia_InnerSet",
                ObjectName = "ChestItem (3)",
                LocationId = 200080,
                DisplayName = "Vavelia Village - Houses - Chest 3",
            },
            new FieldItemCheck
            {
                Scene = "Village_Vabellia_InnerSet",
                ObjectName = "ChestItem (1)",
                LocationId = 200081,
                DisplayName = "Vavelia Village - Houses - Chest 4",
            },
            new FieldItemCheck
            {
                Scene = "Village_Vabellia_InnerSet",
                ObjectName = "ChestItem (2)",
                LocationId = 200082,
                DisplayName = "Vavelia Village - Houses - Chest 5",
            },
            new FieldItemCheck
            {
                Scene = "SnowLand",
                ObjectName = "Item_EternalIce (4)",
                LocationId = 200083,
                DisplayName = "Snow Field - Behind 5 Yeti",
            },
            new FieldItemCheck
            {
                Scene = "SnowLand",
                ObjectName = "Item_EternalIce (2)",
                LocationId = 200084,
                DisplayName = "Snow Field - Item Below Teleport",
            },
            new FieldItemCheck
            {
                Scene = "SnowLand",
                ObjectName = "Item_EternalIce (1)",
                LocationId = 200085,
                DisplayName = "Snow Field - Behind 2 Yeti",
            },
            new FieldItemCheck
            {
                Scene = "SnowLand",
                ObjectName = "Item_EternalIce",
                LocationId = 200086,
                DisplayName = "Snow Field - Next to Item Below Teleport",
            },
            new FieldItemCheck
            {
                Scene = "SnowLand",
                ObjectName = "Item_EternalIce (3)",
                LocationId = 200087,
                DisplayName = "Snow Field - Above Teleport Behind Ramp",
            },
            new FieldItemCheck
            {
                Scene = "SnowLand_Cave",
                ObjectName = "Item_EternalIce (2)",
                LocationId = 200088,
                DisplayName = "Snow Field - Ice Cave - Far Right",
            },
            new FieldItemCheck
            {
                Scene = "SnowLand_Cave",
                ObjectName = "Item_EternalIce",
                LocationId = 200089,
                DisplayName = "Snow Field - Ice Cave - Behind Ramp to Ice Giant",
            },
            new FieldItemCheck
            {
                Scene = "SnowLand_Cave",
                ObjectName = "Item_EternalIce (3)",
                LocationId = 200090,
                DisplayName = "Snow Field - Ice Cave - By Bridge",
            },
            new FieldItemCheck
            {
                Scene = "SnowLand_Cave",
                ObjectName = "Item_EternalIce (1)",
                LocationId = 200091,
                DisplayName = "Snow Field - Ice Cave - Blocked By Schwitz",
            },
            new FieldItemCheck
            {
                Scene = "SnowLand_Cave2",
                ObjectName = "ChestItem",
                LocationId = 200092,
                DisplayName = "Snow Field - Frozen Altar - Chest",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Pudding",
                ObjectName = "Item_Stone_Small",
                LocationId = 200097,
                DisplayName = "Pudding Cave - Entrance - Far Right Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Pudding",
                ObjectName = "ChestItem",
                LocationId = 200098,
                DisplayName = "Pudding Cave - Entrance - Chest",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Pudding_2",
                ObjectName = "ChestItem",
                LocationId = 200103,
                DisplayName = "Pudding Cave - Deep - Bottom Left Chest",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Pudding_3",
                ObjectName = "ChestItem2 (2)",
                LocationId = 200104,
                DisplayName = "Pudding Cave - Royal Pudding - Chest",
            },
            new FieldItemCheck
            {
                Scene = "Swamp_1",
                ObjectName = "Item (1)",
                LocationId = 200105,
                DisplayName = "Swamp - Item Near Wampleaf",
            },
            new FieldItemCheck
            {
                Scene = "Swamp_1",
                ObjectName = "Item",
                LocationId = 200106,
                DisplayName = "Swamp - Central Item",
            },
            new FieldItemCheck
            {
                Scene = "Swamp_1",
                ObjectName = "Item (2)",
                LocationId = 200107,
                DisplayName = "Swamp - Bottom Item",
            },
            new FieldItemCheck
            {
                Scene = "Swamp_1",
                ObjectName = "ChestItem",
                LocationId = 200108,
                DisplayName = "Swamp - Chest 1",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Golem_BackMountain",
                ObjectName = "Item_Stone_Small_Blue (1)",
                LocationId = 200109,
                DisplayName = "Blackhill Golem Cave - Entrance - Item By Fox Den",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Golem_BackMountain",
                ObjectName = "Item_Stone_Small_Blue",
                LocationId = 200110,
                DisplayName = "Blackhill Golem Cave - Entrance - Item By Entrance",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Golem_BackMountain",
                ObjectName = "ChestItem2 (2)",
                LocationId = 200111,
                DisplayName = "Blackhill Golem Cave - Entrance - Chest 1",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Golem_BackMountain",
                ObjectName = "ChestItem2 (1)",
                LocationId = 200112,
                DisplayName = "Blackhill Golem Cave - Entrance - Chest2",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Golem_BackMountain_Fox",
                ObjectName = "ChestItem1",
                LocationId = 200113,
                DisplayName = "Blackhill Golem Cave - Fox Den - Chest",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Golem_BackMountain_Fire",
                ObjectName = "Item_FireDust",
                LocationId = 200114,
                DisplayName = "Blackhill Golem Cave - Fire Cave - Right Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Golem_BackMountain_Fire",
                ObjectName = "Item_FireDust",
                LocationId = 200115,
                DisplayName = "Blackhill Golem Cave - Fire Cave - Item Near Entrance",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Golem_BackMountain_Fire",
                ObjectName = "Item_FireDust (1)",
                LocationId = 200116,
                DisplayName = "Blackhill Golem Cave - Fire Cave - Left Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Golem_BackMountain_Fire_2",
                ObjectName = "Item_FireDust",
                LocationId = 200117,
                DisplayName = "Blackhill Golem Cave - Volcano Road - Left Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Golem_BackMountain_Fire_2",
                ObjectName = "Item_FireDust (1)",
                LocationId = 200118,
                DisplayName = "Blackhill Golem Cave - Volcano Road - Right Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Golem_BackMountain_Fire_3",
                ObjectName = "ChestItem2 (2)",
                LocationId = 200120,
                DisplayName = "Blackhill Golem Cave - Lava Road - Chest Behind Lava Enemies",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Dark",
                ObjectName = "Item_Stone_Small_Blue",
                LocationId = 200121,
                DisplayName = "Darkstone Cave - Entrance - Item Near Entrance",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Dark",
                ObjectName = "Item_Stone_Small_Blue (1)",
                LocationId = 200122,
                DisplayName = "Darkstone Cave - Entrance - Behind 7 Poison Golems 1",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Dark",
                ObjectName = "Item_Stone_Small_Blue (2)",
                LocationId = 200123,
                DisplayName = "Darkstone Cave - Entrance - Behind 7 Poison Golems 2",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Dark",
                ObjectName = "Item_Stone_Small_Blue (4)",
                LocationId = 200124,
                DisplayName = "Darkstone Cave - Entrance - Back Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Dark",
                ObjectName = "Item_Stone_Small_Blue (3)",
                LocationId = 200125,
                DisplayName = "Darkstone Cave - Entrance - Central Left Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Dark",
                ObjectName = "Item_Stone_Small_Blue (5)",
                LocationId = 200126,
                DisplayName = "Darkstone Cave - Entrance - Central Right Item",
            },
            new FieldItemCheck
            {
                Scene = "Forest_Elicion_1",
                ObjectName = "ChestItem",
                LocationId = 200127,
                DisplayName = "Elysion Plain - Central - Chest in Abandonded Camp",
            },
            new FieldItemCheck
            {
                Scene = "Island_Arua",
                ObjectName = "ChestItem1 (1)",
                LocationId = 200128,
                DisplayName = "South Island - Chest 1",
            },
            new FieldItemCheck
            {
                Scene = "Island_Arua",
                ObjectName = "ChestItem1",
                LocationId = 200129,
                DisplayName = "South Island - Chest 2",
            },
            new FieldItemCheck
            {
                Scene = "Island_Arua",
                ObjectName = "ChestItem2 (3)",
                LocationId = 200130,
                DisplayName = "South Island - Chest 3",
            },
            new FieldItemCheck
            {
                Scene = "Island_Arua",
                ObjectName = "ChestItem2 (2)",
                LocationId = 200131,
                DisplayName = "South Island - Chest 4",
            },
            new FieldItemCheck
            {
                Scene = "Island_Arua",
                ObjectName = "ChestItem2 (1)",
                LocationId = 200132,
                DisplayName = "South Island - Chest 5",
            },
            new FieldItemCheck
            {
                Scene = "Island_Arua",
                ObjectName = "ChestItem2",
                LocationId = 200133,
                DisplayName = "South Island - Chest 6",
            },
            new FieldItemCheck
            {
                Scene = "ShipWrecked_Cannon",
                ObjectName = "ChestItem (4)",
                LocationId = 200135,
                DisplayName = "Shipwreck - Armory - Chest 2",
            },
            new FieldItemCheck
            {
                Scene = "ShipWrecked_Cannon",
                ObjectName = "ChestItem (5)",
                LocationId = 200136,
                DisplayName = "Shipwreck - Armory - Chest 3",
            },
            new FieldItemCheck
            {
                Scene = "ShipWrecked_Cannon",
                ObjectName = "ChestItem (2)",
                LocationId = 200137,
                DisplayName = "Shipwreck - Armory - Chest 4",
            },
            new FieldItemCheck
            {
                Scene = "Temple_Durok_2",
                ObjectName = "ChestItem (1)",
                LocationId = 200149,
                DisplayName = "Durok Temple - Sliding Puzzle - Far Right Chest",
            },
            new FieldItemCheck
            {
                Scene = "ShipWrecked_Cannon",
                ObjectName = "ChestItem1",
                LocationId = 200134,
                DisplayName = "Shipwreck - Armory - Chest 1",
            },
            new FieldItemCheck
            {
                Scene = "ShipWrecked_Prison",
                ObjectName = "ChestItem1",
                LocationId = 200139,
                DisplayName = "Shipwreck - Brig - Chest 1",
            },
            new FieldItemCheck
            {
                Scene = "ShipWrecked_Prison",
                ObjectName = "ChestItem1 (1)",
                LocationId = 200140,
                DisplayName = "Shipwreck - Brig - Chest 2",
            },
            new FieldItemCheck
            {
                Scene = "Temple_Arua",
                ObjectName = "ChestItem (1)",
                LocationId = 200141,
                DisplayName = "Arua Temple - Chest 1",
            },
            new FieldItemCheck
            {
                Scene = "Temple_Arua",
                ObjectName = "ChestItem",
                LocationId = 200142,
                DisplayName = "Arua Temple - Chest 2",
            },
            new FieldItemCheck
            {
                Scene = "Temple_Arua",
                ObjectName = "ChestItem (1)",
                LocationId = 200143,
                DisplayName = "Arua Temple - Chest 3",
            },
            new FieldItemCheck
            {
                Scene = "Temple_Arua",
                ObjectName = "ChestItem",
                LocationId = 200144,
                DisplayName = "Arua Temple - Chest 4",
            },
            new FieldItemCheck
            {
                Scene = "Temple_Arua",
                ObjectName = "ChestItem (3)",
                LocationId = 200145,
                DisplayName = "Arua Temple - Chest 5",
            },
            new FieldItemCheck
            {
                Scene = "Temple_Arua",
                ObjectName = "ChestItem (4)",
                LocationId = 200146,
                DisplayName = "Arua Temple - Chest 6",
            },
            new FieldItemCheck
            {
                Scene = "Temple_Arua",
                ObjectName = "ChestItem (2)",
                LocationId = 200147,
                DisplayName = "Arua Temple - Chest 7",
            },
            new FieldItemCheck
            {
                Scene = "Island_Arua_2",
                ObjectName = "ChestItem (1)",
                LocationId = 200148,
                DisplayName = "South Island - Big Crab Island - Chest",
            },
            new FieldItemCheck
            {
                Scene = "Forest_BlackWitch",
                ObjectName = "Item_DryLeaf_0",
                LocationId = 200158,
                DisplayName = "Black Witch Forest - Item 2",
            },
            new FieldItemCheck
            {
                Scene = "Forest_BlackWitch",
                ObjectName = "Item_DryLeaf_3",
                LocationId = 200159,
                DisplayName = "Black Witch Forest - Item 3",
            },
            new FieldItemCheck
            {
                Scene = "Forest_BlackWitch",
                ObjectName = "Item_DryLeaf_3 (1)",
                LocationId = 200157,
                DisplayName = "Black Witch Forest - Item 1",
            },
            new FieldItemCheck
            {
                Scene = "Forest_BlackWitch",
                ObjectName = "Item_DryLeaf_3 (2)",
                LocationId = 200160,
                DisplayName = "Black Witch Forest - Item 4",
            },
            new FieldItemCheck
            {
                Scene = "Forest_BlackWitch",
                ObjectName = "Item_DryLeaf_3 (3)",
                LocationId = 200161,
                DisplayName = "Black Witch Forest - Item 5",
            },
            new FieldItemCheck
            {
                Scene = "Forest_BlackWitch",
                ObjectName = "Item_DryLeaf_2",
                LocationId = 200162,
                DisplayName = "Black Witch Forest - Item 6",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Pudding",
                ObjectName = "Item_Stone_Small (3)",
                LocationId = 200093,
                DisplayName = "Pudding Cave - Entrance - Top Left Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Pudding",
                ObjectName = "Item_Stone_Small (1)",
                LocationId = 200094,
                DisplayName = "Pudding Cave - Entrance - Center Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Pudding",
                ObjectName = "Item_Stone_Small (4)",
                LocationId = 200095,
                DisplayName = "Pudding Cave - Entrance - Bottom Left Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Pudding",
                ObjectName = "Item_Stone_Small (2)",
                LocationId = 200096,
                DisplayName = "Pudding Cave - Entrance - Center Left Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Pudding_2",
                ObjectName = "Item_Stone_Small_Blue (3)",
                LocationId = 200099,
                DisplayName = "Pudding Cave - Deep _ Back Left Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Pudding_2",
                ObjectName = "Item_Stone_Small_Blue (2)",
                LocationId = 200100,
                DisplayName = "Pudding Cave - Deep - Right of Teleporter Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Pudding_2",
                ObjectName = "Item_Stone_Small_Blue (1)",
                LocationId = 200101,
                DisplayName = "Pudding Cave - Deep - Left of Teleporter Item",
            },
            new FieldItemCheck
            {
                Scene = "Cave_Pudding_2",
                ObjectName = "ChestItem1",
                LocationId = 200102,
                DisplayName = "Pudding Cave - Deep - Top Left Chest",
            },
        };

        public static readonly ItemGrant[] ItemGrants =
        {
            new ItemGrant
            {
                ApItemName = "Crisp Dry Leaves x3",
                GameItemId = "DryLeaf",
                Quantity = 3,
            },
            new ItemGrant
            {
                ApItemName = "Sulfur Powder x3",
                GameItemId = "FireDust",
                Quantity = 3,
            },
            new ItemGrant
            {
                ApItemName = "Lesser Magic Slab x3",
                GameItemId = "Stone_0",
                Quantity = 3,
            },
            new ItemGrant
            {
                ApItemName = "Boar Meat",
                GameItemId = "Meat_Boar",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Secondary Circles Spellbook",
                GameItemId = "Book_Level_SubCircle",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Anna's Spellbook",
                GameItemId = "Book_Level_Anna",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Fire Magic Spellbook",
                GameItemId = "Book_Level_Fire",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lightning Magic Spellbook",
                GameItemId = "Book_Level_Thunder",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Ice Magic Spellbook",
                GameItemId = "Book_Level_Ice",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Old Spellbook",
                GameItemId = "Book_Level_Old",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "3-Orb Flame Circle",
                GameItemId = "MAGICCIRCLE_Fire_3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "4-Orb Flame Circle",
                GameItemId = "MAGICCIRCLE_Fire_4",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Raw Rabbit Meat",
                GameItemId = "Meat_Rabbit",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Strength Stimulant",
                GameItemId = "PowerStimulus",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "HP Enhancer",
                GameItemId = "Meat_RabbitFood",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lesser Flame Sigil",
                GameItemId = "MAGICCIRCLE_Fire_1",
                Quantity = 1,
            },
            //new ItemGrant
            //{
            //    ApItemName = "Mind Control Circle",
            //    GameItemId = "MAGICCIRCLE_MindControl",
            //    Quantity = 1,
            //},
            new ItemGrant
            {
                ApItemName = "Small Blue Magic Stones",
                GameItemId = "Stone_Small_Blue",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Dwarf Golem Grass",
                GameItemId = "Leaf_MiniGolem",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Dwarf Golem Essence",
                GameItemId = "Leaf_MiniGolem2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Dried Pie",
                GameItemId = "DryBread",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Strength Enhancer",
                GameItemId = "RabbitBread",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Leaf Pudding Slice",
                GameItemId = "Item_LeafPudding",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blue Booster Crystal",
                GameItemId = "IncreasingStoneBlue",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Dwarf Golem Magic Stone",
                GameItemId = "DwarfGolemStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Red Booster Crystal",
                GameItemId = "IncreasingStoneRed",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Sticky Bomb",
                GameItemId = "StickyPack",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Sticky Black Pudding",
                GameItemId = "BlackPuddingOil",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Mental Enhancer",
                GameItemId = "LeafBall",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blue Absorption Stone",
                GameItemId = "BlueAbsorbStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Red Absorption Stone",
                GameItemId = "RedAbsorbStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Giant Frog Poison Pouch",
                GameItemId = "PoisonBall",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Poisonous Frog Gas Shell",
                GameItemId = "PoisonPocket",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blade Fragment",
                GameItemId = "IronPart",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Life Staff Stage 1",
                GameItemId = "Weapon_Stick_LIFE_1",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lesser Focus Circle",
                GameItemId = "MAGICCIRCLE_Save_3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lesser Booster Circle",
                GameItemId = "MAGICCIRCLE_Double_3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Dried Strawberry",
                GameItemId = "DryBerry",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Basic Iron",
                GameItemId = "Iron_1",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Fine Iron",
                GameItemId = "Iron_2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Advanced Iron",
                GameItemId = "Iron_3",
                Quantity = 1,
            },
            //new ItemGrant
            //{
            //    ApItemName = "Superior Iron",
            //    GameItemId = "Iron_4",
            //    Quantity = 1,
            //},
            new ItemGrant
            {
                ApItemName = "Heartfelt Cookies",
                GameItemId = "GoodCookie",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "3-Fork Lightning Circle",
                GameItemId = "MAGICCIRCLE_Thunder_3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Life Staff Stage 2",
                GameItemId = "Weapon_Stick_LIFE_2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Life Staff Stage 3",
                GameItemId = "Weapon_Stick_LIFE_3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Life Staff Stage 4",
                GameItemId = "Weapon_Stick_LIFE_4",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Strength Staff Stage 2",
                GameItemId = "Weapon_Stick_STR_2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Strength Staff Stage 3",
                GameItemId = "Weapon_Stick_STR_3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Strength Staff Stage 4",
                GameItemId = "Weapon_Stick_STR_4",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Enchanted Staff Stage 2",
                GameItemId = "Weapon_Stick_SP_2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Enchanted Staff Stage 3",
                GameItemId = "Weapon_Stick_SP_3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Enchanted Staff Stage 4",
                GameItemId = "Weapon_Stick_SP_4",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "5-Orb Flame Circle",
                GameItemId = "MAGICCIRCLE_Fire_5",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "6-Orb Flame Circle",
                GameItemId = "MAGICCIRCLE_Fire_6",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "7-Orb Flame Circle",
                GameItemId = "MAGICCIRCLE_Fire_7",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "4-Fork Lightning Circle",
                GameItemId = "MAGICCIRCLE_Thunder_4",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "5-Fork Lightning Circle",
                GameItemId = "MAGICCIRCLE_Thunder_5",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "6-Fork Lightning Circle",
                GameItemId = "MAGICCIRCLE_Thunder_6",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "7-Fork Lightning Circle",
                GameItemId = "MAGICCIRCLE_Thunder_7",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "3-Pillar Ice Circle",
                GameItemId = "MAGICCIRCLE_Ice_3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "4-Pillar Ice Circle",
                GameItemId = "MAGICCIRCLE_Ice_4",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "5-Pillar Ice Circle",
                GameItemId = "MAGICCIRCLE_Ice_5",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "6-Pillar Ice Circle",
                GameItemId = "MAGICCIRCLE_Ice_6",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "7-Pillar Ice Circle",
                GameItemId = "MAGICCIRCLE_Ice_7",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Giant Frogspawn",
                GameItemId = "Frogspawn",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Electric Pufferfish Spike",
                GameItemId = "ThunderFish",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Agility Stimulant",
                GameItemId = "AgtStimulus",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blue Crab Carapace",
                GameItemId = "BlueCrabCover",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Big Crab Hat",
                GameItemId = "BigCrabCover",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Fire Stone",
                GameItemId = "FireStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Boar Golem Branch",
                GameItemId = "BoarGolemBranch",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Boar Golem Fang",
                GameItemId = "BoarGolemTooth",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Weakened Dark Magic Stone Fragment",
                GameItemId = "WeakDrakStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Boar Captain's Tooth",
                GameItemId = "BoarBossTooth",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Gold",
                GameItemId = "Gold",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Kreytes Leaf",
                GameItemId = "CreichLeaf",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Kreytes Moisture",
                GameItemId = "CreichWater",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Kreytes Root",
                GameItemId = "CreichRoot",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Basic Ball Bomb",
                GameItemId = "SmallBomb",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Improved Ball Bomb",
                GameItemId = "SmallBomb2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "High-Power Ball Bomb",
                GameItemId = "SmallBomb3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Buffalo Gorilla Horn",
                GameItemId = "BufaloGoriliaHorn",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Love Antler",
                GameItemId = "LoveAntlers",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lalaque Berry",
                GameItemId = "LalaqueApple",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Aged Lalaque Berry",
                GameItemId = "LalaqueAppleDark",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Rusty Commander's Cabin Key",
                GameItemId = "Key_WreckedCaptainRoom",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Staff Journal",
                GameItemId = "WeaponBook",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Wampleaf Petal",
                GameItemId = "WampleafPetal",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Wampleaf Leaf",
                GameItemId = "WampleafLeaf",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Flame Frog Fire Pouch",
                GameItemId = "FireFrogPocket",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Soggy Green Pudding Slice",
                GameItemId = "PunchPuddingPart",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Cracked Giant Golem Core",
                GameItemId = "OldIronMagicStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Hercules Stone",
                GameItemId = "PowerStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Rage Horn",
                GameItemId = "VolcanoHorn",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "King Pudding",
                GameItemId = "KingPudding",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Queen Pudding",
                GameItemId = "QueenPudding",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Neutralized Poison Pouch",
                GameItemId = "RefreshedPoisonBall",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Glowing Pollen",
                GameItemId = "YellowSeed",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Wampleaf Seed",
                GameItemId = "WampleafSeed",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Pleaf",
                GameItemId = "Pleaf",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blue Crab Extract",
                GameItemId = "Cronball",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Leaf Pudding Extract",
                GameItemId = "PuddingPie",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Aged Frogspawn",
                GameItemId = "FrogPie",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Leather Armor",
                GameItemId = "Armor_Leather",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Iron Armor",
                GameItemId = "Armor_IronLow",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Advanced Iron Armor",
                GameItemId = "Armor_IronHigh",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Crabber",
                GameItemId = "Armor_Crapper",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "High Crabber",
                GameItemId = "Armor_CrapperHigh",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Mithril Armor",
                GameItemId = "Armor_Mithril",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Advanced Mithril Armor",
                GameItemId = "Armor_MithrilHigh",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Leather Boots",
                GameItemId = "Shoes_Leather",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Iron Boots",
                GameItemId = "Shoes_IronLow",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Improved Iron Boots",
                GameItemId = "Shoes_IronMiddle",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Advanced Iron Boots",
                GameItemId = "Shoes_IronHigh",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lucca Spike",
                GameItemId = "Shoes_Ruka",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Wild Dog Tooth",
                GameItemId = "DogTooth",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Punch Rat Tail",
                GameItemId = "PunchTail",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Intermediate Focus Circle",
                GameItemId = "MAGICCIRCLE_Save_5",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Intermediate Booster Circle",
                GameItemId = "MAGICCIRCLE_Double_5",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Advanced Focus Circle",
                GameItemId = "MAGICCIRCLE_Save_7",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Advanced Booster Circle",
                GameItemId = "MAGICCIRCLE_Double_7",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Intermediate Magic Slab",
                GameItemId = "Stone_1",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Advanced Magic Slab",
                GameItemId = "Stone_2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lava Eye",
                GameItemId = "LavaEye",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lavastein Core",
                GameItemId = "LavaCore",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Chaos Stone",
                GameItemId = "ConfuseStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Barrier Stone",
                GameItemId = "LockStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lightning Dragon Horn",
                GameItemId = "LightningDragonHorn",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Sparkor",
                GameItemId = "Sparkor",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Caric Vocal Chords",
                GameItemId = "CaricOrb",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Carico Tail",
                GameItemId = "CaricoTailNiddle",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lightnoceros Horn",
                GameItemId = "ElectricRhinoHorn",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Giant Dark Magic Stone",
                GameItemId = "BigDarkStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Ferocious Soul Orb",
                GameItemId = "AngryStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Clear Crystal",
                GameItemId = "WhiteCrystal",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Glowing Claw",
                GameItemId = "BlueCrabHand",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "High Elasticity Spring",
                GameItemId = "PowerSpring",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Warm Pie",
                GameItemId = "WarmBread",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Artisan Pie",
                GameItemId = "AnnaBread",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Strawberry Pudding Essence",
                GameItemId = "RedBerryPuddingWater",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lalaque Berry Juice",
                GameItemId = "LalaqueAppleJuice",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Mint Pudding Essence",
                GameItemId = "MintPuddingWater",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Small Dark Magic Stone",
                GameItemId = "DarkStoneSmall",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Dark Magic Stone",
                GameItemId = "DarkStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shipwreck Hold Key",
                GameItemId = "Key_ShipStoreKey",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shipwreck Cannonball",
                GameItemId = "ShipCannonBomb",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lalaque Mine Key",
                GameItemId = "Key_MineUnderDarkStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Matt's Garden Passage Key",
                GameItemId = "Key_CannaHouseIronDoor",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Low-Rank Warrior's Sword",
                GameItemId = "Sword_Basic",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Dispelling Stone",
                GameItemId = "FreeStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shieldstone",
                GameItemId = "ShieldStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blue Shieldstone",
                GameItemId = "ShieldStoneTween",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Carico Horn",
                GameItemId = "CaricoHorn",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Steam Gear",
                GameItemId = "SteamGear",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "White Rhino Horn",
                GameItemId = "WhiteRhinoHorn",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Bomb Journal",
                GameItemId = "Book_Bomb",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Bomb Wick",
                GameItemId = "BombLine",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Combat Top",
                GameItemId = "TouchClothArmor",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "White Fox Marble",
                GameItemId = "FoxOrb",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Fox Marble Shard",
                GameItemId = "FoxOrbPart",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Laque Peach",
                GameItemId = "SeraDressLaquePeach",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Skylake",
                GameItemId = "SeraDressLakeSky",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blackberry Pink",
                GameItemId = "BlackberryPink",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blackberry Bloom",
                GameItemId = "BlackberryBloom",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Laybiss",
                GameItemId = "Laybiss",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Life Stone",
                GameItemId = "LifeStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Small Powerstone",
                GameItemId = "GolemPowerStone1",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Medium Powerstone",
                GameItemId = "GolemPowerStone2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Large Powerstone",
                GameItemId = "GolemPowerStone3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Broken Large Powerstone",
                GameItemId = "GolemPowerStone3Broken",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Eilion",
                GameItemId = "Eyelion",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Wind Bangle",
                GameItemId = "WindBangle",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Barrier Bangle",
                GameItemId = "BarrierBangle",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Zircon",
                GameItemId = "Zircon",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Tail Sting",
                GameItemId = "TailNiddle",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Clear Droplet Bag",
                GameItemId = "CleanWaterBall",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Peanut Shark Signal Flare",
                GameItemId = "BirdSharkSign",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Compact Sun Shard",
                GameItemId = "SmallSun",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Quick Feather",
                GameItemId = "FastFeather",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "White Feather Shoe",
                GameItemId = "FeatherShoose",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Ugly Laurel",
                GameItemId = "UglyBay",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Laurel Feather Shoes",
                GameItemId = "FeatherShoose2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Mid-Rank Palace Warrior's Sword",
                GameItemId = "Sword_Mid",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "High-Rank Palace Warrior's Sword",
                GameItemId = "Sword_High",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Redvic",
                GameItemId = "Sword_RedBig",
                Quantity = 1,
            },
            //new ItemGrant
            //{
            //    ApItemName = "Livya's Sword",
            //    GameItemId = "Sword_Livya",
            //    Quantity = 1,
            //},
            //new ItemGrant
            //{
            //    ApItemName = "Justice's Sword",
            //    GameItemId = "Sword_Justice",
            //    Quantity = 1,
            //},
            new ItemGrant
            {
                ApItemName = "Lightning Blade",
                GameItemId = "Sword_Thunder2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Sun Sword",
                GameItemId = "Sword_Fire",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Frozen Sword Handle",
                GameItemId = "Sword_Ice",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Ludina Blade",
                GameItemId = "Sword_Ice2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Tainted Lesser Warrior's Blade",
                GameItemId = "Sword_Dark_Low",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Aged Leaf Pudding Slice",
                GameItemId = "OldLeafPuddingPart",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "King Queen Pudding",
                GameItemId = "KingQueenPudding",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Tarnished Flame Sword",
                GameItemId = "Sword_FireOff",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Ancient Weapon Recipe",
                GameItemId = "Book_AcientWeapon",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Soul Sword",
                GameItemId = "Sword_Soul",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Tarnished Soul Sword",
                GameItemId = "Sword_SoulOff",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Aimhard's Necklace",
                GameItemId = "AimhardNecklace",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Protein Pudding",
                GameItemId = "PowerPudding",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Ancient Lightning Dragon Horn",
                GameItemId = "AcientLightningDragonHorn",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Giant Zirconia",
                GameItemId = "ZirconinaBig",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Zirconia",
                GameItemId = "Zirconina",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Secret Trader Key",
                GameItemId = "Key_RedBeard",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Ice Witch Scarf",
                GameItemId = "IceScarf",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Ice Giant Head",
                GameItemId = "IceHead",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Ice Core",
                GameItemId = "IceCore",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Schwitz's Arm",
                GameItemId = "IceSharpArm",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Frozen Claw",
                GameItemId = "IceNail",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Frozen Heart",
                GameItemId = "IceHeart",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Glittering Ice",
                GameItemId = "EternalIce",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Temar Summon Sigil",
                GameItemId = "MAGICCIRCLE_Temar",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Promise Potion",
                GameItemId = "WarriorPortion1",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Anticipation Potion",
                GameItemId = "WarriorPortion2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Miracle Potion",
                GameItemId = "WarriorPortion3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Ruaret",
                GameItemId = "Ruaret",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Secondary Equipment Journal",
                GameItemId = "Book_Accessary",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Magic Enhancer",
                GameItemId = "SPGrowth",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Combat Aids Journal",
                GameItemId = "Book_BattleSub",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Chaos Stone Earrings",
                GameItemId = "OrangeConfusingStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Reforgeable Equipment Journal",
                GameItemId = "Book_Reforge",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Light Wooden Shield",
                GameItemId = "Shield_Wood",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Steel Shield",
                GameItemId = "Shield_Iron",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Owl Shield",
                GameItemId = "Shield_Wood_Owl",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Low-Rank Warrior Mark",
                GameItemId = "WarriorMark_Low",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Mid-Rank Warrior Mark",
                GameItemId = "WarriorMark_Mid",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "High-Rank Warrior Mark",
                GameItemId = "WarriorMark_High",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Strength Ring",
                GameItemId = "PowerRing",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Enchanted Ring",
                GameItemId = "MagicRing",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Defense Ring",
                GameItemId = "DefenceRing",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Agility Ring",
                GameItemId = "AgilityRing",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Enhanced Mid-Rank Palace Warrior Sword",
                GameItemId = "Sword_Mid_2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Antler Shield",
                GameItemId = "Shield_Iron_Horn",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Iron Ore",
                GameItemId = "IronOre",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Steam Pipe",
                GameItemId = "SteamPipe",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "High-Rank Warrior Shield",
                GameItemId = "Shield_Iron_High",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Purification Necklace",
                GameItemId = "PureEaring",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Glorious Armor",
                GameItemId = "Armor_IronGlory",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Glorious Shield",
                GameItemId = "Shield_IronGlory",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Glorious Sword",
                GameItemId = "Sword_IronGlory",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Commander's Insignia",
                GameItemId = "LivyaMark",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Rich Pudding Juice",
                GameItemId = "PuddingApple",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Aromatic Meat Pie",
                GameItemId = "MeatPie",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Bane Herb",
                GameItemId = "DarkLeaf",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Zircon Armor",
                GameItemId = "Amor_Zircon",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Zirconia Armor",
                GameItemId = "Amor_Zirconia",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lightning Blade",
                GameItemId = "Sword_Thunder3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Dangerous Journal",
                GameItemId = "Book_Ban",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Ugly Bird Meat",
                GameItemId = "MeatUglyBird",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lightning Blast",
                GameItemId = "Weapon_Stick_Thunder",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Narrel Flesh",
                GameItemId = "NarMeat",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Narrel Scale",
                GameItemId = "NarCover",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lucca Claw",
                GameItemId = "RukaNail",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Carrot",
                GameItemId = "Carrot",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Bedos's Headband",
                GameItemId = "BedosHeadband",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Valor Ring",
                GameItemId = "WarriorRing",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Wisdom Ring",
                GameItemId = "WizardRing",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Eagle Pendant",
                GameItemId = "BraveStep",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Green Rally Pendant",
                GameItemId = "RallyNecklace1",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blue Rally Pendant",
                GameItemId = "RallyNecklace2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Awakening Pendant",
                GameItemId = "WakeUpPendent",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lightning Needle",
                GameItemId = "Weapon_Stick_ThunderNiddle",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Flame Staff",
                GameItemId = "Weapon_Stick_Fire",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Dark Sword",
                GameItemId = "Sword_Dark",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blue Moonstone Staff",
                GameItemId = "BlueMoonStick",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Big Pie",
                GameItemId = "BigPie",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Tough Soup",
                GameItemId = "StrengthSoup",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Nightmare Sword",
                GameItemId = "Sword_Nightmare",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Gravity Stone",
                GameItemId = "GravityStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Crew List",
                GameItemId = "ShipMemberList",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shipwreck Brig Key",
                GameItemId = "Key_ShipPrison",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shadow Shield",
                GameItemId = "Shield_Dark",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Miro's Headband",
                GameItemId = "MiroHairband",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Flame Pendant",
                GameItemId = "FirePendant",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Ice Shield",
                GameItemId = "Shield_Ice",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Red Gem",
                GameItemId = "RedJewel",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Protoype Steam Engine",
                GameItemId = "FirstSteamEngine",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Matt's Letter",
                GameItemId = "GolemBlueprintInfo",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Evolved Lightning Needle",
                GameItemId = "Weapon_Stick_ThunderNiddle2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Evolved Flame Staff",
                GameItemId = "Weapon_Stick_Fire2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "White Wood Staff",
                GameItemId = "Weapon_Stick_WhiteTree",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Budding White Wood Staff",
                GameItemId = "Weapon_Stick_WhiteTree_LIFE",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Water Balloon Frog Mucus",
                GameItemId = "BlueFrogMocus",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Rookveli Crest",
                GameItemId = "RukevalleyMark",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Enhanced High-Rank Warrior Sword",
                GameItemId = "Sword_High2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shipwreck Diary Page 1",
                GameItemId = "JadePaper1",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shipwreck Diary Page 2",
                GameItemId = "JadePaper2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shipwreck Diary Page 3",
                GameItemId = "JadePaper3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shipwreck Diary Page 4",
                GameItemId = "JadePaper4",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shipwreck Diary Page 5",
                GameItemId = "JadePaper5",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shipwreck Diary",
                GameItemId = "JadePaper",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shipwreck Diary Page 6",
                GameItemId = "JadePaper6",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shipwreck Diary Page 7",
                GameItemId = "JadePaper7",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Ecarr Vertel",
                GameItemId = "MAGICCIRCLE_Ekar",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Bundle of Teleportation Talismans",
                GameItemId = "WarpPapers",
                Quantity = 1,
            },
            //new ItemGrant
            //{
            //    ApItemName = "Blue Horn Staff",
            //    GameItemId = "Weapon_Stick_WhiteWoodBlue",
            //    Quantity = 1,
            //},
            new ItemGrant
            {
                ApItemName = "Weapon Stimulant",
                GameItemId = "WeaponCooler",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Pick-me-up",
                GameItemId = "EnergyDrink",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Zirconia Dragon Egg",
                GameItemId = "ZirconiaEgg",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Zirconia Junior",
                GameItemId = "ZirconiaJunior",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Weapon Stimulant",
                GameItemId = "WeaponCooler2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Flaming Budding White Wood Staff",
                GameItemId = "Weapon_Stick_WhiteTree_LIFE_FIRE",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Frozen Key",
                GameItemId = "Key_Ice",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Starlight White Wood Staff",
                GameItemId = "Weapon_Stick_WhiteTree_SP",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "White Wood Club",
                GameItemId = "Weapon_Stick_WhiteTree_STR",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Flaming Starlight White Wood Staff",
                GameItemId = "Weapon_Stick_WhiteTree_SP_FIRE",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Flaming White Wood Club",
                GameItemId = "Weapon_Stick_WhiteTree_STR_FIRE",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blue Firestone",
                GameItemId = "SoulFireStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Ra Za'rrel",
                GameItemId = "Sword_LaZarel",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Esteran",
                GameItemId = "Sword_Esteran",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Red Potion",
                GameItemId = "WarriorPotionHP",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Mind Cleanser",
                GameItemId = "WarriorPotionMP",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Great Key",
                GameItemId = "Key_Big",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Kreytes Berry",
                GameItemId = "CreichApple",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Magic Stimulant",
                GameItemId = "MagicStimulus",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Red Shieldstone",
                GameItemId = "ShieldStoneRed",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Genesis Blessing",
                GameItemId = "GuardianPendant",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Red Shieldstone",
                GameItemId = "ShieldStoneRed2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Red Berry White",
                GameItemId = "RedBerryWhite",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Red Berry Blossom",
                GameItemId = "RedBerryBlossom",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Black Pearl Mini",
                GameItemId = "BlackPearlMini",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Deep Black Pearl",
                GameItemId = "BlackPearlDeep",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Silver Rose Seed",
                GameItemId = "RoseIronSeed",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Silver Rose Knight",
                GameItemId = "RoseIronKnight",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shining Dawn Princess",
                GameItemId = "ShiningDawnPrincess",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Shining Dawn Angel",
                GameItemId = "ShiningDawnAngel",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Strength Amplifier",
                GameItemId = "PowerStimuler",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Mind Stimulator",
                GameItemId = "MagicStimuler",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Silver Feather",
                GameItemId = "CloudShoes",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Flower of Repose",
                GameItemId = "RestFlower",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Gilded Chalice",
                GameItemId = "GoldenGrail",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Extreme Ludina Blade",
                GameItemId = "Sword_Ice3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blazing Sun Sword",
                GameItemId = "Sword_Fire2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Rampaging Nightmare Blade",
                GameItemId = "Sword_Nightmare2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Assembly of Tainted Souls",
                GameItemId = "RedFreeStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Black Horn Club",
                GameItemId = "Weapon_Stick_WhiteTree_STR_2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Earth Staff",
                GameItemId = "Weapon_Stick_WhiteTree_SP_2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blue Flower Staff",
                GameItemId = "Weapon_Stick_WhiteTree_LIFE_2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lightning Lance",
                GameItemId = "Weapon_Stick_ThunderNiddle3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Fire Wings",
                GameItemId = "Weapon_Stick_Fire3",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Small Guardian Shards",
                GameItemId = "SmalGuardian",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Heart of Fury",
                GameItemId = "AngryHeart",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Binding Gloves",
                GameItemId = "GuardianGlove",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Guardian Stone",
                GameItemId = "BigGuardian",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Nessie's Egg",
                GameItemId = "NeciEgg",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Deepstone",
                GameItemId = "WhiteDeepStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "White Rhino's Black Horn",
                GameItemId = "BlackRihnoHorn",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blue Flower Seed",
                GameItemId = "BlueFlowerSeed",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Eiger",
                GameItemId = "Shield_Eiger",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Onyx",
                GameItemId = "Shield_Onix",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lightning Crystal",
                GameItemId = "LightningCrystal",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Flame Vessel",
                GameItemId = "FireCrystal",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Livya's Special Uniform",
                GameItemId = "LivyaDress",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Dragon Taming Rod",
                GameItemId = "DragonStick",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Nivisus Horn",
                GameItemId = "NavisusHorn",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Blue Twin Moonstone Staff",
                GameItemId = "BlueMoonStick2",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Silver Esteran",
                GameItemId = "EsteranSpecial",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Wolf Meat",
                GameItemId = "WolfMeat",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Scorpion Tail",
                GameItemId = "ScorpionTail",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Giant Scorpion Tail",
                GameItemId = "ScorpionTailBig",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Magic Dew",
                GameItemId = "BallBatOrb",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Gold Nugget",
                GameItemId = "Massgold",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Kentz Stone",
                GameItemId = "KenchStone",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Kentz Luster",
                GameItemId = "KenLights",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Kentz Leaf",
                GameItemId = "KenchStoneLeaf",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Brilliant Blue Crystal",
                GameItemId = "BrightBlueCrystal",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Mintgel Fragment",
                GameItemId = "MintJellPortion",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Redgel Fragment",
                GameItemId = "RedJellPortion",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Lambette Peach",
                GameItemId = "Lambette",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Sheeplie Peach",
                GameItemId = "Sheeplie",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Aimhard Blessing",
                GameItemId = "Bless_Aimhard",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Durok Blessing",
                GameItemId = "Bless_Durok",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Elision Blessing",
                GameItemId = "Bless_Elicion",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Arua Arrow Blessing",
                GameItemId = "Bless_AruaArrow",
                Quantity = 1,
            },
            new ItemGrant
            {
                ApItemName = "Arua Thunder Blessing",
                GameItemId = "Bless_AruaThunder2",
                Quantity = 1,
            },
        };

    }
}