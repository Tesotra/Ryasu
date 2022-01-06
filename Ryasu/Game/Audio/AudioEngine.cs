using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Wobble.Audio.Samples;
using Wobble.Audio.Tracks;

namespace Ryasu.Game.Audio
{
    public static class AudioEngine
    {
        public static AudioTrack Track { get; private set; }

        public static Dictionary<string, AudioSample> LoadedSamples = new Dictionary<string, AudioSample>();

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

        public static AudioSample LoadSample(string path, bool cache = false)
        {
            AudioSample tmp = null;

            if (LoadedSamples.TryGetValue(path, out tmp))
                return tmp;

            byte[] byteArray = RyasuGame.Instance.Resources.Get(path);

            tmp = new AudioSample(byteArray);

            if(cache)
                LoadedSamples.Add(path, tmp);

            return tmp;
        }

        public static AudioSample LoadSampleExternal(string path, bool cache = false)
        {
            AudioSample tmp = null;

            if (LoadedSamples.TryGetValue(path, out tmp))
                return tmp;

            if (!File.Exists(path))
                return null;

            byte[] byteArray = File.ReadAllBytes(path);

            tmp = new AudioSample(byteArray);

            if(cache)
                LoadedSamples.Add(path, tmp);

            return tmp;
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
