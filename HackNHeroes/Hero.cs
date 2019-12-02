using System;
using System.Collections.Generic;
using System.Text;

namespace HackNHeroes
{
    internal class Hero : ICreature 
    { 
        public string name { get; set; }
        public int damage { get; set; }
        public int hp { get; set; }
        public int hpMax { get; set; }

        public void Save()
        {

        }

        internal void attack()
        {

        }

        internal void getHit()
        {

        }
    }
}
