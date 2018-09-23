using System;
using BuildLibrary.BuildElems;
using BuildLibrary.TeamBuilders;

namespace BuildProject
{
    class Program
    {
        static void Main(string[] args)
        {
            const int lenght = 8;
            const int height = 15;
            const int width = 6;
            const int _windowsCount = 30;
            const int _doorsCount = 2;
            Team _team = new Team(10);
            House _home = new House(lenght, height, width, _windowsCount, _doorsCount);

            _team.StartBuilding(_home);
            string[] report = _team.GetReport;
            Console.WriteLine(report[0]);
            for (int i = 1; i < report.Length; i++)
            {
                Console.WriteLine("{0}  -  {1}", i, report[i]);
            }
            Console.Read();
        }
    }
}
