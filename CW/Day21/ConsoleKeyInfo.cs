using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Write("Введите символ: ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if ((keyInfo.Modifiers & ConsoleModifiers.Shift)   != 0    || 
                    (keyInfo.Modifiers & ConsoleModifiers.Alt)     != 0    || 
                    (keyInfo.Modifiers & ConsoleModifiers.Control) != 0 )
                    Console.WriteLine(" Вы ввели: {0}+{1}", keyInfo.Key, keyInfo.Modifiers);
                else 
                    Console.WriteLine(" Вы ввели: {0}", keyInfo.Key);
                if (keyInfo.Modifiers == ConsoleModifiers.Alt && keyInfo.Key == ConsoleKey.F4)
                    break;
            }


        }
    }
}
