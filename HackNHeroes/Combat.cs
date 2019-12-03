using System;
using System.Collections.Generic;
using System.Text;

namespace HackNHeroes
{
    internal class Combat
    {
        internal void DeathMatch(Creature hero, Creature foe)
        {
            Console.Write("EARTH SHAKING BATTLES OF EPIC PROPORTIONS ENSUE...\n");
            var rand = new Random();
            bool fight = true;

            while (fight)
                fight = Round(hero, foe);
        }

        internal bool Round(Creature hero, Creature foe)
        {
            if (hero.isAlive() && foe.isAlive())
            {
                var rand = new Random();
                var coinFlip = rand.Next(1, 101);

                if (coinFlip > 50 && hero.isAlive() && foe.isAlive())
                {
                    Console.WriteLine($"{hero.Name} attacks!");
                    var dmg = hero.attack(foe);
                    Console.WriteLine($"{foe.Name} takes {dmg} damage and has {foe.Hp} health left.\n");

                    return true;
                }
                else if (coinFlip < 51 && hero.isAlive() && foe.isAlive())
                {
                    Console.WriteLine($"{foe.Name} attacks!");
                    var dmg = foe.attack(hero);
                    Console.WriteLine($"{hero.Name} takes {dmg} damage and has {hero.Hp} health left.\n");

                    return true;
                }
            }

            if (!hero.isAlive())
                Console.WriteLine("You're hero has fallen!\n");

            if (!foe.isAlive())
                Console.Write("Way to go! Ding-dong the foe is dead.\n");

            return false;
        }
    }
}
