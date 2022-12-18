using AzemitologaUzdevums.Engine.General.Draw;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzemitologaUzdevums.Engine.General.Math
{
    public class Vector2D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Coord AsCoord { get => new Coord { X = (short)X, Y = (short)Y }; }

        public Vector2D(double x = 0.0, double y = 0.0)
        {
            X = x;
            Y = y;
        }
    }
}
