using System;
using System.Collections.Generic;
using System.Text;

namespace HackNHeroes
{
    internal class Foe : ICreature
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Hp { get; set; }
        public int HpMax { get; set; }

        public Foe(string name, int hp, int damage)
        {
            Name = name;
            Hp = hp;
            HpMax = hp;
            Damage = damage;
        }
        public void Save()
        {

        }

        public bool isAlive()
        {
            return true;
        }

    }
}
