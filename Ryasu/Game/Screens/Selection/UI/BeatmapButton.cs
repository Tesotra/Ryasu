using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Ryasu.API.Maps;
using Ryasu.Game.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Wobble.Graphics.UI.Buttons;

namespace Ryasu.Game.Screens.Selection.UI
{
    public class BeatmapButton : TextButton
    {
        public Rys Map { get; private set; }

        public float DefX { get; set; }
        public bool Parallax { get; set; }

        public BeatmapButton(Rys rys) : base(Wobble.Assets.WobbleAssets.WhiteBox,"gotham", $"{rys.MapName}\n{rys.Artist} // {rys.MapAuthor}\n{rys.Difficulty} ({rys.KeyCount}k)",16)
        {
            Map = rys;
            DrawIfOffScreen = false;
        }
    }
}
