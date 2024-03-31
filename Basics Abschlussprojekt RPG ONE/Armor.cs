using static System.Console;

namespace RPGOne
    {
    /// <summary>
    /// Class for the Armors in the Game
    /// </summary>
    public class Armor
        {
        public string name { get; set; }
        public int arValue { get; set; }
        public int gpValue { get; set; }
        public double weight { get; set; }


        /// <summary>
        /// Randomizer for new gear every game
        /// </summary>
        private static Random rand = new Random();


        /// <summary>
        /// Constructor for Armor
        /// </summary>
        /// <param name="name">Name of armor</param>
        /// <param name="arValue">Armor protection Value</param>
        /// <param name="gpValue">Goldpoints</param>
        /// <param name="weight">The weight!</param>
        public Armor(string name,int arValue,int gpValue,double weight)
            {
            this.name = name;
            this.arValue = arValue;
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
            if(shop.armors.Count == 0)
                {
                WriteLine("I AM SO SORRY, I AM OUT OF STOCK...");
                Store.Menu(player,shop);
                }
            WriteLine(player.name + " IS BUYING SOME ARMOR!" + Environment.NewLine);

            for(int i = 0;i < shop.armors.Count;i++)
                {
                //Plus one because of indexing
                WriteLine($"{i + 1}: {shop.armors[i].name} FOR {shop.armors[i].gpValue} GOLD.");
                }

            WriteLine($"WHICH NUMBER DO YOU CHOOSE FROM 1 TO {shop.items.Count} ?");
            Write("==>");

            //Minus 1 because of indexing
            var userInput = int.Parse(ReadLine()) - 1;

            try
                {
                if(player.gp >= shop.armors[userInput].gpValue)
                    {
                    WriteLine($"BUYING {shop.armors[userInput].name} !" + Environment.NewLine);

                    player.gp -= shop.armors[userInput].gpValue;
                    shop.gp += shop.armors[userInput].gpValue;

                    Armor aChanger = shop.armors[userInput];
                    shop.armors.RemoveAt(userInput);
                    player.armors.Add(aChanger);
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
            if(player.armors.Count == 0)
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

            for(int i = 0;i < player.armors.Count;i++)
                {
                //plus 1 because of the indexing
                WriteLine($"{i + 1}: {player.armors[i].name} WORTH {player.armors[i].gpValue} GOLD.");
                }

            WriteLine($"WHAT YOU WANNA SELL FROM 1 TO {player.armors.Count} ?");
            Write("==>");
            //minus 1 because of the indexing
            int userInput = int.Parse(ReadLine()) - 1;
            try //why?
                {
                WriteLine($"SELLING {player.armors[userInput].name} !");
                WriteLine($"{player.name} GETS: {player.armors[userInput].gpValue} GOLD.");

                player.gp += player.armors[userInput].gpValue;//todo: make a small cut for the clerk, like 0.7 times. need double,though...
                shop.gp -= player.armors[userInput].gpValue;

                Armor aChanger = player.armors[userInput];
                player.armors.RemoveAt(userInput);
                shop.armors.Add(aChanger);
                Store.Menu(player,shop);
                }
            catch(ArgumentOutOfRangeException)
                {
                WriteLine("NO ITEM HERE...");
                Store.Menu(player,shop);
                }
            }


        /// <summary>
        /// Status of the current Armor
        /// </summary>
        public void Status()
            {
            WriteLine(name);
            WriteLine("AR VALUE: " + arValue.ToString());
            WriteLine("GP VALUE: " + gpValue.ToString());
            WriteLine("WEIGHT: " + weight.ToString());
            }


        /// <summary>
        /// Invocation of the Armor
        /// </summary>
        public static Armor leather_armor = new Armor("LEATHER ARMOR",2,80,12);
        public static Armor cloth_robe = new Armor("CLOTH ROBE",1,5,2);
        public static Armor towel = new Armor("TOWEL",1,1,0.1);

        /////
        }
    }