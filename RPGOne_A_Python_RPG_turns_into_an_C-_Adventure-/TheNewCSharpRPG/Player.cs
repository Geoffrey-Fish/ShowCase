using static System.Console;

namespace RPGOne
    {/// <summary>
     /// It is more fun to be a Player, ayght? ^^
     /// </summary>
    public class Player
        {
        //todo: include weight and think about
        //todo: dmg and ar
        public string name = "PLAYER";
        public int posX = 0;
        public int posY = 0;
        public int? max_hp = null;
        public int hp = 0;
        public int xp = 0;
        public int gp = 10;
        public int st = 0; //ToDo: Strength for Weight Calculations!
        public int dex = 0;
        public List<Item> items = new List<Item>();
        public List<Weapon> weapons = new List<Weapon> { };
        public List<Armor> armors = new List<Armor> { };
        public int dmg; //defined by weapon
        public int ar; //defined by armor


        /// <summary>
        /// Create Method is interactive
        /// </summary>
        /// <param name="Player">Empty object</param>
        public Player()
            {
            //Do while for creation. Only full rolled char may start
            bool creation = false;
            WriteLine("CREATING YOUR CHARACTER:");
            WriteLine("PLEASE CHOOSE A NAME AND ROLL YOUR STATS!");
            WriteLine("''''''''''''''''''''''''''''''''''''''''''");
            do
                {
                WriteLine("(N)AME YOUR CHARACTER");
                WriteLine("(R)OLL YOUR CHARACTER");
                WriteLine("(P)LAY GAME");
                Write("==> ");
                string[] choice = new string[] { "N","R","P" };
                string? user_input = UserInput(choice);

                switch(user_input)
                    {
                    case "N":
                        WriteLine("WHAT IS YOUR NAME?");
                        Write("=>>");
                        string? name = ReadLine().ToUpper().Trim();
                        this.name = name;
                        WriteLine($"{name}?\n" +
                            $"SOUNDS ABOUT RIGHT.");
                        Thread.Sleep(1000);
                        Clear();
                        break;

                    case "R":
                        WriteLine("-------------------------");
                        WriteLine("LET'S SEE YOUR HEALTH...");
                        WriteLine("ROLLING HP...");
                        Thread.Sleep(1000);
                        int roll = RollDice(30,60);
                        hp = roll;
                        WriteLine($"YOU START WITH: {hp} HP!\n" +
                            $"SO YOUR HP CAP IS: {max_hp = hp + 20}");
                        Thread.Sleep(1000);

                        WriteLine("------------------------------");
                        WriteLine("LET'S SEE YOUR MUSCLES THEN...");
                        WriteLine("ROLLING...");
                        Thread.Sleep(1000);
                        roll = RollDice(20,60);
                        st = roll;
                        WriteLine($"YOUR POWER IS {st} !");
                        Thread.Sleep(1000);

                        WriteLine("-------------------------");
                        WriteLine("AT LAST YOUR DEXTERITY...");
                        WriteLine("ROLLING...");
                        Thread.Sleep(1000);
                        roll = RollDice(20,60);
                        dex = roll;
                        WriteLine($"{dex} IS YOUR DEXTERITY.");
                        WriteLine("-------------------------");
                        break;

                    case "P":
                        if(this.name is "PLAYER" || hp is 0)
                            {
                            Clear();
                            WriteLine("FINISH MAKING YOUR CHARACTER!");
                            WriteLine("-----------------------------");
                            break;
                            }
                        else
                            {
                            //And don't let that poor fella walk naked!
                            items.Add(Item.minor_health);
                            weapons.Add(Weapon.short_sword);
                            armors.Add(Armor.towel);
                            dmg = weapons[0].dmgValue;
                            ar = armors[0].arValue;


                            //Everything is ok, lets go and end the do while loop
                            WriteLine("HAVE FUN PLAYING THE GAME AND DON'T DIE!");
                            Thread.Sleep(2000);
                            creation = true;
                            }
                        break;
                    default:
                        WriteLine("INVALID!\nCHOOSE AN OPTION:\n 'N', 'R' OR 'P'");
                        WriteLine("---------------------");
                        break;
                    }
                } while(!creation);
            }

        /// <summary>
        /// Takes Userinput, checks and converts it and returns the value
        /// </summary>
        /// <param name="array">Possible chars given</param>
        /// <returns>Chosen char</returns>
        public string UserInput(string[] array)
            {
            string? user_input = ReadLine().ToUpper().Trim();
            if(!array.Contains(user_input))
                {
                WriteLine("WRONG INPUT.");
                Write("==>");
                UserInput(array);
                }
            return user_input;
            }


        //todo: include weight
        /// <summary>
        /// Show actual status of Player
        /// </summary>
        public void Status()
            {
            Clear();
            WriteLine("-------POSITION---------");
            WriteLine($"YOU ARE IN THE {Room.Locate(posX,posY)}");
            WriteLine(name + "`S POS X: " + posX);
            WriteLine(name + "`S POS Y: " + posY);

            WriteLine("-------STATS------------");
            WriteLine($"HEALTH: {hp} OF: {max_hp}");
            WriteLine("STRENGTH: " + st);
            WriteLine("DEXTERITY: " + dex);
            WriteLine("DAMAGE: " + dmg);
            WriteLine("DEFENCE: " + ar);
            WriteLine("EXPIERIENCE: " + xp);
            WriteLine("GOLD: " + gp);

            if(items.Count > 0)
                {
                WriteLine("---------------------");
                WriteLine("YOUR BAG CONTAINS: ");
                foreach(Item item in items)
                    {
                    WriteLine(item.name);
                    }
                }
            if(weapons.Count > 0)
                {
                WriteLine("---------------------");
                WriteLine("YOUR WEAPONS: ");
                foreach(Weapon weapon in weapons)
                    {
                    WriteLine(weapon.name);
                    }
                }
            if(armors.Count > 0)
                {
                WriteLine("---------------------");
                WriteLine("YOUR ARMOR: ");
                foreach(Armor armor in armors)
                    {
                    WriteLine(armor.name);
                    }
                }
            WriteLine("---------------------");
            }


        /// <summary>
        /// Personal Dice machine
        /// </summary>
        /// <param name="name">Playername</param>
        /// <param name="min">min value</param>
        /// <param name="max">max value -1</param>
        /// <returns></returns>
        public int RollDice(int min,int max)
            {
            Random Dice = new Random();
            int roll = Dice.Next(min,max);
            WriteLine($"{name} ROLLED: {roll}");
            return roll;
            }


        //todo: weapon and armor choose for active weapon
        /// <summary>
        /// To look at the inventory and interact with its contents
        /// todo: the weight might play here also!
        /// </summary>
        /// <param name="room"> The room the player is at</param>
        /// <param name="player">The player</param>
        public void Inventory(Room room,Player player)
            {
            Clear();
            WriteLine("INVENTORY OPTIONS:\n" +
                "| (P)ICK UP\n" +
                "| (D)ROP\n" +
                "| (B)ACK");
            Write("==> ");
            string[] choice = new string[] { "P","D","B" };
            string user_input = UserInput(choice);

            if(user_input == "P")
                {
                if(room.items.Count == 0 && room.weapons.Count == 0 && room.armors.Count == 0)
                    {
                    WriteLine("SORRY,BUT THIS ROOM IS EMPTY!");
                    Program.Options(room,player);
                    }
                WriteLine("LOOK FOR:\n|(I)TEMS\n|(W)EAPONS\n|(A)RMORS");
                Write("==>");
                string[] choice0 = new string[] { "I","W","A" };
                string user_input0 = UserInput(choice0);

                if(user_input0 == "I" && room.items.Count > 0)
                    {
                    WriteLine("LOOK AT THE ITEMS HERE:");
                    Thread.Sleep(500);
                    PickUpItems(room,room.items,items);
                    }
                else if(user_input0 == "W" && room.weapons.Count > 0)
                    {
                    WriteLine("WHAT ABOUT THESE WEAPONS?");
                    Thread.Sleep(500);
                    PickUpWeapons(room,room.weapons,weapons);
                    }
                else if(user_input0 == "A" && room.armors.Count > 0)
                    {
                    WriteLine("SOME ARMOR, MAYBE?");
                    Thread.Sleep(500);
                    PickUpArmors(room,room.armors,armors);
                    }
                else
                    {
                    WriteLine("HOW OFTEN WILL THIS HAPPEN?");
                    Inventory(room,this);
                    }
                }

            else if(user_input == "D")
                {
                if(player.items.Count == 0 && player.weapons.Count == 0 && player.armors.Count == 0)
                    {
                    WriteLine("SORRY,BUT YOU ARE NEKKID, LOL");
                    }
                Drop(room);
                }

            else if(user_input == "B")
                {
                WriteLine("GOING BACK TO MOVEMENT MENU");
                Program.Options(room,player);
                }
            }

        ///The comments in this block stand for the weapons and armors,too!
        ///
        /// <summary>
        /// Pick valuable Items from the Floor
        /// </summary>
        /// <param name="room">The Room you are at</param>
        /// <param name="roomObjList">The items in the room</param>
        /// <param name="playerObjList">Players bag</param>
        void PickUpItems(Room room,List<Item> roomObjList,List<Item> playerObjList)
            {
            //Is there anything
            if(roomObjList.Count > 0)
                {
                //is it more than one so u cam iterate
                if(roomObjList.Count > 1)
                    {
                    foreach(Item obj in roomObjList)
                        {
                        WriteLine(obj.name);
                        WriteLine("|(P)ICK UP?\n|(N)EXT?\n|(B)ACK?");
                        Write("==>");
                        string[] choice = new string[] { "P","N","B" };
                        string userInput = UserInput(choice);

                        if(userInput == "P")
                            {
                            WriteLine(name + " PICKS UP " + obj.name);
                            Item iChanger = obj;
                            roomObjList.Remove(obj);
                            playerObjList.Add(iChanger);
                            Inventory(room,this);
                            }
                        else if(userInput == "N")
                            {
                            continue;
                            }
                        else if(userInput == "B")
                            {
                            Inventory(room,this);
                            }
                        }
                    Inventory(room,this);
                    }
                //if its just one item, take it or not
                else if(roomObjList.Count == 1)
                    {
                    WriteLine(roomObjList[0].name);
                    WriteLine("|(P)ICK UP?\n|(B)ACK?");
                    Write("==>");
                    string[] choice = new string[] { "P","B" };
                    string userInput = UserInput(choice);
                    if(userInput == "P")
                        {
                        WriteLine(name + " PICKS UP " + roomObjList[0].name);
                        Item iChanger = roomObjList[0];
                        roomObjList.RemoveAt(0);
                        playerObjList.Add(iChanger);
                        Inventory(room,this);
                        }
                    else if(userInput == "B")
                        {
                        return;
                        }
                    Inventory(room,this);
                    }
                }
            else
                {
                //Give an alternative choice of action
                WriteLine("THERE IS NOTHING!WANNA DROP INSTEAD?\n|(Y)ES\n|(N)O");
                Write("==>");
                string[] choice = new string[] { "Y","N" };
                string userInput = UserInput(choice);
                if(userInput == "Y")
                    {
                    Drop(room);
                    }
                else if(userInput == "N")
                    {
                    Inventory(room,this);
                    }
                }
            }


        /// <summary>
        /// Pick valuable Weapons from the Floor
        /// </summary>
        /// <param name="room">The Room you are at</param>
        /// <param name="roomObjList">The weapons in the room</param>
        /// <param name="playerObjList">Players bag</param>
        void PickUpWeapons(Room room,List<Weapon> roomObjList,List<Weapon> playerObjList)
            {
            if(roomObjList.Count > 0)
                {
                if(roomObjList.Count > 1)
                    {
                    foreach(Weapon obj in roomObjList)
                        {
                        WriteLine(obj.name);
                        WriteLine("|(P)ICK UP?\n|(N)EXT?\n|(B)ACK?");
                        Write("==>");
                        string[] choice = new string[] { "P","N","B" };
                        string userInput = UserInput(choice);

                        if(userInput == "P")
                            {
                            WriteLine(name + " PICKS UP " + obj.name);
                            Weapon wChanger = obj;
                            roomObjList.Remove(obj);
                            playerObjList.Add(wChanger);
                            Inventory(room,this);
                            }
                        else if(userInput == "N")
                            {
                            continue;
                            }
                        else if(userInput == "B")
                            {
                            Inventory(room,this);
                            }
                        }
                    Inventory(room,this);
                    }
                else if(roomObjList.Count == 1)
                    {
                    WriteLine(roomObjList[0].name);
                    WriteLine("|(P)ICK UP?\n|(B)ACK?");
                    Write("==>");
                    string[] choice = new string[] { "P","B" };
                    string userInput = UserInput(choice);

                    if(userInput == "P")
                        {
                        WriteLine(name + " PICKS UP " + roomObjList[0].name);
                        Weapon wChanger = roomObjList[0];
                        roomObjList.RemoveAt(0);
                        playerObjList.Add(wChanger);
                        Inventory(room,this);
                        }
                    else if(userInput == "B")
                        {
                        Inventory(room,this);
                        }
                    }
                }
            else
                {
                WriteLine("THERE IS NOTHING!WANNA DROP INSTEAD?\n|(Y)ES\n|(N)O");
                Write("==>");
                string[] choice = new string[] { "Y","N" };
                string userInput = UserInput(choice);

                if(userInput == "Y")
                    {
                    Drop(room);
                    }
                else if(userInput == "N")
                    {
                    Inventory(room,this);
                    }
                }
            }


        /// <summary>
        /// Pick valuable Armor from the Floor
        /// </summary>
        /// <param name="room">The Room you are at</param>
        /// <param name="roomObjList">The Armor in the room</param>
        /// <param name="playerObjList">Players bag</param>
        void PickUpArmors(Room room,List<Armor> roomObjList,List<Armor> playerObjList)
            {
            if(roomObjList.Count > 0)
                {
                if(roomObjList.Count > 1)
                    {
                    foreach(Armor obj in roomObjList)
                        {
                        WriteLine(obj.name);
                        WriteLine("|(P)ICK UP?\n|(N)EXT?\n|(B)ACK?");
                        Write("==>");
                        string[] choice = new string[] { "P","N","B" };
                        string userInput = UserInput(choice);

                        if(userInput == "P")
                            {
                            WriteLine(name + " PICKS UP " + obj.name);
                            Armor aChanger = obj;
                            roomObjList.Remove(obj);
                            playerObjList.Add(aChanger);
                            Inventory(room,this);
                            }
                        else if(userInput == "N")
                            {
                            continue;
                            }
                        else if(userInput == "B")
                            {
                            Inventory(room,this);
                            }
                        }
                    Inventory(room,this);
                    }
                else if(roomObjList.Count == 1)
                    {
                    WriteLine(roomObjList[0].name);
                    WriteLine("|(P)ICK UP?\n|(B)ACK?");
                    Write("==>");
                    string[] choice = new string[] { "P","B" };
                    string userInput = UserInput(choice);

                    if(userInput == "P")
                        {
                        WriteLine(name + " PICKS UP " + roomObjList[0].name);
                        Armor aChanger = roomObjList[0];
                        roomObjList.RemoveAt(0);
                        playerObjList.Add(aChanger);
                        Inventory(room,this);
                        }
                    else if(userInput == "B")
                        {
                        Inventory(room,this);
                        }
                    }
                }
            else
                {
                WriteLine("THERE IS NOTHING!WANNA DROP INSTEAD?\n|(Y)ES\n|(N)O");
                Write("==>");
                string[] choice = new string[] { "Y","N" };
                string userInput = UserInput(choice);

                if(userInput == "Y")
                    {
                    Drop(room);
                    }
                else if(userInput == "N")
                    {
                    Inventory(room,this);
                    }
                }
            }


        /// <summary>
        /// Drop Function for throwing stuff away- wait till the player sees how much money he could make at the store...hehehe...
        /// </summary>
        /// <param name="room">The room to be littered</param>
        void Drop(Room room)
            {
            if(items.Count == 0 && weapons.Count == 0 && armors.Count == 0)
                {
                WriteLine("OH BOY,HOW DID YOU GET NEKKID???CYA...");
                Program.Grid(this);
                }
            WriteLine("DROP:\n|(I)TEM ? \n|(W)EAPON ?\n|(A)RMOR ?");
            Write("==>");
            string[] choice = new string[] { "I","W","A" };
            string userInput = UserInput(choice);
            //The following comments are for every choice, item,weapon or armor
            //Item drop
            if(userInput == "I")
                {
                //Bag empty? Safe out
                if(items.Count == 0)
                    {
                    WriteLine("YOU HAVE NO ITEMS.");
                    Inventory(room,this);
                    }
                WriteLine("DROPPING ITEM");
                //More than one on the list? Loop through, else it would crash here
                if(items.Count > 1)
                    {
                    foreach(Item item in items)
                        {
                        WriteLine("DROPPING " + item.name);
                        WriteLine("YOU SURE?\n|(Y)ES\n|(N)O");
                        Write("==>");
                        string[] choice2 = new string[] { "Y","N" };
                        string input = UserInput(choice2);
                        if(input == "Y")
                            {
                            //Again the Changer trick for working with List Item changes
                            Item iChanger = item;
                            items.Remove(item);
                            room.items.Add(iChanger);
                            Drop(room);
                            }
                        else if(input == "N")
                            {
                            continue;
                            }
                        else
                            {
                            WriteLine("WRONG INPUT, DUDE.");
                            Drop(room);
                            }
                        }
                    //safe out after looped through
                    Drop(room);
                    }
                //Else the same procedure if only one Item in the list
                else if(items.Count == 1)
                    {
                    WriteLine("DROPPING " + items[0].name);
                    WriteLine("YOU SURE?\n|(Y)ES\n|(N)O");
                    Write("==>");
                    string[] choice2 = new string[] { "Y","N" };
                    string input = UserInput(choice2);
                    if(input == "Y")
                        {
                        Item iChanger = items[0];
                        items.RemoveAt(0);
                        room.items.Add(iChanger);
                        Drop(room);
                        }
                    else if(input == "N")
                        {
                        //go back if no,nothing else possible
                        Drop(room);
                        }
                    else
                        {
                        WriteLine("WRONG INPUT, DUDE.");
                        Drop(room);
                        }
                    }
                }

            //Weapon drop
            else if(userInput == "W")
                {
                if(weapons.Count == 0)
                    {
                    WriteLine("YOU DON'T HAVE WEAPONS.");
                    Drop(room);
                    }

                WriteLine("DROPPING WEAPONS:");
                if(weapons.Count > 1)
                    {
                    foreach(Weapon weapon in weapons)
                        {
                        WriteLine("DROPPING " + weapon.name);
                        WriteLine("YOU SURE?\n|(Y)ES\n|(N)O");
                        Write("==>");
                        string[] choice3 = new string[] { "Y","N" };
                        string input = UserInput(choice3);
                        if(input == "Y")
                            {
                            Weapon wChanger = weapon;
                            weapons.Remove(weapon);
                            room.weapons.Add(wChanger);
                            Drop(room);
                            }
                        else if(input == "N")
                            {
                            continue;
                            }
                        else
                            {
                            WriteLine("WRONG INPUT, DUDE.");
                            Drop(room);
                            }
                        }
                    Drop(room);
                    }

                else if(weapons.Count == 1)
                    {
                    WriteLine("DROPPING " + weapons[0]);
                    WriteLine("YOU SURE?\n|(Y)ES\n|(N)O");
                    Write("==>");
                    string[] choice3 = new string[] { "Y","N" };
                    string input = UserInput(choice3);
                    if(input == "Y")
                        {
                        Weapon wChanger = weapons[0];
                        weapons.RemoveAt(0);
                        room.weapons.Add(wChanger);
                        Drop(room);
                        }
                    else if(input == "N")
                        {
                        Drop(room);
                        }
                    else
                        {
                        WriteLine("WRONG INPUT, DUDE.");
                        Drop(room);
                        }
                    }
                }

            //Armor drop
            else if(userInput == "A")
                {
                if(armors.Count == 0)
                    {
                    WriteLine("YOU DON'T HAVE ANY ARMOR.");
                    Drop(room);
                    }

                WriteLine("DROPPING ARMOR: ");
                if(armors.Count > 1)
                    {
                    foreach(Armor armor in armors)
                        {
                        WriteLine("DROPPING " + armor.name);
                        WriteLine("YOU SURE?\n|(Y)ES\n|(N)O");
                        Write("==>");
                        string[] choice4 = new string[] { "Y","N" };
                        string input = UserInput(choice4);
                        if(input == "Y")
                            {
                            Armor aChanger = armor;
                            armors.Remove(armor);
                            room.armors.Add(aChanger);
                            Drop(room);
                            }
                        else if(input == "N")
                            {
                            continue;
                            }
                        else
                            {
                            WriteLine("WRONG INPUT, COME ON!");
                            Drop(room);
                            }
                        }
                    Drop(room);
                    }

                else if(armors.Count == 1)
                    {
                    WriteLine("DROPPING " + armors[0]);
                    WriteLine("YOU SURE?\n|(Y)ES\n|(N)O");
                    Write("==>");
                    string[] choice4 = new string[] { "Y","N" };
                    string input = UserInput(choice4);
                    if(input == "Y")
                        {
                        Armor aChanger = armors[0];
                        armors.RemoveAt(0);
                        room.armors.Add(aChanger);
                        Drop(room);
                        }
                    else if(input == "N")
                        {
                        Drop(room);
                        }
                    else
                        {
                        WriteLine("WRONG INPUT, COME ON!");
                        Drop(room);
                        }
                    }
                }
            else
                {
                WriteLine("WRONG INPUT,GOOD LORD!!!");
                Drop(room);
                }
            }


        /// <summary>
        /// Every Story ends some time...
        /// </summary>
        /// <param name="player">Players dead body</param>
        public static void DeadHero(Player player)
            {
            WriteLine($"DID I SAY YOU MAY DIE???\n" +
                $"DID I, {player.name}?");
            Program.GameOver();
            }


        /// <summary>
        /// //TODO: Level up system with stats increasing
        /// </summary>
        public void LevelUp() { }

        /////
        }
    }