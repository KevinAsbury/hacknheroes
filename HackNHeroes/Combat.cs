using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace HackNHeroes
{
    internal class Combat : IDisposable
    {
        //private Hero Hero { get; set; }
        private List<Monster> MonsterList { get; set; }
        internal Monster Foe { get; set; }

        // Free up resources after battle
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Flag for GC
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
                //Hero = hero;
                LoadMonsters();
                LoadFoe(hero);
            }
        }

        internal void Fight(Hero hero, Monster foe)
        {
            if (!foe.isAlive() || !hero.isAlive())
                return;

            var battle = true;

            if (battle)
            {
                // Determine who attacks first this round
                if (hero.isAlive() && foe.isAlive())
                {
                    var rand = new Random();
                    var coinFlip = rand.Next(1, 101);

                    if (coinFlip > 50 && hero.isAlive() && foe.isAlive())
                    {
                        Console.WriteLine($"{hero.Name} attacks!");

                        // Do a miss roll
                        var miss = rand.Next(1, 100);
                        if (miss < 98)
                        {
                            var dmg = hero.attack(foe);
                            Console.WriteLine($"{foe.Name} takes {dmg} damage and has {foe.Hp} health left.\n");
                        } else
                        {
                            Console.WriteLine($"{hero.Name} swings and misses!");
                        } 
                    }
                    else if (coinFlip < 51 && hero.isAlive() && foe.isAlive())
                    {
                        Console.WriteLine($"{foe.Name} attacks!");

                        // Do a miss roll
                        var miss = rand.Next(1, 100);
                        if (miss < 98)
                        {
                            var dmg = foe.attack(hero);
                            Console.WriteLine($"{hero.Name} takes {dmg} damage and has {hero.Hp} health left.\n");
                        }
                        else
                        {
                            Console.WriteLine($"{foe.Name} attacks and misses!");
                        }  
                    }
                }

                if (!hero.isAlive())
                {
                    Console.WriteLine("You're hero has fallen!\n");
                    this.Dispose();
                }


                if (!foe.isAlive())
                {
                    Console.WriteLine("***Way to go! Ding-dong the foe is dead***");
                    Console.WriteLine($"***{hero.Name} gains {foe.Experience} XP***");
                    Console.WriteLine("");
                    hero.IncreaseExp(foe.Experience);
                    hero.Kills += 1;
                    battle = false;
                    this.Dispose();
                }
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

        private void LoadFoe(Hero hero)
        {
            // Create a monster pool
            var pool = new List<Monster>();

            // Fill pool with level appropriate monsters
            foreach (var monster in MonsterList)
                if (monster.Ranking < hero.getLevel())
                    pool.Add(monster);

            // Pick a random monster from pool
            var rand = new Random();
            var i = rand.Next(pool.Count);
            Foe = pool[i];
        }

        private void LoadMonsters()
        {
            MonsterList = new List<Monster>();

            string filePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
                $@"\Monsters.csv";
            List<string> lines = new List<string>();

            var line = "";

            using (System.IO.StreamReader file = new System.IO.StreamReader(filePath))
                while ((line = file.ReadLine()) != null)
                {
                    string[] split = line.Split(',');
                    var monster = new Monster(
                        split[0].ToString(),
                        Convert.ToInt32(split[1]),
                        Convert.ToInt32(split[3]),
                        Convert.ToInt32(split[4]),
                        Convert.ToInt32(split[5]));
                    MonsterList.Add(monster);
                }
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
