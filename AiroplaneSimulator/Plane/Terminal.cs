using PilotLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pilot
{
    public static class Terminal
    {
        public static void CheckGame(Airoplane plane, List<Dispatcher> disps)
        {
            if (disps == null)
                throw new ArgumentNullException("Диспетчеры не инициализированны");
            if (plane == null)
                throw new ArgumentNullException("Самолет не инициализирован");


            if (disps.Count < 2)
                throw new ArgumentNullException("Невозможно начать без 2-х или более диспетчеров");

            if (plane.Speed > 0)
                throw new Exception("Cheating!!!");

            disps.ForEach(d =>
            {
                if (d.Height != 0)
                    throw new Exception("Cheating!!!");
            });
        }
    }
}
