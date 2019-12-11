using System;
using System.Collections.Generic;
using System.Text;

namespace HackNHeroes
{
    internal class Monster
    {
        internal string Name { get; private set; }
        internal int Hp { get; set; }
        internal int HpMax { get; private set; }
        internal int Damage { get; private set; }
        internal int Ranking { get; private set; }
        internal int Experience { get; private set; }

        public Monster()
        {
            Name = "Thoth-Amon";
            Hp = 12;
            HpMax = 12;
            Damage = 1;
            Ranking = 1;
            Experience = 100;
        }

        public Monster(string name, int hp, int damage, int ranking, int experience)
        {
            Name = name;
            Hp = hp;
            HpMax = hp;
            Damage = damage;
            Ranking = ranking;
            Experience = experience;
        }

        public bool isAlive()
        {
            if (Hp > 0)
                return true;

            return false;
        }

        internal int attack(Hero hero)
        {
            var rand = new Random();
            var dmg = rand.Next(1, Damage);
            hero.Hp -= dmg;
            return dmg;
        }
    }
}
