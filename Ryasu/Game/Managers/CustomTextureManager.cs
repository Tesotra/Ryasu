using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Wobble.Assets;

namespace Ryasu.Game.Managers
{
    public class CustomTextureManager
    {
        public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

        public static Texture2D Load(string path, string name)
        {
            if (name != null && Textures.ContainsKey(name))
                return Textures[name];

            if (!File.Exists(path))
                return null;

            var tex = AssetLoader.LoadTexture2D(File.ReadAllBytes(path));
            if (name != null)
                Textures.Add(name, tex);

            return tex;
        }

        public static Texture2D Load(string path)
        {
            return Load(path, null);
        }
    }
}
