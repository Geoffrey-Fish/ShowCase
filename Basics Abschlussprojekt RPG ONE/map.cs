using static System.Console;

namespace RPGOne
    {

    /// <summary>
    /// Every RPG needs a map!
    /// </summary>
    public class Map

        {
        /// <summary>
        /// The Map as jagged array,
        /// One hidden, one uncovered.
        /// </summary>
        public static string[][] mapHidden ={
                new string[] { "||||||", "||||||", "||||||" }, //[0][0],[0][1],[0][2]
                new string[] { "||||||", "???? |", "||||||" }, //[1][0],[1][1],[1][2]
                new string[] { "|????|", "???? |", "???? |" }, //[2][0],[2][1],[2][2]
                new string[] { "|????|", "???? |", "???? |" }, //[3][0],[3][1],[3][2]
                new string[] { "|????|", "START|", "???? |" }, //[4][0],[4][1],[4][2]
                new string[] { "|????|", "???? |", "???? |" }, //[5][0],[5][1],[5][2]
                new string[] { "||||||", "???? |", "||||||" }, //[6][0],[6][1],[6][2]
                new string[] { "||||||", "||||||", "||||||" }  //[7][0],[7][1],[7][2]
                };
        public static string[][] mapUncovered ={
                new string[] { "||||||", "||||||", "||||||" }, //[0][0],[0][1],[0][2]
                new string[] { "||||||", "NULL |", "||||||" }, //[1][0],[1][1],[1][2]
                new string[] { "|NULL|", "ORCS |", "NULL |" }, //[2][0],[2][1],[2][2]
                new string[] { "|NULL|", "FOES |", "STORE|" }, //[3][0],[3][1],[3][2]
                new string[] { "|NULL|", "START|", "RATS |" }, //[4][0],[4][1],[4][2]
                new string[] { "|NULL|", "GEMS |", "NULL |" }, //[5][0],[5][1],[5][2]
                new string[] { "||||||", "NULL |", "||||||" }, //[6][0],[6][1],[6][2]
                new string[] { "||||||", "||||||", "||||||" }  //[7][0],[7][1],[7][2]
                };


        /// <summary>
        /// Simple printout of the map.
        /// </summary>
        public static void Plan(Room room,Player player)
            {
            Clear();
            for(int i = 0;i < 8;i++)
                {
                WriteLine(mapHidden[i][0] + mapHidden[i][1] + mapHidden[i][2]);
                }
            Program.Options(room,player);
            }


        //todo: still wip
        /// <summary>
        /// Right now no idea what I wanted with that
        /// </summary>
        public static void Path(int x,int y)
            {
            mapHidden[x][y] = mapUncovered[x][y];
            }



        }
    }