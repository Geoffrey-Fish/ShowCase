using static System.Console;

namespace RPGOne
    {
    //Todo: Shop still WIP

    /// <summary>
    /// A store is essential for selling the LOOT
    /// </summary>
    public class Store
        {
        public string name;
        public string desc;
        public int pos_x;
        public int pos_y;
        public List<Character> npcs;
        public List<Item> items;
        public List<Weapon> weapons;
        public List<Armor> armors;
        public int gp;

        public Store(string name,string desc,int pos_x,int pos_y,List<Character> npcs,List<Item> items,List<Weapon> weapons,List<Armor> armors,int gp)
            {
            this.name = name;
            this.desc = desc;
            this.pos_x = pos_x;
            this.pos_y = pos_y;
            this.npcs = npcs;
            this.items = items;
            this.weapons = weapons;
            this.armors = armors;
            this.gp = gp;
            }
        public static Store shop = new Store("CRAMERS CANDIES","ALL THE STUFF YOU NEED",1,1,new List<Character>
            { Character.store_clerk },new List<Item> { Item.gem,Item.minor_health,Item.poison },new List<Weapon>
                { Weapon.short_sword,Weapon.wizards_staff,Weapon.stick },new List<Armor>
                    { Armor.leather_armor,Armor.towel,Armor.cloth_robe },599);

        public static void status(Player player)
            {
            Clear();
            WriteLine("WELCOME TO THE CANDY SHOP");
            WriteLine("-------------------------");
            Menu(player,Store.shop);
            }

        /// <summary>
        /// Main Menu of the store, choose if you want to sell or buy
        /// </summary>
        /// <param name="player">Player stats</param>
        /// <param name="shop">shop stats</param>
        public static void Menu(Player player,Store shop)
            {
            WriteLine("STORE MENU:");
            WriteLine("|(B)UY\n|(S)ELL\n|(L)EAVE");
            Write("==>");
            string[] choice = new string[] { "B","S","L" };
            string user_input = player.UserInput(choice);

            if(user_input == "B")
                {
                //Here was my main battlefield because of the Lists and their uniqueness when paired to a class.
                //So I exported Buy and Sell to the coressponding Classes, it makes calling the buy/sell method easy and concise.
                WriteLine("(I)TEMS,(W)EAPONS,(A)RMOR?");
                Write("==>");
                string[] choice2 = new string[] { "I","W","A" };
                string user_input2 = player.UserInput(choice2);
                switch(user_input2)
                    {
                    case "I":
                        //It works!!!!It finally fucking works!!!!!
                        Item.Buy(player,shop);
                        break;
                    case "W":
                        Weapon.Buy(player,shop);
                        break;
                    case "A":
                        Armor.Buy(player,shop);
                        break;
                    default:
                        WriteLine("WRONG INPUT,CAVEMAN!");
                        break;
                    }
                }
            else if(user_input == "S")
                {
                WriteLine("|(I)TEMS\n|(W)EAPONS\n|(A)RMOR?");
                Write("==>");
                string[] choice3 = new string[] { "I","W","A" };
                string user_input2 = player.UserInput(choice3);
                switch(user_input2)
                    {
                    case "I":
                        //It works!!!!It finally f*****g works!!!!!
                        Item.Sell(player,shop);
                        break;
                    case "W":
                        Weapon.Sell(player,shop);
                        break;
                    case "A":
                        Armor.Sell(player,shop);
                        break;
                    default:
                        WriteLine("WRONG INPUT,CAVEMAN!");
                        Menu(player,shop);
                        break;
                    }
                }
            else if(user_input == "L")
                {
                //Back to main menu
                WriteLine("SEE YOU! COME BACK SOMETIME!");
                //Program.Options(room,player);
                return;
                }
            else
                {
                WriteLine("AGAIN SOMETHING WENT THE WRONG ROAD...");
                return;
                //dunno if this works...
                }
            }
        }
    }