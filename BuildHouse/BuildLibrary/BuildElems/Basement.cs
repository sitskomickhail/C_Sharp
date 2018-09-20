using BuildLibrary.Interfaces;
using BuildLibrary.TeamBuilders;
using System;

namespace BuildLibrary.BuildElems
{
    internal class Basement : IPart
    {
        #region FIELDS
        private int _crLenght;
        #endregion

        #region IRELIZ
        public bool IsCreated(int _length)
        {
            if (Remained(_length) == 0)
                return true;
            return false;
        }

        public int Remained(int _length)
        {
            if (_length == _crLenght)
                return 0;
            return _length - _crLenght;
        }
        #endregion

        #region METHODS
        public void AddSlice(Worker builder)
        {
            _crLenght++;
            builder.CheckWork();
        }
        #endregion

        #region PROP
        public int CreatedLength { get { return _crLenght; } }
        #endregion
    }
}
