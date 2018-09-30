using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrinkerLibrary
{
    public static class Randomer
    {
        private static Random rand;
        static Randomer()
        {
            rand = new Random();
        }

        public static int Next()
        {
            return rand.Next();
        }
    }
}
