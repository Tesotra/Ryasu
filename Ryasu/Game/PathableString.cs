using System;
using System.Collections.Generic;
using System.Text;

namespace Ryasu.Game
{
    public class PathableString
    {
        public string Text { get; private set; }

        public PathableString(string text) => Text = text;

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
