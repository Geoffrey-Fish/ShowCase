namespace halilistsexy
    {
    class Programm
        {
        static void Main(string[] args)
            {
            bool exit = false;
            while(exit == false)
                {
                Console.WriteLine("Was tust du: \n" +
                "(W)eiter,\n " +
                "(F)lucht \n" +
                "(E)xit");

                string? antwort = Console.ReadLine();
                switch(antwort)

                    {
                    case "W":
                        blablablabla();
                        break;
                    case "F":
                        blablablabla();
                        break;
                    case "E":
                        exit = true;
                        break;
                    }
                }
            }

        public static void blablablabla()
            {
            Console.WriteLine("blabla");
            }
        }
    }
