using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intro
{
    internal class Notebook : PC
    {
        private double _display;

        public double Display
        {
            get { return _display; }
            set { _display = value; }
        }

        public override void Testing()
        {
            base.Testing();
            Console.WriteLine("Test Display");
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Model, Fp, _display);
        }

        public override decimal Calculate()
        {
            return base.Calculate() * 1.5m;
        }

        public Notebook(string model, double fp) : base(model, fp) {  }
    }
}