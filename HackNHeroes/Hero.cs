using System;
using System.Collections.Generic;
using System.Text;

namespace HackNHeroes
{
    internal class Hero : ICreature 
    { 
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Hp { get; set; }
        public int HpMax { get; set; }

        public Hero(string name, int hp, int damage)
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

        internal void attack()
        {

        }

        internal void getHit()
        {

        }
    }
}
