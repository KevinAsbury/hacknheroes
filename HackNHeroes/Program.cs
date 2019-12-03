using System;
using System.Runtime.CompilerServices;

namespace HackNHeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Creature hero = new Creature("Conan", 60, 10);
            Creature foe = new Creature("Thoth-Amon", 100, 6);
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

        private static (bool, Creature, Creature) MainMenuSelection(int choice, Combat combat, Creature hero, Creature foe)
        {
            switch (choice)
            {
                case 0x30:
                    return (true, null, null);
                case 0x31:
                    combat.DeathMatch(hero, foe);
                    PrintMenu();
                    return (false, null, null);
                case 0x32:
                    combat.Round(hero, foe);
                    return (false, null, null);
                case 0x33:
                    hero.Hp = hero.HpMax;
                    return (false, null, null);
                case 0x34:
                    foe.Hp = foe.HpMax;
                    return (false, null, null);
                case 0x35:
                    return (false, NewCreature(hero, true), null);
                case 0x36:
                    return (false, null, NewCreature(foe, false));
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
                              "3) Heal hero\n" +
                              "4) Heal foe\n" +
                              "5) New Hero\n" +
                              "6) New Foe\n" +
                              "7) Load\n" +
                              "8) Save\n" +
                              "9) Print Menu\n" +
                              "*****************************");
        }

        private static Creature NewCreature(Creature hero, bool isHero = true)
        {
            Console.WriteLine('\n');

            var type = "creature";
            if (isHero) type = "hero";

            Console.WriteLine(@"What is the new {type}'s name: ");
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
    }
}
