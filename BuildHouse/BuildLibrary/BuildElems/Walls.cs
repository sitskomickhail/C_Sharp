using BuildLibrary.Interfaces;
using BuildLibrary.TeamBuilders;

namespace BuildLibrary.BuildElems
{
    internal class Walls : IPart
    {
        #region FIELDS
        private int _crHeight;
        private int _fullHeight;
        private decimal _pct;
        #endregion

        #region CTOR
        public Walls(int height)
        {
            _fullHeight = height;
            _pct = (_crHeight * 100) / _fullHeight;
        }
        #endregion

        #region IRELIZ
        public void AddSlice(Worker builder)
        {
            _crHeight++;
            _pct = (_crHeight * 100) / _fullHeight;
        }

        public decimal Pct { get { return _pct; } }
        #endregion

        #region PROP
        public int CreatedLength { get { return _crHeight; } }
        #endregion
    }
}
