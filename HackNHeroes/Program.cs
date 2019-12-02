using System;
using System.Runtime.CompilerServices;

namespace HackNHeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;

            PrintMenu();

            while (!quit)
            {
                var choice = Console.Read();
                MainMenuSelection(choice);
                
            }
            
        }

        private static void MainMenuSelection(int choice)
        {
            switch (choice)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    PrintMenu();
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine('\n');
            Console.WriteLine("" +
                              "*****************************\n" +
                              "0) Run away little girl!\n" +
                              "1) DEATHMATCH\n" +
                              "2) ATTACK!\n" +
                              "3) \n" +
                              "4) \n" +
                              "5) New Hero\n" +
                              "6) New Foe\n" +
                              "7) Load\n" +
                              "8) Save\n" +
                              "9) Print Menu\n" +
                              "*****************************");
        }
    }
}
