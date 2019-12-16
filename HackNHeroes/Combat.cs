using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace HackNHeroes
{
    internal class Combat : IDisposable
    {
        // Declare the variables
        const int HeroMissChance = 2;
        const int FoeMissChance = 2;
        internal Monster Foe { get; set; } // The Foe
        internal bool BattleOver;
        private List<Monster> MonsterList { get; set; } // List of monsters
        
        // Free up resources after battle
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Flag for garbage collection
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
                // Load the list of monsters
                // and pick a foe
                LoadMonsters();
                LoadFoe(hero);
            }
        }

        internal void Fight(Hero hero, Monster foe)
        {
            // Return if the foe or hero are dead
            if (!foe.isAlive() || !hero.isAlive())
            {
                BattleOver = true;
                return;
            }

            // Determine who attacks first this round
            if (hero.isAlive() && foe.isAlive())
            {
                // Pick a number between 1 and 100
                var rand = new Random();
                var coinFlip = rand.Next(1, 100);

                // Determine who attacks
                if (coinFlip > 50 && hero.isAlive() && foe.isAlive())
                {
                    // The Hero wins the roll and attacks
                    Console.WriteLine($"{hero.Name} attacks!");

                    // Do a miss roll
                    var miss = rand.Next(1, 100);
                    if (miss < 100 - HeroMissChance)
                    {
                        var dmg = hero.attack(foe);
                        Console.WriteLine($"{foe.Name} takes {dmg} damage and has {foe.Hp} health left.\n");
                    } else
                    {
                        Console.WriteLine($"{hero.Name} swings and misses!\n");
                    } 
                }
                else if (coinFlip < 51 && hero.isAlive() && foe.isAlive())
                {
                    Console.WriteLine($"{foe.Name} attacks!");

                    // Do a miss roll
                    var miss = rand.Next(1, 100);
                    if (miss < 100 - FoeMissChance)
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
                this.BattleOver = true;
                this.Dispose();
            }


            if (!foe.isAlive())
            {
                Console.WriteLine("***Way to go! Ding-dong the foe is dead***");
                Console.WriteLine($"***{hero.Name} gains {foe.Experience} XP***");
                Console.WriteLine("");
                hero.IncreaseExp(foe.Experience);
                hero.Kills += 1;
                this.BattleOver = true;
                this.Dispose();
            }
        }

        // Call on the Dispose method
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
                $@"{Path.DirectorySeparatorChar}Monsters.csv";
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
    }
}
