using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildLibrary.BuildExceptions
{
    internal static class Exception
    {
        public static bool NameException(string value)
        {
            if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
                return false;
            return true;
        }

        public static bool LHWException(int value)
        {
            if (value <= 0)
                return false;
            return true;
        }
    }
}
