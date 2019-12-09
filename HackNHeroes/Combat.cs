using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace HackNHeroes
{
    internal class Combat : IDisposable
    {
        private Hero Hero { get; set; }
        private List<Monster> Monsters { get; set; }

        // Free up resources after battle
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal Combat(Hero hero)
        {
            if (!hero.isAlive())
            {
                // Hero is dead, end combat!
                Console.WriteLine($"{hero.Name} is dead.");
                this.Dispose();
            }
            else
            {
                Hero = hero;
                // TODO: Do Battle!
                this.Dispose();
            }

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing) 
                handle.Dispose();

            disposed = true;
        }

        internal void AddMonster(Monster monster)
        {
            Monsters.Add(monster);
        }

        ~Combat()
        {
            Dispose(false);
        }
        //internal void DeathMatch(Creature hero, Creature foe)
        //{
        //    Console.Write("EARTH SHAKING BATTLES OF EPIC PROPORTIONS ENSUE...\n");
        //    var rand = new Random();
        //    bool fight = true;

        //    while (fight)
        //        fight = Round(hero, foe);
        //}

        //internal bool Round(Creature hero, Creature foe)
        //{
        //    if (hero.isAlive() && foe.isAlive())
        //    {
        //        var rand = new Random();
        //        var coinFlip = rand.Next(1, 101);

        //        if (coinFlip > 50 && hero.isAlive() && foe.isAlive())
        //        {
        //            Console.WriteLine($"{hero.Name} attacks!");
        //            var dmg = hero.attack(foe);
        //            Console.WriteLine($"{foe.Name} takes {dmg} damage and has {foe.Hp} health left.\n");

        //            return true;
        //        }
        //        else if (coinFlip < 51 && hero.isAlive() && foe.isAlive())
        //        {
        //            Console.WriteLine($"{foe.Name} attacks!");
        //            var dmg = foe.attack(hero);
        //            Console.WriteLine($"{hero.Name} takes {dmg} damage and has {hero.Hp} health left.\n");

        //            return true;
        //        }
        //    }

        //    if (!hero.isAlive())
        //        Console.WriteLine("You're hero has fallen!\n");

        //    if (!foe.isAlive())
        //        Console.Write("Way to go! Ding-dong the foe is dead.\n");

        //    return false;
        //}
    }
}
