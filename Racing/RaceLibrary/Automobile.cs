using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLibrary
{
    public delegate void SetStart(Automobile[] racers);
    public delegate void StartRace(Automobile[] racers);
    public delegate void PrintFinisher(Automobile win_auto);

    abstract public class Automobile
    {
        abstract public double TopSpeed { get; set; }
        abstract public double Weight { get; set; }
        abstract public double Patency { get; set; }

        abstract public void Move();
        abstract public double EnlSpeed();
    }
}
