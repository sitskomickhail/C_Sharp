using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildLibrary.TeamBuilders;

namespace BuildLibrary.BuildElems
{
    public class House
    {
        #region FIELDS
        private int _lenght;
        private int _width;
        private int _height;
        private Basement _base;
        private Roof _roof;
        private Walls[] _walls;
        private Window[] _windows;
        private Door _door;
        #endregion

        public House(int lenght, int width, int height, int windowCount)
        {
            _windows = new Window[windowCount];
            _walls = new Walls[4];
            Lenght = lenght;
            Width = width;
            Height = height;
        }

        public void StartBuilding(Team _team)
        {

        }

        #region PROPS
        public int Height
        {
            get { return _height; }
            protected set { _height = value; }
        }

        public int Width
        {
            get { return _width; }
            protected set { _width = value; }
        }

        public int Lenght
        {
            get { return _lenght; }
            protected set { _lenght = value; }
        }
        #endregion
    }
}
