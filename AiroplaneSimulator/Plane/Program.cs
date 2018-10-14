using PilotLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pilot
{
    class Program
    {
        static void Main(string[] args)
        {
            Airoplane plane = new Airoplane(2);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Shift + →\t(+50 speed)\t" +
                              "Shift + ↑\t(+50 height)\n" +
                              "Shift + ←\t(-50 speed)\t" +
                              "Shift + ↓\t(-50 height)");
            Console.WriteLine("\t\tPress Any Key to start!!!");
            while (true)
            {
                Terminal.ShowDispInfo(plane);
                Console.WriteLine();
                Terminal.ShowPlainInfo(plane);
                Terminal.Manage(plane);
                if (plane.PlaneHeight == 0 && plane.Speed == 0 && plane.FlightType == PlainType.Landing)
                {
                    Console.WriteLine();
                    Console.WriteLine("Вы прошли испытание набрав: {0} штрафных очков!", plane.ErrorPoints());
                    break;
                }
                Thread.Sleep(50);
                Console.Clear();
            }

            Console.ReadLine();
        }
    }
}
