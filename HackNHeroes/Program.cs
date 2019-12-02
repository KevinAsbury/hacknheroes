using System;

namespace HackNHeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("Hello World!");
                PrintMenu();
            }
            
        }

        private static void MainMenuSelection(int n)
        {
            switch (n)
            {
                case 0:
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
            }
        }

        private static void BattleMenuSelection(int n)
        {
            switch (n)
            {
                case 0:
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
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine('\n');
            Console.WriteLine(
                @"
1) Hello World!
q) Quit");
        }
    }
}
