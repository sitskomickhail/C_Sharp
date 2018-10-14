using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PilotLib
{
    public enum PlainType
    {
        Takeoff,
        Accelerate,
        SlowDown,
        Landing
    }
    
    public class Dispatcher
    {
        #region FIELDS
        private string _name;
        private int _wCorrect;
        private int _erPoints;
        private int _recomenHeight;
        private int _maxSpeed = 1000;
        private static int _count = 1;
        #endregion

        #region CTOR
        internal Dispatcher()
        {
            _wCorrect = Randomer.Next(-200, 200);
            Name = _count.ToString();
            _erPoints = 0;
            _count++;
        }
        #endregion

        private void CalcErrorPoints(int height)
        {
            int temp = Math.Abs(_recomenHeight - height);
            if (temp >= 300 && temp < 600)
                _erPoints += 25;
            else if (temp >= 600 && temp < 1000)
                _erPoints += 50;

            if (temp >= 1000)
                throw new Exception("Самолет разбился!");

            if (_erPoints >= 1000)
                throw new Exception("Пилот не годен к полетам!");
        }
        
        private void CalcHeight(int speed)
        {
            _recomenHeight = 7 * speed - _wCorrect;
            if (_recomenHeight < 0)
                _recomenHeight = 0;
        }

        public void CheckDispReport(int speed, int height, List<string> reports, PlainType type)
        {
            int tempError = _erPoints;
            string res;

            if (speed == 0 && height == 0 && (type != PlainType.Landing && type != PlainType.Takeoff))
                throw new Exception("Самолет разбился!");

            CalcHeight(speed);
            CalcErrorPoints(height);

            res = $"Диспетчер {Name}\nРекомендуемая высота: {_recomenHeight}\nШтрафных очков: {_erPoints}\n";

            if (speed > _maxSpeed)
            {
                res += $"Самолет превышает максимальную скорость!\nНемедленно снизьте скорость!\nНачислено 100 штрафных очков!\n";
                _erPoints += 100;
                CalcHeight(_maxSpeed);
            }
            reports.Add(res);            
        }

        #region PRTIES
        public int RecomendedHeight
        {
            get { return _recomenHeight; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int ErrorPoints { get { return _erPoints; } }
        #endregion
    }
}
