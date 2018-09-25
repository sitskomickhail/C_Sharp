using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLibrary
{
    class Bus : Automobile
    {
        private double _patiency;
        private double _topSpeed;
        private double _weight;

        public PrintFinisher Final { get; set; }

        public override double Patency
        {
            get
            {
                return _patiency;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Неверное передаваемое значение");
               _patiency = value;
            }
        }

        public override double TopSpeed
        {
            get
            {
                return _topSpeed;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Неверное передаваемое значение");
                _topSpeed = value;
            }
        }

        public override double Weight
        {
            get
            {
                return _weight;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Неверное передаваемое значение");
                _weight = value;
            }
        }

        public override double EnlSpeed()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
