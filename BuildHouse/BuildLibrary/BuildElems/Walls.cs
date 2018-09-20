using BuildLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildLibrary.BuildElems
{
    internal class Walls : IPart
    {
        private int _height;    
        public bool IsCreated(int height)
        {
            return Int32.Equals(height, this._height);

        }

        public int Remained(int value)
        {
            throw new NotImplementedException();
        }
    }
}
