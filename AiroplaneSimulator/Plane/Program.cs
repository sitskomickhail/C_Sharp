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
            Airoplane plane = new Airoplane();
            List<Dispatcher> disps = new List<Dispatcher>(2);
            Terminal.CheckGame(plane, disps);

            while (true)
            {
                disps.ForEach(d => Console.WriteLine("Диспетчер: {0}", d.Height));

            }
        }
    }
}
