using BuildLibrary.Interfaces;
using BuildLibrary.TeamBuilders;

namespace BuildLibrary.BuildElems
{
    internal class Door : IPart
    {
        #region FIELDS
        private int _crLenght;
        private int _fullLenght;
        private decimal _pct;
        #endregion

        #region CTOR
        public Door()
        {
            _fullLenght = 1;
            _pct = (_crLenght * 100) / _fullLenght;
        }
        #endregion

        #region IRELIZ
        public void AddSlice(Worker builder)
        {
            _crLenght++;
            _pct = (_crLenght * 100) / _fullLenght;
        }

        public decimal Pct { get { return _pct; } }
        #endregion
    }
}
