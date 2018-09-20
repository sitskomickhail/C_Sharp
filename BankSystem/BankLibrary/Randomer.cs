using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    internal static class Randomer
    {
        private static Random rand;

        static Randomer()
        {
            rand = new Random();
        }
        public static string Next(int size)
        {
            char[] arr = new char[size];
            for (int i = 0; i < size; i++)
            {
                switch (rand.Next(1, 4))
                {
                    case 1:
                        arr[i] = Convert.ToChar(rand.Next(48, 57));
                        break;
                    case 2:
                        arr[i] = Convert.ToChar(rand.Next(65, 90));
                        break;
                    case 3:
                        arr[i] = Convert.ToChar(rand.Next(97, 122));
                        break;
                    default:
                        break;
                }
            }
            return new string(arr);
        }
    }
}