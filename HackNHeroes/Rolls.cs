using System;
using System.Collections.Generic;
using System.Text;

namespace HackNHeroes
{
    internal static class Rolls
    {
        internal static int Initiative()
        {
            var rand = new Random();
            return rand.Next(1, 100);
        }
    }
}
