using PilotLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pilot
{
    public static class Terminal
    {
        public static void Manage(Airoplane plane)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.RightArrow || keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (keyInfo.Key == ConsoleKey.RightArrow) plane.Speed = 25;
                else plane.Speed = -25;
            }
            else if ((keyInfo.Key == ConsoleKey.RightArrow && keyInfo.Modifiers == ConsoleModifiers.Shift) || 
                (keyInfo.Key == ConsoleKey.LeftArrow && keyInfo.Modifiers == ConsoleModifiers.Shift))
            {
                if (keyInfo.Key == ConsoleKey.RightArrow && keyInfo.Modifiers == ConsoleModifiers.Shift) plane.Speed = 50;
                else plane.Speed = -50;
            }

            if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (keyInfo.Key == ConsoleKey.UpArrow) plane.PlaneHeight = 25;
                else plane.PlaneHeight = -25;
            }
            else if ((keyInfo.Key == ConsoleKey.UpArrow && keyInfo.Modifiers == ConsoleModifiers.Shift) ||
                (keyInfo.Key == ConsoleKey.DownArrow && keyInfo.Modifiers == ConsoleModifiers.Shift))
            {
                if (keyInfo.Key == ConsoleKey.UpArrow && keyInfo.Modifiers == ConsoleModifiers.Shift) plane.PlaneHeight = 50;
                else plane.PlaneHeight = -50;
            }


            if (keyInfo.Key == ConsoleKey.OemPlus)
                plane.AddDispatcher();
            else if (keyInfo.Key == ConsoleKey.OemMinus)
            {
                Console.Write("Введите номер диспетчера которого вы хотите удалить: ");
                int pos = Int32.Parse(Console.ReadLine().ToString());
                plane.RemoveDispatcher(pos);
            }

            if (keyInfo.Key != ConsoleKey.OemPlus && keyInfo.Key != ConsoleKey.OemMinus && 
                keyInfo.Key != ConsoleKey.UpArrow && keyInfo.Key != ConsoleKey.DownArrow &&
                keyInfo.Key != ConsoleKey.RightArrow && keyInfo.Key != ConsoleKey.LeftArrow &&
                (keyInfo.Key != ConsoleKey.UpArrow && keyInfo.Modifiers != ConsoleModifiers.Shift) &&
                (keyInfo.Key != ConsoleKey.DownArrow && keyInfo.Modifiers != ConsoleModifiers.Shift)&&
                (keyInfo.Key != ConsoleKey.LeftArrow && keyInfo.Modifiers != ConsoleModifiers.Shift) &&
                (keyInfo.Key != ConsoleKey.RightArrow && keyInfo.Modifiers != ConsoleModifiers.Shift))
            {
                plane.Speed = 0;
                plane.PlaneHeight = 0;
            }
        }

        public static void ShowDispInfo(Airoplane plane)
        {
            List<string> reports = plane.GetDispReports;
            Console.ForegroundColor = ConsoleColor.Green;
            reports.ForEach(rep => Console.WriteLine(rep));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void ShowPlainInfo(Airoplane plane)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Высота: {0}", plane.PlaneHeight);
            Console.WriteLine("Скорость: {0}", plane.Speed);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
