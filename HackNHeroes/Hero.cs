using System;
using System.IO;

namespace HackNHeroes
{
    internal class Hero
    {
        internal string Name { get; private set; }
        internal int Hp { get; set; }
        internal int HpMax { get; private set; }
        internal Int64 Experience { get; private set; }
        internal int Damage { get; private set; }
        internal int Kills { get; set; }

        public Hero()
        {
            Name = "Conan";
            Hp = 11;
            HpMax = 11;
            Experience = 0;
            Damage = 1;
            Kills = 0;
        }

        public Hero(string name)
        {
            Name = name;
            Hp = 11;
            HpMax = 11;
            Experience = 0;
            Damage = 8;
            Kills = 0;
        }

        public Hero(string name, int hp, int damage)
        {
            Name = name;
            Hp = hp;
            HpMax = hp;
            Damage = damage;
            Experience = 0;
            Kills = 0;
        }

        public void New(string name)
        {
            Name = name;
            Hp = 11;
            HpMax = 11;
            Experience = 0;
            Damage = 8;
            Kills = 0;
        }

        internal int attack(Monster monster)
        {
            var rand = new Random();
            var dmg = rand.Next(0, Damage);
            monster.Hp -= dmg;
            return dmg;
        }

        internal void Rest()
        {
            Hp = HpMax;
        }

        public bool isAlive()
        {
            if (Hp > 0)
                return true;

            return false;
        }

        internal void IncreaseExp(int amount)
        {
            var curLvl = getLevel();
            Experience += amount;
            var chkLvl = getLevel();

            if (chkLvl > curLvl)
                LevelUp(11, 6);
        }

        internal int getLevel()
        {
            // Capping level at 30
            for (int i = 1; i < 30; i++)
            {
                if (Experience > (2 ^ 1) - 1) return i;
            }
            return 1;
        }

        internal void Save()
        {
            // TODO: Use a cipher to save
            string text = $"{Name},{Hp},{HpMax},{Experience},{Damage},{Kills}";
            System.IO.File.WriteAllText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + $@"\{Name}.SAV", text);
        }

        internal void Load(string name)
        {
            // TODO: Load encrypted save
            if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + $@"\{name}.SAV"))
            {
                string text = System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + $@"\{name}.SAV");
                var data = text.Split(',');
                Name = data[0];
                Hp = Convert.ToInt32(data[1]);
                HpMax = Convert.ToInt32(data[2]);
                Experience = Convert.ToInt64(data[3]);
                Damage = Convert.ToInt32(data[4]);
                Kills = Convert.ToInt32(data[5]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: No hero named {name} found!");
                Console.ForegroundColor = ConsoleColor.Green;
            }
           
        }

        private void LevelUp(int hp, int damage)
        {
            HpMax += hp;
            Damage += damage;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"*** {Name} is level {getLevel()}! You should rest ***");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
