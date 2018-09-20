using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            PC[] comps = new PC[3];
            comps[0] = new PC("Sony", 2.5); // UpCast
            comps[1] = new Notebook("Apple", 1.9) { Display = 2.2 };
            comps[2] = new GameNotebook("Samsung", 2.4) { Display = 3.5 };


            for (int i = 0; i < comps.Length; i++)
            {
                Console.WriteLine("Price: {0:N2}", comps[i].Calculate());
                Test(comps[i]);
                Console.WriteLine(comps[i]);
                Console.WriteLine();
            }

            Console.Read();
        }

        public static void Test(PC pc)
        {
            //pc.Testing();

            //Notebook notebook = (Notebook)pc; // DownCast
            //if (pc is Notebook)
            //{
            //    Notebook notebook = (Notebook)pc;
            //}
            Notebook notebook = pc as Notebook;
            if (notebook != null)
            {

            }
        }
    }
}