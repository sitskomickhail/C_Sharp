using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intro
{
    internal class GameNotebook : Notebook
    {
        private bool _hasJoystick;
        public bool HasJoystick
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }


        }
        public GameNotebook(string model, double fp) : base(model, fp) {  }

        public override decimal Calculate()
        {
            return _price * 2m;
        }



        public override void Testing()
        {
            base.Testing();
            Console.WriteLine("Test Joystick");
        }
    }
}