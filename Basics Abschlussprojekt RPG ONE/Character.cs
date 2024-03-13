using static System.Console;

namespace RPGOne
    {
    /// <summary>
    /// These are the values a npc has.
    /// </summary>
    public class Character
        {
        public bool friend { get; set; }
        public string name { get; set; }
        public int pos_x { get; set; }
        public int pos_y { get; set; }
        public int max_hp { get; set; }
        public int hp { get; set; }
        public int st { get; set; }
        public int dex { get; set; }
        public int gp { get; set; }
        public int xp { get; set; }
        public List<Item> items { get; set; }
        public List<Weapon> weapons { get; set; }
        public List<Armor> armors { get; set; }
        public int dmg { get; set; }
        public int ar { get; set; }
        public string dialog { get; set; }


        /// <summary>
        /// This is the NPC Constructor, for Friends and foes alltogether
        /// </summary>
        /// <param name="friend">Friend or Foe?</param>
        /// <param name="name">The Name</param>
        /// <param name="pos_x">Where npc is at x</param>
        /// <param name="pos_y">Where npc is at y</param>
        /// <param name="hp">Npc health</param>
        /// <param name="st">Npc strength</param>
        /// <param name="dex">Npc dexterity</param>
        /// <param name="gp">Npc precious GOLD</param>
        /// <param name="xp">Npc Expierience</param>
        /// <param name="items">Npcs stuff</param>
        /// <param name="weapons">Npcs Weapons</param>
        /// <param name="armors">Npcs Armor</param>
        /// <param name="dialog">What the buddy has to say.</param>
        public Character(bool friend,string name,int pos_x,int pos_y,int hp,int st,int dex,int gp,int xp,List<Item> items,List<Weapon> weapons,List<Armor> armors,string dialog)
            {
            this.friend = friend;
            this.name = name;
            this.pos_x = pos_x;
            this.pos_y = pos_y;
            this.hp = hp;
            this.st = st;
            this.dex = dex;
            this.gp = gp;
            this.xp = xp;
            this.items = items;
            this.weapons = weapons;
            this.armors = armors;
            this.dmg = weapons[0].dmgValue; //gets calculated while fighting
            this.ar = armors[0].arValue;
            this.dialog = dialog;
            }


        /// <summary>
        /// Gives the actual Status of the Npc
        /// </summary>
        public void Status()
            {
            Clear();
            WriteLine("---NPC-POSITION---------");
            WriteLine(name + "`S POS X: " + pos_x);
            WriteLine(name + "`S POS Y: " + pos_y);
            WriteLine("---NPC-STATS------------");
            WriteLine($"HEALTH: {hp} OF: {max_hp}");
            WriteLine("STRENGTH: " + st);
            WriteLine("DEXTERITY: " + dex);
            WriteLine("DAMAGE: " + dmg);
            WriteLine("DEFENCE: " + ar);
            WriteLine("EXPIERIENCE: " + xp);
            WriteLine("GOLD: " + gp);

            foreach(Item item in items)
                {
                WriteLine("ITEMS: ");
                WriteLine(item.name);
                }
            foreach(Weapon weapon in weapons)
                {
                WriteLine("WEAPONS: ");
                WriteLine(weapon.name);
                }
            foreach(Armor armor in armors)
                {
                WriteLine("ARMORS: ");
                WriteLine(armor.name);
                }
            }


        /// <summary>
        /// Random Dice roll for the battles
        /// </summary>
        /// <param name="min">minimum value</param>
        /// <param name="max">maximum value - 1</param>
        /// <returns>Random Number in Range of min and max</returns>
        public int RollDice(int min,int max)
            {
            int roll = new Random().Next(min,max);
            WriteLine(name + " ROLLS: " + roll);
            return roll;
            }


        /// <summary>
        /// That's what the Npc can say
        /// </summary>
        public void Dialog()
            {
            WriteLine(dialog);
            }


        /// <summary>
        ///It clears the enemy Npc from the Room
        ///</summary>
        /// <param name="room">Rooms Npcs</param>
        public void QueueFree(Room room)
            {
            Narrative.EnemyDeath();
            WriteLine(name + " IS DEAD.\n" +
                "WELL DONE!\n" +
                "THE BODY DROPS HIS LOOT TO THE GROUND.");
            //Now looping through items, weapons and armor
            //if zero,skip
            if(items.Count > 0)
                {
                //if more than one, iterate
                if(items.Count > 1)
                    {
                    foreach(Item item in items)
                        {
                        Item iChanger = item;
                        items.Remove(item);
                        room.items.Add(iChanger);
                        }
                    }
                //if only one, this one
                else if(items.Count == 1)
                    {
                    Item iChanger = items[0];
                    items.RemoveAt(0);
                    room.items.Add(iChanger);
                    }
                }
            //same procedure as items
            if(weapons.Count > 0)
                {
                if(weapons.Count > 1)
                    {
                    foreach(Weapon weapon in weapons)
                        {
                        Weapon wChanger = weapon;
                        weapons.Remove(weapon);
                        room.weapons.Add(wChanger);
                        }
                    }
                else if(weapons.Count == 1)
                    {
                    Weapon wChanger = weapons[0];
                    weapons.RemoveAt(0);
                    room.weapons.Add(wChanger);
                    }
                }
            //same procedure as items
            if(armors.Count > 0)
                {
                if(armors.Count > 1)
                    {
                    foreach(Armor armor in armors)
                        {
                        Armor aChanger = armor;
                        armors.Remove(armor);
                        room.armors.Add(aChanger);
                        }
                    }
                else if(armors.Count == 1)
                    {
                    Armor aChanger = armors[0];
                    armors.RemoveAt(0);
                    room.armors.Add(aChanger);
                    }
                }
            WriteLine("IF YOU WANT TO LOOT,CHOOSE (I)NVENTORY IN THE MENU.\n" +
                "CONTINUE WITH ANY KEY:");
            Write("==>");
            ReadKey();
            }


        /// <summary>
        /// Invocation of all Characters
        /// </summary>
        //Foes
        //bool friend, string name,int pos_x,int pos_y,int max_hp,int st,int dex,int gp,int xp,List<Item> items,List<Weapon> weapons,List<Armor> armors,string dialog
        public static Character orc_peon = new Character(false,"ORC PIGGY",0,6,18,30,20,20,10,new List<Item> { Item.gem },new List<Weapon> { Weapon.short_sword },new List<Armor> { Armor.leather_armor },"DIE DIE DIE BART, DIE!!!");
        public static Character orc_peewee = new Character(false,"ORC PEEWEE",0,6,25,30,30,20,10,new List<Item> { Item.gem },new List<Weapon> { Weapon.short_sword },new List<Armor> { Armor.leather_armor },"DIEDABADUU!!!");
        public static Character orc_boner = new Character(false,"ORC BONER",0,6,30,60,50,20,10,new List<Item> { Item.gem },new List<Weapon> { Weapon.short_sword },new List<Armor> { Armor.leather_armor },"DER BART, DER!!!");
        public static Character orc_baba = new Character(false,"ORC BABA",0,6,30,60,50,20,10,new List<Item> { Item.gem },new List<Weapon> { Weapon.short_sword },new List<Armor> { Armor.leather_armor },"LOREM IPSUM!!!");
        //Friends
        public static Character friendly_wizard = new Character(true,"FRIENDLY WIZARD",0,6,30,60,50,20,10,new List<Item> { Item.gem },new List<Weapon> { Weapon.wizards_staff },new List<Armor> { Armor.cloth_robe },"HELLO ADVENTURER!\n I AM A FRIENDLY WIZARD.\nI HAVE BROUGHT YOU TO THIS REALITY!\nI HEARD STRANGE SOUNDS COMING FROM THE NORTH!!!!");
        public static Character rat_man = new Character(true,"RAT MAN",1,2,5,10,20,2,5,new List<Item> { Item.poison },new List<Weapon> { Weapon.stick },new List<Armor> { Armor.towel },"RAT TITTIES,FRESH RAT TITTIES,I HAVE THEM ALL!!!\nJUST 49999 GOLD,EACH!!!\nBETTER THAN WHAT THAT SHOP UP NORTH HAS TO OFFER,FOR SURE!!!!\n*garbles along in his beard...*");
        public static Character store_clerk = new Character(true,"STORE CLERK",1,0,2,3,4,5,5,new List<Item> { Item.gem,Item.minor_health },new List<Weapon> { Weapon.stick },new List<Armor> { Armor.towel },"Hi THERE, STRANGER");

        /////
        }
    }