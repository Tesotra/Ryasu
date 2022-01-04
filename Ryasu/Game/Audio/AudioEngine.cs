using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Wobble.Audio.Tracks;

namespace Ryasu.Game.Audio
{
    public static class AudioEngine
    {
        public static AudioTrack Track { get; private set; }

        static void DisposeTrack()
        {
            if (Track != null && !Track.IsDisposed)
                Track.Dispose();
        }

        public static void Load(byte[] stream, bool autoDispose = true)
        {
            if (autoDispose)
                DisposeTrack();

            Track = new AudioTrack(stream, false, false);
        }

        public static void Load(string path)
        {
            DisposeTrack();

            if (File.Exists(path))
            {
                var bytes = File.ReadAllBytes(path);
                Load(bytes, false);
            }
            else
            {
                throw new FileNotFoundException($"Error Loading AudioTrack: {path} not found.");
            }
        }

        public static void Load(PathableString path)
        {
            Load(path.Text);
        }
    }
}
