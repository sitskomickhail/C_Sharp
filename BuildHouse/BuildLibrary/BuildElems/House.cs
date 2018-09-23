using System;
using BuildLibrary.Interfaces;

namespace BuildLibrary.BuildElems
{
    public class House
    {
        #region FIELDS
        private IPart[] _parts;
        private int _lenght;
        private int _width;
        private int _height;

        private int _windowCount;
        private int _doorsCount;
        #endregion

        #region CONSTS
        private const int _baseCount = 1;
        private const int _roofCount = 1;
        private const int _wallsCount = 4;
        #endregion

        #region CTOR
        public House(int lenght, int height, int width, int windowCount, int doorsCount)
        {
            Lenght = lenght;
            Height = height;
            Width = width;

            if (windowCount < 0 || doorsCount < 0)
                throw new ArgumentOutOfRangeException("Неверные аргументы");

            _windowCount = windowCount;
            _doorsCount = doorsCount;

            _parts = new IPart[_baseCount + _roofCount + _wallsCount + windowCount + doorsCount];
            _parts[0] = new Basement(_lenght);
            _parts[1] = new Roof(_lenght);
            for (int i = 2; i < 6; i++)
            {
                _parts[i] = new Walls(_height);
            }
            int a = 5;
            for (int i = a; i < 5 + windowCount; i++)
            {
                _parts[i] = new Window();
                a++;
            }
            for (int i = a; i < a + doorsCount; i++) { _parts[i] = new Door(); }
        }
        #endregion

        #region IDNDEXER
        public IPart this[int index]
        {
            get { return _parts[index]; }
        }
        #endregion

        #region PROPS
        public int WinCount { get { return _windowCount; } }
        public int DoorCount { get { return _doorsCount; } }

        public static int AllCount
        { get { return _baseCount + _roofCount + _wallsCount; } }

        public int Height
        {
            get { return _height; }
            protected set
            {
                if (!BuildExceptions.Exception.LHWException(value))
                    throw new ArgumentOutOfRangeException("Null argument"); _height = value;
            }
        }

        public int Width
        {
            get { return _width; }
            protected set
            {
                if (!BuildExceptions.Exception.LHWException(value))
                    throw new ArgumentOutOfRangeException("Null argument"); _width = value;
            }
        }

        public int Lenght
        {
            get { return _lenght; }
            protected set
            {
                if (!BuildExceptions.Exception.LHWException(value))
                    throw new ArgumentOutOfRangeException("Null argument"); _lenght = value;
            }
        }
        #endregion
    }
}
