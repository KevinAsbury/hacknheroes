using System;
using System.Collections.Generic;
using System.Text;

namespace HackNHeroes
{
    internal class Combat
    {
        internal void DeathMatch(Hero hero, Foe foe)
        {
            Console.Write("EARTH SHAKING BATTLES OF EPIC PROPORTIONS ENSUE...\n");
            var rand = new Random();
            bool fight = true;

            while (fight)
            {
                var coinFlip = rand.Next(1, 101);

                if (coinFlip > 50 && hero.isAlive() && foe.isAlive())
                {
                    Console.WriteLine($"{hero.Name} attacks!");
                    hero.attack();
                    var dmg = rand.Next(0, hero.Damage);
                    foe.Hp -= dmg;
                    Console.WriteLine($"{foe.Name} takes {dmg} damage and has {foe.Hp} health left.");
                }
                else if(coinFlip < 51 && hero.isAlive() && foe.isAlive())
                {
                    Console.WriteLine($"{foe.Name} attacks!");
                    var dmg = rand.Next(0, foe.Damage);
                    hero.Hp -= dmg;
                    Console.WriteLine($"{hero.Name} takes {dmg} damage and has {hero.Hp} health left.");
                }
                else
                {
                    if(!hero.isAlive())
                        Console.WriteLine("You're hero has fallen!");

                    if(!foe.isAlive())
                        Console.Write("Way to go! Ding-dong the foe is dead.");
                    
                    fight = false;
                }
            }
        }

        internal void Round(Hero hero, Foe foe)
        {
            if (hero.isAlive() && foe.isAlive())
            {
                Console.Write("CAT FIGHT... REOW!");
                // HIT!
            }
        }

    }
}
