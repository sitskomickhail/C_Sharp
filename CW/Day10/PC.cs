using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intro
{
    internal class PC : Device
    {
        private string _model;
        private double _fp;
        protected decimal _price;

        public override string CreateCode()
        {
            return "111112222333";
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", _model, _fp);
        }

        public PC(string model, double fp)
        {
            _model = model;
            _fp = fp;
            _price = 1000;
        }

        public virtual decimal Calculate()
        {
            return _price;
        }

        public virtual void Testing()
        {
            Console.WriteLine("Test FP");
        }

        public string Model
        {
            get { return _model; }
            private set { _model = value; }
        }

        
        public double Fp
        {
            get { return _fp; }
            private set { _fp = value; }
        }

    }
}
