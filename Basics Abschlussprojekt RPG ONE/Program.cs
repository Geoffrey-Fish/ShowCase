using static System.Console;


namespace RPGOne
    {
    class Program
        {
        /// <summary>
        /// Where the magic happens
        /// </summary>
        /// <param name="args">AAAAARRRRGHHH</param>
        static void Main(string[] args)
            {
            WriteLine("Proof of Concept for a simple CLI Dungeon adventure.\n" +
                "I had the Idea for it a year ago\n" +
                "as I started to learn coding with Python.\n" +
                "Now, I rewrote every bit and translated it into C# logic.\n\n" +
                "Dear FABIAN MEINEL,\n" +
                "Please set your terminal window to full height,\n" +
                "or else you might miss some outputs.\n" +
                "Have fun!");
            Write("Continue with any key ==>");
            ReadKey();
            Clear();

            WriteLine("This is RPG One. A solo Adventure.\n");

            WriteLine("Welcome, stranger...");
            WriteLine("------------------------------------------");
            Thread.Sleep(2000);

            //Main loop
            while(true)
                {
                Player player = new Player();
                Narrative.Welcome(player);
                Narrative.StartingRoom(player);
                Thread.Sleep(1000);
                Grid(player);
                }
            }


        /// <summary>
        /// Secret main loop, check position of player and reacts accordingly
        /// </summary>
        /// <param name="rooms">The Room the player walked in</param>
        /// <param name="player">Captain Obvious</param>
        public static void Grid(Player player)
            {
            // Find the room that the player is in
            Room currentRoom = null;
            foreach(Room room in rooms)
                {
                if(room.posX == player.posX && room.posY == player.posY)
                    {
                    currentRoom = room;
                    break;
                    }
                }
            if(currentRoom == null)
                {
                // The player is not in any room
                WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                WriteLine("LOOKS LIKE YOU ARE TRAPPED IN THE VOID.\n" +
                    "MAYBE YOU SHOULD LOOK AT YOUR MAP MORE OFTEN!\n" +
                    "SORRY PAL, I PUSH YOU BACK TO START!.");
                WriteLine("M'KAY?");
                Write("Push a button ==> ");
                ReadKey();
                player.posX = 0;
                player.posY = 0;
                Grid(player);
                }
            else if(currentRoom.posX == 1 && currentRoom.posY == 1)
                {
                //Give current map pointers to map for unhiding new encountered rooms
                Map.Path(currentRoom.mapX,currentRoom.mapY);
                Store.status(player);
                }
            else
                {
                Clear();
                WriteLine("------------------------------------------");
                currentRoom.Status();
                //Give current map pointers to map for unhiding new encountered rooms
                Map.Path(currentRoom.mapX,currentRoom.mapY);
                foreach(var npc in currentRoom.npcs)
                    {
                    if(npc.friend == false)
                        {
                        Battles.Battle(npc,player,currentRoom);
                        }
                    }
                }
            //Give current map pointers to map for unhiding new encountered rooms
            Map.Path(currentRoom.mapX,currentRoom.mapY);
            Options(currentRoom,player);
            }


        /// <summary>
        /// Options is an interactive tool for the player to navigate the game
        /// </summary>
        /// <param name="room">the current room and its position</param>
        /// <param name="player">The Player himself in all his glory</param>
        public static void Options(Room room,Player player)
            {
            WriteLine("MOVE:\n" +
                "|(N)ORTH\n" +
                "|(E)AST\n" +
                "|(S)OUTH\n" +
                "|(W)EST\n" +
                "|-------\n" +
                "|(L)OOK AT YOUR STATS!\n" +
                "|(R)OOM CONTENTS!\n" +
                "|(M)AP!\n" +
                "|(I)NVENTORY!\n" +
                "|-------\n" +
                "|(Q)UIT GAME...\n" +
                "|-------");

            //build a stringArray and give it as possible choices.UserInput will check validity
            string[] choices = new string[] { "N","E","S","W","L","R","M","I","Q" };
            string user_input = player.UserInput(choices);

            if(user_input == "N")
                {
                player.posY += 1;
                Grid(player);
                }
            else if(user_input == "S")
                {
                player.posY -= 1;
                Grid(player);
                }
            else if(user_input == "W")
                {
                player.posX -= 1;
                Grid(player);
                }
            else if(user_input == "E")
                {
                player.posX += 1;
                Grid(player);
                }
            else if(user_input == "L")
                {
                WriteLine("LOOK AT YOU!");
                player.Status();
                WriteLine("------------------------------------------");
                Options(room,player);
                }
            else if(user_input == "R")
                {
                room.Status();
                /*print(Room.status(room) maybe
                 a function in rooms for locating the player
                 and return the corresponding room?*/
                Options(room,player);
                }
            else if(user_input == "M")
                {
                Map.Plan(room,player);
                Options(room,player);
                }
            else if(user_input == "I")
                {
                player.Inventory(room,player);
                Options(room,player);
                }
            else if(user_input == "Q")
                {
                GameOver();
                }
            else
                {
                WriteLine("DUDE, WRONG INPUT!!!");
                // maybe here after choose drop,pick up?
                WriteLine("------------------------------------------");
                Options(room,player);
                }
            }


        /// <summary>
        /// Exit function
        /// </summary>
        public static void GameOver()
            {
            Clear();
            WriteLine("THANK YOU FOR PLAYING\n" +
                "RPG ONE V1.1\n" +
                "by Geoffrey Fish 2023\n" +
                "\n" +
                "GOODBYE!\n\n" +
                "PLEASE PRESS ANY KEY TO GET OUT OF HERE.");
            ReadKey();
            Environment.Exit(0);
            }


        //Todo: needs to be better hidden
        /// <summary>
        ///Invocation of the rooms we are in.
        ///</summary>
        public static Room start_room = new Room("START ROOM","THIS IS THE STARTING ROOM",0,0,4,1,new List<Character> { Character.friendly_wizard },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room foe_room = new Room("ORC FOE ROOM","THIS IS THE ORC FOE ROOM",0,1,3,1,new List<Character> { Character.orc_peon },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room gem_room = new Room("GEM ROOM","THIS IS THE GEM ROOM",0,-1,5,1,new List<Character> { },new List<Item> { Item.gem,Item.gem,Item.gem },new List<Weapon> { },new List<Armor> { });
        public static Room orc_room = new Room("ORC ROOM","THIS IS AN ORC ROOM",0,2,2,1,new List<Character> { Character.orc_baba },new List<Item> { },new List<Weapon> { },new List<Armor> { });
        public static Room rat_room = new Room("RAT ROOM","LOOK! THE RAT MAN!",1,0,4,2,new List<Character> { Character.rat_man },new List<Item> { },new List<Weapon> { },new List<Armor> { });
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


        /// <summary>
        /// Main List of the rooms
        /// </summary>
        public static List<Room> rooms = new List<Room> { start_room,foe_room,gem_room,orc_room,rat_room,stor,wallm1m1,wall1m1,wallm10,wallm11,wallm12,wall12,wall03,wall0m2 };

        ///////////////
        ///End Tags///
        /////////////
        }
    }

// TODO: Make wall rooms for not going into the abyss
//maybe give possible directions in the rooms if looked at?
//give hints about a store
//need interaction and talk with npcs
//use of health potions
//maybe even a game break for drinking with an alert or so
//whilst in fight - better than dying, right ?
//exit method ?