using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ryasu.API.Maps
{
    public class HitObjectInfo
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int Lane { get; set; }
        public bool IsLongNote => EndTime > 0;

        public TimingPointInfo GetTimingPoint(List<TimingPointInfo> timingPoints)
        {
            // Search through the entire list for the correct point
            for (var i = timingPoints.Count - 1; i >= 0; i--)
            {
                if (StartTime >= timingPoints[i].StartTime)
                    return timingPoints[i];
            }

            return timingPoints.First();
        }
    }
}
