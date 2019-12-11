using System;

namespace HackNHeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Hero hero = new Hero();
            Monster foe = new Monster();
            bool quit = false;

            PrintMenu(hero.Name);

            do
            {
                var result = MainMenuSelection(Console.Read(), hero);
                quit = result;
            } while (!quit);

            //Environment.Exit(0);
        }

        private static bool MainMenuSelection(int ch, Hero hero)
        {
            var input = (int)Convert.ToChar(Convert.ToChar(ch).ToString().ToUpper());

            switch (input)
            {
                case 0x52: //R
                    PrintCombat(hero);
                    return false;
                case 0x56: //V
                    PrintStats(hero);
                    return false;
                case 0x47: //G
                    PrintRest(hero);
                    return false;
                case 0x4E: //N
                    PrintNewHero(hero);
                    return false;
                case 0x53: //S
                    hero.Save();
                    return false;
                case 0x4C: //L
                    PrintLoad(hero);
                    return false;
                case 0x4D: //M
                    PrintMenu(hero.Name);
                    return false;
                case 0x51: //Q
                    Console.WriteLine("The crowd BOOOOOS as you walk away.");
                    return true;
            }

            return false;
        }

        private static void PrintHeader(string name = "")
        {
            Console.Clear();
            ColorText("Hack N Heroes", ConsoleColor.White);

            if (!String.IsNullOrEmpty(name))
                ColorText($" - {name}\n", ConsoleColor.Cyan);
            else
                Console.Write('\n');

            ColorText("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\n", 
                ConsoleColor.Magenta);
        }

        private static void PrintFooter(string heroName = "hero")
        {
            Console.Write('\n');
            ColorText("The Arena", ConsoleColor.Magenta);
            ColorText(" - (M to print menu)\n", ConsoleColor.Gray);
            ColorText("(R, V, G, N, S, L, Q, M)\n", ConsoleColor.Gray);
            Console.Write('\n');
            Console.Write("Your command, ");
            ColorText($"{heroName}", ConsoleColor.Cyan);
            Console.Write("? : ");
        }

        private static void PrintMenu(string heroName = "hero")
        {
            PrintHeader();
            Console.WriteLine("You enter the arena like a boss hardly noticed by bustling crowd. The bored ");
            Console.WriteLine("announcer yawns and presents yet another hero wanting to test their metal.");
            Console.WriteLine("You're going to have to prove yourself in this area...");
            Console.Write('\n');
            PrintMenuItem("Raise your sword and fight!");
            PrintMenuItem("View your stats");
            PrintMenuItem("Goto the resting pens and save");
            PrintMenuItem("New hero");
            PrintMenuItem("Save hero");
            PrintMenuItem("Load hero");
            PrintMenuItem("Quit");
            PrintFooter(heroName);
        }

        private static void PrintStats(Hero hero)
        {
            PrintHeader("Hero Stats");
            Console.WriteLine($"Name: {hero.Name}");
            Console.WriteLine($"Level: {hero.getLevel()}");
            Console.WriteLine($"Experience: {hero.Experience}");
            Console.WriteLine($"HP: {hero.Hp}");
            Console.WriteLine($"Damage: {hero.Damage}");
            Console.WriteLine($"Kills: {hero.Kills}");
            PrintFooter(hero.Name);
        }

        private static void PrintRest(Hero hero)
        {
            PrintHeader("Rest");
            Console.WriteLine($"{hero.Name} thuds heavily on the pile of straw that serves as a bed and sleeps.");
            hero.Rest();
            PrintFooter(hero.Name);
        }

        private static void PrintLoad(Hero hero)
        {
            bool stop = false;

            while (!stop)
            {
                Console.Clear();
                PrintHeader("Load Hero");
                Console.Write($"Name: ");
                var name = Console.ReadLine();
                if (name.Length > 3)
                {
                    hero.Load(name);
                    stop = true;
                }
            }
            PrintFooter(hero.Name);
        }

        private static void PrintNewHero(Hero hero)
        {
            bool stop = false;

            while (!stop)
            {
                Console.Clear();
                PrintHeader("New Hero");
                Console.Write($"Name: ");
                var name = Console.ReadLine();
                if (name.Length > 3)
                {
                    hero.New(name);
                    stop = true;
                }
            }
            
            PrintFooter(hero.Name);
        }

        private static void PrintCombat(Hero hero)
        {
            bool stop = false;
            var combat = new Combat(hero);

            while (!stop)
            {
                Console.Clear();
                PrintHeader("Combat");
                //Console.WriteLine($"Hero HP: {hero.Hp} / {hero.HpMax}");
                //Console.WriteLine($"{combat.Foe.Name} HP: {combat.Foe.Hp} / {combat.Foe.HpMax}");
                Console.WriteLine("");

                if (combat.Foe.isAlive() && hero.isAlive())
                    PrintMenuItem($"Attack {combat.Foe.Name}");

                PrintMenuItem($"Consign");
                //var input = (int)Convert.ToChar(Convert.ToChar(Console.Read()).ToString().ToUpper());

                var quit = false;
                do
                {
                    var input = (int)Convert.ToChar(Convert.ToChar(Console.Read()).ToString().ToUpper());
                    
                    if (input == 0x41)
                    {
                        combat.Fight(hero);
                        ColorText($"{hero.Name}", ConsoleColor.Cyan);
                        ColorText($" HP: {hero.Hp} / {hero.HpMax}\n", ConsoleColor.Magenta);
                        ColorText($"{combat.Foe.Name}", ConsoleColor.Cyan);
                        ColorText($" HP: {combat.Foe.Hp} / {combat.Foe.HpMax}", ConsoleColor.Magenta);
                        Console.Write('\n');
                        Console.Write("Your command, ");
                        ColorText($"{hero.Name}", ConsoleColor.Cyan);
                        Console.Write("? ");
                        ColorText("(A, C)", ConsoleColor.Gray);
                        Console.Write(" : ");
                    }

                    if (input == 0x43)
                    {
                        Console.WriteLine("Weary and on the edge of death you concede the battle. Go rest.");
                        quit = true;
                        stop = true;
                    }
                } while (!quit);
            }

            PrintFooter(hero.Name);
        }

        private static void PrintMenuItem(string text)
        {
            Console.Write("(");
            ColorText(text[0]);
            Console.WriteLine($"){text.Substring(1)}");
        }

        /// <summary>
        /// Print a string in a custom color
        /// </summary>
        /// <param name="chars">the string</param>
        /// <param name="color">the color</param>
        /// <returns>String</returns>
        private static string ColorText(string chars, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"{chars}");
            Console.ForegroundColor = ConsoleColor.Green;
            return "";
        }

        /// <summary>
        /// Print a char in magenta
        /// </summary>
        /// <param name="ch">character</param>
        private static void ColorText(char ch)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{ch}");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        private static Creature NewCreature(Creature hero, bool isHero = true)
        {
            Console.WriteLine('\n');

            var type = "creature";
            if (isHero) type = "hero";

            Console.WriteLine($"What is the new {type}'s name: ");
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
