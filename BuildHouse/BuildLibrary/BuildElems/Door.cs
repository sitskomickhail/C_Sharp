using BuildLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildLibrary.BuildElems
{
    internal class Door : IPart
    {
        private int _count;

        public void AddSlice()
        {
            _count++;
        }

        public bool IsCreated(int count)
        {
            return Int32.Equals(count, this._count);
        }

        public int Remained(int count)
        {
            if (_count == count)
                return 0;
            return _count - count;
        }
    }
}
