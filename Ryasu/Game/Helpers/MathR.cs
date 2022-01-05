using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ryasu.Game.Helpers
{
    public static class MathR
    {
        /// <summary>
        /// Calculates the distance between point A and point B
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double DistanceFrom(Vector2 a, Vector2 b)
        {
            double dX0 = a.X;
            double dY0 = a.Y;
            double dX1 = b.X;
            double dY1 = b.Y;
            return Math.Sqrt((dX1 - dX0) * (dX1 - dX0) + (dY1 - dY0) * (dY1 - dY0));
        }
    }
}
