using static System.Console;

namespace RPGOne
    {

    /// <summary>
    /// Item Class contains all items in the game except Weapons and Armor
    /// </summary>
    public class Item
        {
        public string name { get; set; }
        public int gpValue { get; set; }
        public double weight { get; set; }


        /// <summary>
        /// Constructor for Items
        /// </summary>
        /// <param name="name">Item name, descriptive</param>
        /// <param name="gpValue">Goldpoints, the Currency in the game</param>
        /// <param name="weight">Oh the weight!</param>
        public Item(string name,int gpValue,double weight)
            {
            this.name = name;
            this.gpValue = gpValue;
            this.weight = weight;
            }


        /// <summary>
        /// Method is called from the shop for buying stuff
        /// </summary>
        /// <param name="player">Players stats</param>
        /// <param name="shop">Shops stats</param>
        public static void Buy(Player player,Store shop)
            {
            WriteLine(player.name + " IS BUYING STUFF!" + Environment.NewLine);
            if(shop.items.Count == 0)
                {
                WriteLine("I AM SO SORRY, I AM OUT OF STOCK...");
                Store.Menu(player,shop);
                }
            for(int i = 0;i < shop.items.Count;i++)
                {
                WriteLine($"{i + 1}: {shop.items[i].name} FOR {shop.items[i].gpValue} GOLD");
                }

            WriteLine($"WHICH NUMBER DO YOU CHOOSE FROM 1 TO {shop.items.Count} ?");
            Write("==>");
            // minus one because indexing
            var userInput = int.Parse(ReadLine()) - 1;

            try
                {
                if(player.gp >= shop.items[userInput].gpValue)
                    {
                    WriteLine($"BUYING {shop.items[userInput].name} !" + Environment.NewLine);

                    player.gp -= shop.items[userInput].gpValue;
                    shop.gp += shop.items[userInput].gpValue;
                    Item iChanger = shop.items[userInput];
                    shop.items.RemoveAt(userInput);
                    player.items.Add(iChanger);
                    Store.Menu(player,shop);
                    }
                else
                    {
                    WriteLine("NOT ENOUGH COINS YOU HAVE!" + Environment.NewLine);
                    Store.Menu(player,shop);
                    }
                }
            catch(ArgumentOutOfRangeException)
                {
                WriteLine("NO ITEM HERE..." + Environment.NewLine);
                Store.Menu(player,shop);
                }
            }


        /// <summary>
        /// Method called from within Store for selling all the LOOT
        /// </summary>
        /// <param name="player">Player stats</param>
        /// <param name="shop">Store stats</param>
        public static void Sell(Player player,Store shop)
            {
            if(player.items.Count == 0)
                {
                WriteLine("YOUR BAG SEEMS EMPTY, MAN!");
                Store.Menu(player,shop);
                }
            if(shop.gp == 0)
                {
                WriteLine("I'M BROKE, BUDDY, SORRY.");
                Store.Menu(player,shop);
                }
            WriteLine(player.name + " IS SELLING:");

            for(int i = 0;i < player.items.Count;i++)
                {
                //plus 1 because of the indexing
                WriteLine($"{i + 1}: {player.items[i].name} WORTH {player.items[i].gpValue} GOLD.");
                }

            WriteLine($"WHAT YOU WANNA SELL FROM 1 TO {player.items.Count} ?");
            Write("==>");
            //minus 1 because of the indexing
            int userInput = int.Parse(ReadLine()) - 1;
            try
                {
                WriteLine($"SELLING {player.items[userInput].name} !");
                WriteLine($"{player.name} GETS: {player.items[userInput].gpValue} GOLD.");

                player.gp += player.items[userInput].gpValue;//todo: make a small cut for the clerk, like 0.7 times. need double,though...
                shop.gp -= player.items[userInput].gpValue;
                Item iChanger = player.items[userInput];
                player.items.RemoveAt(userInput);
                shop.items.Add(iChanger);
                Store.Menu(player,shop);

                }
            catch(ArgumentOutOfRangeException)
                {
                WriteLine("NO ITEM HERE...");
                Store.Menu(player,shop);
                }
            }


        /// <summary>
        /// Status of current Item
        /// </summary>
        public void Status()
            {
            WriteLine(name);
            WriteLine("GP VALUE: " + gpValue.ToString());
            WriteLine("WEIGHT: " + weight.ToString());
            }

        //// Example usage
        //short_sword.Status();
        //        wizards_staff.Status();
        //        stick.Status();
        //        leather_armor.Status();
        //        cloth_robe.Status();
        //        towel.Status();
        //        gem.Status();
        //        poison.Status();
        //        minor_health.Status();


        /// <summary>
        /// Invocation of Items
        /// </summary>
        public static Item gem = new Item("GEM",100,0.1);
        public static Item poison = new Item("POISON",40,1);
        public static Item minor_health = new Item("MINOR_HEALTH",150,1);

        ///////
        }
    }