using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class PressurePoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double HeatValue { get; set; }

        public PressurePoint()
        {

        }

        public PressurePoint(int x, int y, double heatValue)
        {
            X = x;
            Y = y;
            HeatValue = heatValue;
        }
    }
}
