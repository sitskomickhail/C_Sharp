using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intro
{
    internal abstract class Device
    {
        private string _code;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public abstract string CreateCode();

    }
}
