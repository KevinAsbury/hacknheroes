using System;
using System.Collections.Generic;
using System.Text;

namespace HackNHeroes
{
    class Foe : ICreature
    {
        public string name { get; set; }
        public int damage { get; set; }
        public int hp { get; set; }
        public int hpMax { get; set; }

        public void Save()
        {

        }
    }
}
