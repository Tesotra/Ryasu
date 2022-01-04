using System;
using System.Collections.Generic;
using System.Text;
using Wobble.Audio.Tracks;

namespace Ryasu.Game.Audio
{
    public static class AudioEngine
    {
        public static AudioTrack Track { get; private set; }

        public static void Load(string path)
        {
            if (Track != null && !Track.IsDisposed)
                Track.Dispose();

            Track = new AudioTrack(path, false, false);
        }

        public static void Load(PathableString path)
        {
            Load(path.Text);
        }
    }
}
