using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildLibrary.Interfaces
{
    internal interface IWorker
    {
        string Name { get; set; }
        string Position { get; }

        void CheckWork(IPart obj, int _workRemaining);
    }
}
