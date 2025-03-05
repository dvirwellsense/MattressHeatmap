using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class SamplingParameters
    {
        public int Interval { get; set; }
        public bool AllFrames { get; set; }
        public bool IncludePressures { get; set; }

        public SamplingParameters()
        {
            Interval = 1000;
            AllFrames = false;
            IncludePressures = true;
        }

        public SamplingParameters(int interval, bool allFrames, bool includePressures)
        {
            Interval = interval;
            AllFrames = allFrames;
            IncludePressures = includePressures;
        }
    }
}
