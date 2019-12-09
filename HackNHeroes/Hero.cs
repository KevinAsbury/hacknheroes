using System;

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

        internal void Rename(string name)
        {
            Name = name;
        }

        internal void PrintStats()
        {

        }

        internal void Save()
        {
            // TODO: Use a cipher to save
        }

        private void LevelUp(int hp, int damage)
        {
            HpMax += hp;
            Damage += damage;
        }
    }
}
