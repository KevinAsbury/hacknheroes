using System;
using System.Collections.Generic;
using System.Text;

namespace HackNHeroes
{
    internal class Combat
    {
        internal void DeathMatch(Hero hero, Foe foe)
        {
            while (hero.isAlive() && foe.isAlive())
            {   
                // FIGHT!
            }
        }

        internal void Round(Hero hero, Foe foe)
        {
            if (hero.isAlive() && foe.isAlive())
            {
                // HIT!
            }
        }

    }
}
