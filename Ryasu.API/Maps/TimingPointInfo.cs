using Ryasu.API.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ryasu.API.Maps
{
    public class TimingPointInfo
    {
        public float StartTime { get; set; }
        public float Bpm { get; set; }
        public TimeSignature Signature { get; set; }

        /// <summary>
        /// Copied name from osu!
        /// When this is true background dim will be 10% brighter each beat and return to its original value.
        /// this resembles the strong part of the song (usually the drop)
        /// </summary>
        public bool KiaiMode { get; set; }
    }
}
