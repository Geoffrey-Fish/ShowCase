using static System.Console;

namespace RPGOne
    {
    /// <summary>
    /// Room class contains everything about the rooms of the game
    /// </summary>
    public class Room
        {
        //Declaration of parameters for each room, is for besser acessibility
        public string name { get; set; }
        public string description { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public int mapX { get; set; }
        public int mapY { get; set; }
        public List<Character> npcs { get; set; }
        public List<Item> items { get; set; }
        public List<Weapon> weapons { get; set; }
        public List<Armor> armors { get; set; }


        /// <summary>
        /// Constructor for new rooms in the game
        /// </summary>
        /// <param name="name">Room name</param>
        /// <param name="desc">Description</param>
        /// <param name="posX">Position X on the grid</param>
        /// <param name="posY">Position Y on the grid</param>
        /// <param name="mapX">Position X on the map</param> Map X and Y are for the grafical map
        /// <param name="mapY">Position Y on the map</param> For easier Info manipulation.So the map can grow in any Direction.
        /// <param name="npcs"> NPCS in the room</param>
        /// <param name="items">What lays around</param>
        /// <param name="weapons">What lays around</param>
        /// <param name="armors">What lays around</param>
        public Room(string name,string desc,int posX,int posY,int mapX,int mapY,List<Character> npcs,List<Item> items,List<Weapon> weapons,List<Armor> armors)
            {
            this.name = name;
            this.description = desc;
            this.posX = posX;
            this.posY = posY;
            this.mapX = mapX;
            this.mapY = mapY;
            this.npcs = npcs;
            this.items = items;
            this.weapons = weapons;
            this.armors = armors;
            }


        /// <summary>
        /// Gives info about current room
        /// </summary>
        public void Status()
            {
            Clear();
            WriteLine("------------------------------------------");
            WriteLine(name);
            WriteLine(description);
            WriteLine("ROOM: X: " + posX.ToString());
            WriteLine("ROOM: Y: " + posY.ToString());
            WriteLine("YOU SEE: ");
            if(npcs.Count > 0)
                {
                WriteLine("------");
                WriteLine("PERSONS: ");
                foreach(var npc in npcs)
                    {
                    WriteLine(npc.name);
                    WriteLine("\nTHE " + npc.name + " SAYS: " + npc.dialog + "\n");
                    }
                }
            if(items.Count > 0)
                {
                WriteLine("------");
                WriteLine("ITEMS: ");
                foreach(var item in items)
                    {
                    WriteLine(item.name);
                    }
                }
            if(weapons.Count > 0)
                {
                WriteLine("------");
                WriteLine("WEAPONS: ");
                foreach(var weapon in weapons)
                    {
                    WriteLine(weapon.name);
                    }
                }
            if(armors.Count > 0)
                {
                WriteLine("------");
                WriteLine("ARMORS: ");
                foreach(var armor in armors)
                    {
                    WriteLine(armor.name);
                    }
                }
            }


        /// <summary>
        /// Location request returns correct room
        /// </summary>
        /// <param name="x">players current posX</param>
        /// <param name="y">players current posY</param>
        /// <returns>Room object</returns>
        public static string Locate(int x,int y)
            {
            foreach(var room in rooms)
                {
                if(room.posX == x && room.posY == y)
                    {
                    return room.name;
                    }
                }
            return null;
            }

        //Invocation of the rooms we are in.
        public static Room start_room = new Room("START ROOM","THIS IS THE STARTING ROOM",0,0,4,1,new List<Character> { Character.friendly_wizard },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room foe_room = new Room("ORC FOE ROOM","THIS IS THE ORC FOE ROOM",0,1,3,1,new List<Character> { Character.orc_peon },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room gem_room = new Room("GEM ROOM","THIS IS THE GEM ROOM",0,-1,5,1,new List<Character> { },new List<Item> { Item.gem,Item.gem,Item.gem },new List<Weapon> { },new List<Armor> { });
        public static Room orc_room = new Room("ORC ROOM","THIS IS AN ORC ROOM",0,2,2,1,new List<Character> { Character.orc_baba },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room rat_room = new Room("RAT ROOM","LOOK! THE RAT MAN!",1,0,4,1,new List<Character> { Character.rat_man },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room stor = new Room("STORE","BUY IT NOW!",1,1,3,2,new List<Character> { Character.store_clerk },new List<Item> { Item.minor_health,Item.minor_health,Item.poison },new List<Weapon> { Weapon.short_sword,Weapon.stick },new List<Armor> { Armor.leather_armor,Armor.cloth_robe,Armor.towel });
        // the store is a class for itself...

        //these are just blockers, to be reworked laterwith waypoint tips
        public static Room wallm1m1 = new Room("WALL","NO WAY,TURN AROUND",-1,-1,5,0,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room wall1m1 = new Room("WALL","NO WAY,TURN AROUND",1,-1,5,2,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room wallm10 = new Room("WALL","NO WAY,TURN AROUND",-1,0,4,0,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room wallm11 = new Room("WALL","NO WAY,TURN AROUND",-1,1,3,0,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room wallm12 = new Room("WALL","NO WAY,TURN AROUND",-1,2,2,0,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room wall12 = new Room("WALL","NO WAY,TURN AROUND",1,2,2,2,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room wall03 = new Room("WALL","NO WAY,TURN AROUND",0,3,1,1,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room wall0m2 = new Room("WALL","NO WAY,TURN AROUND",0,-2,6,1,new List<Character> { },new List<Item> { },new List<Weapon> { },new List<Armor> { });

        public static List<Room> rooms = new List<Room> { start_room,foe_room,gem_room,orc_room,rat_room,stor,wallm1m1,wall1m1,wallm10,wallm11,wallm12,wall12,wall03,wall0m2 };

        }
    }
