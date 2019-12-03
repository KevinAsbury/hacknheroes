using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace HackNHeroes
{
    class Creature : ICreature
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Hp { get; set; }
        public int HpMax { get; set; }

        public Creature(string name, int hp, int damage)
        {
            Name = name;
            Hp = hp;
            HpMax = hp;
            Damage = damage;
        }

        public bool isAlive()
        {
            if (Hp > 0)
                return true;

            return false;
        }

        internal int attack(Creature foe)
        {
            var rand = new Random();
            var dmg = rand.Next(0, Damage);
            foe.Hp -= dmg;
            return dmg;
        }
    }
}
