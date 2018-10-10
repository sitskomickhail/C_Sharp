using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PilotLib
{
    public class Dispatcher
    {
        private int _wCorrect = Randomer.Next(-200, 200);
        private int _erPoints;
        private int _height;

        public int ErrorPoints
        {
            get { return _erPoints; }
            set { _erPoints = value; }
        }

        public int Height
        {
            get { return _height; }
        }

        public void CalcHeight(Airoplane plane)
        {
            _height = 7 * plane.Speed - _wCorrect;
            if (_height < 0)
                _height = 0;
        }


    }
}
