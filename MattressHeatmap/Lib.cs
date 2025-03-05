using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public static class Lib
    {
        public static Color GetColor(double heatValue, List<ColorRange> colorRanges, HeatMapType type)
        {
            double multiplier = type == HeatMapType.Caps ? 1E-12 : 1;

            for (int i = 0; i < colorRanges.Count; i++)
            {
                if (colorRanges[i].Start * multiplier <= heatValue && heatValue <= colorRanges[i].End * multiplier)
                    return colorRanges[i].Color;
            }

            return Color.White;
        }
    }
}
