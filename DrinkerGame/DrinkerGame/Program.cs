using DrinkerLibrary;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DrinkerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            DateTime start = new DateTime();
            start = DateTime.Now;
            int turns = 0;
            List<Player> players = new List<Player>()
            {
                new Player() { Name = "Ivan", Age = 25, Salary = 7000},
                new Player() { Name = "Alex", Age = 35, Salary = 2550},
                new Player() { Name = "Inna", Age = 20, Salary = 5500},
                new Player() { Name = "Misha", Age = 18, Salary = 5800},
                new Player() { Name = "Sofia", Age = 16, Salary = 9400},
                new Player() { Name = "John", Age = 41, Salary = 3500},
            };

            game.Shuffle();
            game.SetPlayerCards(players);

            Player rndW = new Player();
            int line = 0;
            while (true)
            {
                Thread.Sleep(500);
                turns++;
                rndW = game.StartGame(players);
                int plCount = players.Count;
                for (int i = 0; i < plCount; i++)
                {
                    if (players[i].CCount == 0)
                    {
                        Console.WriteLine("{0} lose game after: {1} seconds", players[i].Name, (DateTime.Now - start).Seconds);
                        players.Remove(players[i]);
                        line++;
                        plCount--;
                        i--;
                    }
                }
                Console.Write("GAME IS RUNNING");
                if (rndW.CCount == 36)
                    break;
                Thread.Sleep(500);
                ClearCurentCinsoleLine();
            }
            ClearCurentCinsoleLine();
            Console.WriteLine("\nThe game ended after: {0} seconds\n  Winner: {1} get all 36 cards after {2} turns", (DateTime.Now - start).Seconds, rndW.Name, turns);
            Console.Read();
        }

        public static void ClearCurentCinsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);

        }


    }
}
