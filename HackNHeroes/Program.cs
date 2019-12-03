using System;
using System.Runtime.CompilerServices;

namespace HackNHeroes
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Hero hero = new Hero("Conan", 60, 10);
            Foe foe = new Foe("Thoth-Amon", 100, 6);
            bool quit = false;
            Combat combat = new Combat();

            PrintMenu();

            while (!quit)
            {
                int choice = Console.Read();
                var result = MainMenuSelection(choice, combat, hero, foe);
                quit = result.Item1;

                if (result.Item2 != null)
                    hero = result.Item2;

                if (result.Item3 != null)
                    foe = result.Item3;
            }

            Console.WriteLine("Run away little girl!");
            Environment.Exit(0);
        }

        private static (bool, Hero, Foe) MainMenuSelection(int choice, Combat combat, Hero hero, Foe foe)
        {
            switch (choice)
            {
                case 0x30:
                    return (true, null, null);
                case 0x31:
                    combat.DeathMatch(hero, foe);
                    return (false, null, null);
                case 0x32:
                    combat.Round(hero, foe);
                    return (false, null, null);
                case 0x33:
                    return (false, null, null);
                case 0x34:
                    return (false, null, null);
                case 0x35:
                    return (false, NewHero(hero), null);
                case 0x36:
                    return (false, null, NewFoe(foe));
                case 0x37:
                    return (false, null, null);
                case 0x38:
                    return (false, null, null);
                case 0x39:
                    PrintMenu();
                    return (false, null, null);
            }

            return (false, null, null);
        }

        private static void PrintMenu()
        {
            Console.WriteLine('\n');
            Console.WriteLine("" +
                              "*****************************\n" +
                              "0) Run away little girl! (quit)\n" +
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

        private static Hero NewHero(Hero hero)
        {
            Console.WriteLine('\n');

            Console.WriteLine(@"What is the new hero's name: ");
            hero.Name = Console.ReadLine();

            Console.WriteLine('\n');
            Console.WriteLine(@"How much health: ");
            var hp = Console.Read();
            hero.Hp = hp;
            hero.HpMax = hp;

            Console.WriteLine('\n');
            Console.WriteLine(@"How much damage: ");
            hero.Damage = Console.Read();
            
            return hero;
        }

        private static Foe NewFoe(Foe foe)
        {
            Console.WriteLine('\n');

            Console.WriteLine(@"What is the new foe called: ");
            foe.Name = Console.ReadLine();

            Console.WriteLine('\n');
            Console.WriteLine(@"How much health: ");
            var hp = Console.Read();
            foe.Hp = hp;
            foe.HpMax = hp;

            Console.WriteLine('\n');
            Console.WriteLine(@"How much damage: ");
            foe.Damage = Console.Read();

            return foe;
        }
    }
}
