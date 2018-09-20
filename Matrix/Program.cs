using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First Array:");
            Matrix FArray = new Matrix();
            FArray.InitRandom();
            FArray.Print();

            Console.WriteLine();
            Console.WriteLine("Change Diagonal Method");
            FArray.ChangeDiagonal();
            FArray.Print();

            Console.WriteLine();
            Console.WriteLine("Sort method");
            Matrix.Sort(FArray);
            FArray.Print();

            Console.WriteLine();
            Console.WriteLine("Second Array:");
            Matrix SArray = new Matrix(3, 6);
            SArray.InitRandom();
            SArray.Print();

            Console.WriteLine();
            Console.WriteLine("Multiplication first * second");
            int[,] Array = FArray.Multi(SArray);
            int MinSizeX, MinSizeY;

            if (FArray.GetColumnSize() < SArray.GetColumnSize()) MinSizeX = FArray.GetColumnSize();
            else MinSizeX = SArray.GetColumnSize();

            if (FArray.GetLineSize() < SArray.GetLineSize()) MinSizeY = FArray.GetLineSize();
            else MinSizeY = FArray.GetLineSize();

            for (int i = 0; i < MinSizeX; i++)
            {
                for (int j = 0; j < MinSizeY; j++)
                {
                    Console.Write("{0},  ", Array[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Transpose second array");
            SArray.Transpose();
            SArray.Print();

            Console.WriteLine();
            Console.WriteLine("Transpose same array without object");
            Matrix.Traspose(SArray);
            SArray.Print();

            int Min = SArray.Min();
            int Max = SArray.Max();
            Console.WriteLine();
            Console.WriteLine("Same array\nMin = {0}\nMax = {1}", Min, Max);
            Console.Read();
        }
    }
}
