using System;
using System.Collections.Generic;
using System.Linq;

namespace Ryasu.API.Maps
{
    public class Rys : IComparable<Rys>
    {
        public int SortByNameAscending(string name1, string name2)
        {
            return name1.CompareTo(name2);
        }
        public int Length => HitObjects.Count == 0 ? 0 : HitObjects.Max(x => Math.Max(x.StartTime, x.EndTime));

        public int CompareTo(Rys compare)
        {
            // A null value means that this object is greater.
            if (compare == null)
                return 1;

            else
                return this.Artist.CompareTo(compare.Artist);
        }

        private bool PreviewMode { get; set; }

        public Rys(bool previewMode = false)
        {
            PreviewMode = previewMode;
            if (HitObjects == null)
            {
                HitObjects = new List<HitObjectInfo>();
            }

            if (SliderVelocities == null)
            {
                SliderVelocities = new List<SliderVelocityInfo>();
            }

            if (TimingPoints == null)
            {
                TimingPoints = new List<TimingPointInfo>();
            }
        }

        public string MapName { get; set; }

        public string MapAuthor { get; set; }

        public string Difficulty { get; set; }

        public int KeyCount { get; set; }

        public List<TimingPointInfo> TimingPoints { get; private set; }

        public List<SliderVelocityInfo> SliderVelocities { get; private set; }

        public float Bpm { get; set; }

        public List<HitObjectInfo> HitObjects { get; set; }

        public string Artist { get; set; }

        public string DirectoryPath { get; set; }

        public string MapPath { get; set; }

        public string Background { get; set; }

        public string Audio { get; set; }

        public int PreviewTime { get; set; }

        public float InitialScrollVelocity { get; set; }

        public void Sort()
        {
            if (HitObjects == null)
            {
                HitObjects = new List<HitObjectInfo>();
            }

            if (SliderVelocities == null)
            {
                SliderVelocities = new List<SliderVelocityInfo>();
            }

            if (TimingPoints == null)
            {
                TimingPoints = new List<TimingPointInfo>();
            }

            if (!PreviewMode)
            {
                HitObjects = HitObjects.OrderBy(x => x.StartTime).ToList();
                SliderVelocities = SliderVelocities.OrderBy(x => x.StartTime).ToList();
                TimingPoints = TimingPoints.OrderBy(x => x.StartTime).ToList();
            }
        }

        public bool IsValid()
        {
            // If there aren't any HitObjects
            if (HitObjects.Count == 0 && !PreviewMode)
            {
                //Console.WriteLine("No HitObjects Found");
                return false;
            }

            // If there aren't any TimingPoints
            if (TimingPoints.Count == 0 && !PreviewMode)
            {
                //Console.WriteLine("No TimingPoints Found");
                return false;
            }

            // Check that hit objects are valid.
            if (!PreviewMode)
            {
                foreach (var info in HitObjects)
                {
                    // LN end times should be > start times.
                    if (info.IsLongNote && info.EndTime <= info.StartTime)
                    {
                        //Console.WriteLine("Invalid LN");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
