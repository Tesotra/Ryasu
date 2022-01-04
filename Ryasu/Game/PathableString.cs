using System;
using System.Collections.Generic;
using System.Text;

namespace Ryasu.Game
{
    public class PathableString
    {
        public string Text { get; private set; }

        public PathableString(string text)
        {
            var dir = System.IO.Directory.GetCurrentDirectory();
            var appdata = Environment.GetEnvironmentVariable("localappdata");
            var osu = $"{appdata}/osu!";
            Text = text.Replace("[dir]", dir).Replace("[songs]",$"{dir}/Songs").Replace("[skins]",$"{dir}/Skins").Replace("[osu]",osu);
        }

        public static implicit operator PathableString(string text)
        {
            //Avoid NULL text
            if (text == null)
                return new PathableString("");

            return new PathableString(text);
        }

        public bool IsEmpty() => string.IsNullOrEmpty(Text) || string.IsNullOrWhiteSpace(Text);
    }
}
