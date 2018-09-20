using BuildLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildLibrary.BuildElems
{
    internal class Window : IPart
    {
        public bool IsCreated(int value)
        {
            return Int32.Equals(count, this._count);
        }

        public int Remained(int value)
        {
            throw new NotImplementedException();
        }
    }
}
