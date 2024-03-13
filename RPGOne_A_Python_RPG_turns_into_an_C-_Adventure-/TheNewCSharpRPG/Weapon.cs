using static System.Console;

namespace RPGOne
    {
    /// <summary>
    /// Class for the weapons in the game
    /// </summary>
    public class Weapon
        {
        public string name { get; set; }
        public int dmgValue { get; set; }
        public int arValue { get; set; }
        public int gpValue { get; set; }
        public double weight { get; set; }


        //todo: still not in use
        /// <summary>
        /// Randomizer for new and different weapons on every game
        /// </summary>
        private static Random rand = new Random();


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dmgValue"></param>
        /// <param name="arValue"></param>
        /// <param name="gpValue"></param>
        /// <param name="weight"></param>
        public Weapon(string name,int dmgValue,int arValue,int gpValue,double weight)
            {
            this.name = name;
            this.dmgValue = dmgValue;
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
            if(shop.weapons.Count == 0)
                {
                WriteLine("I AM SO SORRY, I AM OUT OF STOCK...");
                Store.Menu(player,shop);
                }
            WriteLine(player.name + " IS BUYING SOME WEAPONS!" + Environment.NewLine);

            for(int i = 0;i < shop.weapons.Count;i++)
                {
                //Plus one because of indexing
                WriteLine($"{i + 1}: {shop.weapons[i].name} FOR {shop.weapons[i].gpValue} GOLD");
                }

            WriteLine($"WHICH NUMBER DO YOU CHOOSE FROM 1 TO {shop.weapons.Count} ?");
            Write("==>");
            //Minus one because of indexing
            var userInput = int.Parse(ReadLine()) - 1;

            try
                {
                if(player.gp >= shop.weapons[userInput].gpValue)
                    {
                    WriteLine($"BUYING {shop.weapons[userInput].name} !" + Environment.NewLine);

                    player.gp -= shop.weapons[userInput].gpValue;
                    shop.gp += shop.weapons[userInput].gpValue;
                    Weapon wChanger = shop.weapons[userInput];
                    shop.weapons.RemoveAt(userInput);
                    player.weapons.Add(wChanger);
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
            if(player.weapons.Count == 0)
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

            for(int i = 0;i < player.weapons.Count;i++)
                {
                //plus 1 because of the indexing
                WriteLine($"{i + 1}: {player.weapons[i].name} WORTH {player.weapons[i].gpValue} GOLD");
                }

            WriteLine($"WHAT YOU WANNA SELL FROM 1 TO {player.weapons.Count} ?");
            Write("==>");
            //minus 1 because of the indexing
            int userInput = int.Parse(ReadLine()) - 1;
            try
                {
                WriteLine($"SELLING {player.weapons[userInput].name}");
                WriteLine($"{player.name} GETS: {player.weapons[userInput].gpValue} GOLD");

                player.gp += player.weapons[userInput].gpValue;//todo: make a small cut for the clerk, like 0.7 times. need double,though...
                shop.gp -= player.weapons[userInput].gpValue;

                Weapon wChanger = player.weapons[userInput];
                player.weapons.RemoveAt(userInput);
                shop.weapons.Add(wChanger);
                Store.Menu(player,shop);

                }
            catch(ArgumentOutOfRangeException)
                {
                WriteLine("NO ITEM HERE...");
                Store.Menu(player,shop);
                }
            }


        /// <summary>
        /// Status of current selected Weapon
        /// </summary>
        public void Status()
            {
            WriteLine(name);
            WriteLine("DMG VALUE: " + dmgValue.ToString());
            WriteLine("AR VALUE: " + arValue.ToString());
            WriteLine("GP VALUE: " + gpValue.ToString());
            WriteLine("WEIGHT: " + weight.ToString());
            }


        /// <summary>
        /// Invocation of weapons
        /// </summary>
        public static Weapon short_sword = new Weapon("SHORT SWORD",rand.Next(1,7),0,50,3);
        public static Weapon wizards_staff = new Weapon("WIZARDS STAFF",rand.Next(1,41),0,400,4);
        public static Weapon stick = new Weapon("STICK",1,0,1,0.1);

        /////
        }
    }