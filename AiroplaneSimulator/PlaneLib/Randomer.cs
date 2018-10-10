using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PilotLib
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

        public static int Next(int num1)
        {
            return rand.Next(num1);
        }

        public static int Next(int num1, int num2)
        {
            return rand.Next(num1, num2);
        }
    }
}
