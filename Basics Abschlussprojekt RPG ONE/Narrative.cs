using static System.Console;
namespace RPGOne
    {
    //todo: this file is pretty much WIP
    /// <summary>
    /// This shall be the place for story telling
    /// </summary>
    public class Narrative
        {
        static Random rand = new Random();

        /// <summary>
        /// First greeting in the game
        /// </summary>
        /// <param name="name">Playername</param>
        public static void Welcome(Player player)
            {
            Clear();
            WriteLine("AS YOU WANDERED AROUND THE LANDS OF MINGGA\n" +
                "YOU STUMPLED UPON - IT SEEMS - \n" +
                "AN ABANDONED MINE!\n" +
                "OF COURSE YOU WANT TO...?\n" +
                "------------------------");

            WriteLine("1: GO IN\n" +
                "2: GO IN!\n" +
                "3: GO IN,FOR CHRISTS SAKE!!!");
            Write("==>");
            //Little joke, you dont really have a choice!
            ReadKey();
            WriteLine();
            WriteLine($"NOW, {player.name}, WHAT COULD POSSIBLY GO WRONG?");
            Thread.Sleep(1000);
            }

        public static void StartingRoom(Player player)
            {
            for(int i = 10;i >= 0;i--)
                {
                WriteLine($"{i}");
                Thread.Sleep(300);
                }
            WriteLine("NOW THAT YOU HAVE ENTERED THE MINE,\n" +
                "THERE IS NO GOING BACK!!!!\n" +
                "MUHEHEHHEHEHEHELELELELELEHEHEHEAHAHAHAHAHAHAA");
            Thread.Sleep(500);
            for(int j = 0;j < 50;j++)
                {
                Write("-");
                Thread.Sleep(200);
                }
            }
        /// <summary>
        /// Random greetings from friendly npcs
        /// </summary>
        public static void RandomGreeting()
            {
            string[] greeting = new string[]
                {
                    "Woah, Gods greeting","Welcome","Salve","Wrmpfldrmoph","What you want?"
                    };
            WriteLine($"{greeting[rand.Next(0,greeting.Length)]},");
            }


        /// <summary>
        /// Random Enemy attack phrases
        /// </summary>
        public static void EnemyAttack()
            {
            string[] enemyAttack = new string[]
                {
                    "Ha", "HUAGH", "Taketh thith", "BEMBEMBEMBEM"
                    };
            WriteLine($"{enemyAttack[rand.Next(0,enemyAttack.Length)]}");
            }
        public static void EnemyDeath()
            {
            string[] enemyDeath = new string[]
                {
                    "UUUAAAARRRGGGLLL","I SEE THE LIGHT---caeinrcet","AT LAST A WORTHY ENEMY*RGRHGRLRGL"
                    };
            WriteLine($"{enemyDeath[rand.Next(0,enemyDeath.Length)]}");
            }
        }
    }


