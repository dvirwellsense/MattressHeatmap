using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public enum PressurePointState { Static, FadeIn, FadeOut };

    public class StreamPressurePoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double HeatValue { get; set; }
        public double Density { get; set; }
        public double MinDensity { get; set; }
        public PressurePointState State { get; set; }
        public double Speed { get; set; }

        public StreamPressurePoint()
        {

        }

        public StreamPressurePoint(int x, int y, double heatValue, double density, double minDensity, PressurePointState state, double speed)
        {
            X = x;
            Y = y;
            HeatValue = heatValue;
            Density = density;
            MinDensity = minDensity;
            State = state;
            Speed = speed;
        }
    }
}
