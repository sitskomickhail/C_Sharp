using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotLib
{
    public class Airoplane
    {
        #region FIELDS
        private Action<int, int, List<string>, PlainType> Report;
        private List<Dispatcher> disps;
        private List<string> reports;
        private int _maxSpeed;
        private int _error;
        private int _height;
        private int _speed;
        #endregion

        #region CTOR
        public Airoplane(int dispCount)
        {
            if (dispCount < 2)
                throw new ArgumentOutOfRangeException("Невозможно инициализровать меньше 2 диспетчеров");

            disps = new List<Dispatcher>(dispCount);
            for (int i = 0; i < dispCount; i++) { disps.Add(new Dispatcher()); }
            disps.ForEach(d => Report += d.CheckDispReport);
            reports = new List<string>();
            _speed = 0;
            FlightType = PlainType.Takeoff;
        }
        #endregion

        #region METHODS
        public int ErrorPoints()
        {
            disps.ForEach(d => _error += d.ErrorPoints);
            return _error;
        }
        #endregion

        #region ADD_REMOVE_DISP
        public void AddDispatcher()
        {
            Dispatcher newDisp = new Dispatcher();
            disps.Add(newDisp);
            Report += newDisp.CheckDispReport;
        }

        public void RemoveDispatcher(int dispPos)
        {
            if (dispPos > disps.Count || dispPos <= 0)
                return;
            if (disps.Count - 1 < 2)
                throw new Exception("Полет не может продолжаться с одним диспетчером!");

            int pos = 0, check = 0;

            bool finded = false;
            disps.ForEach(d =>
            {
                if (Int32.Parse(d.Name) == dispPos)
                {
                    finded = true;
                    pos = check;
                }
                check++;
            });

            if (finded)
            {
                Report -= disps[pos].CheckDispReport;
                disps.Remove(disps[pos]);
            }
        }
        #endregion

        #region PRTIES
        public int Speed
        {
            get { return _speed; }
            set
            {
                if (_speed >= 50 && FlightType != PlainType.Landing && value < 0)
                    return;
                _speed += value;
                if (_speed < 0)
                    _speed = 0;
                if (_maxSpeed < _speed)
                    _maxSpeed = _speed;

                if (_speed >= 1000 & _maxSpeed >= 1000)
                    FlightType = PlainType.SlowDown;
                if (reports != null)
                    reports.Clear();
                if (_speed >= 50)
                    Report(_speed, _height, reports, FlightType);
            }
        }

        public int PlaneHeight
        {
            get { return _height; }
            set
            {
                if (_speed < 50)
                    return;
                _height += value;
                if (_height < 0)
                    _height = 0;

                if (_height >= 100 & FlightType == PlainType.Takeoff)
                    FlightType = PlainType.Accelerate;
                if (_height <= 100 & FlightType == PlainType.SlowDown)
                    FlightType = PlainType.Landing;
                if (reports != null)
                    reports.Clear();
                Report(_speed, _height, reports, FlightType);
            }
        }

        public PlainType FlightType { get; private set; }

        public List<string> GetDispReports { get { return reports; } }
        #endregion
    }
}
