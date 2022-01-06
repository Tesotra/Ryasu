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

        public static BeatmapButton SelectedButton { get; set; } = null;

        public float DefX { get; set; }
        public bool Parallax { get; set; }

        public BeatmapButton(Rys rys) : base(Wobble.Assets.WobbleAssets.WhiteBox,"gotham", $"{rys.MapName}\n{rys.Artist} // {rys.MapAuthor}\n{rys.Difficulty} ({rys.KeyCount}k)",32)
        {
            Map = rys;
            DrawIfOffScreen = false;
            Text.Size = Text.Size / 2;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!Parallax)
                return;

            float val = SelectedButton == this ? 20 : 0;

            float x = DefX - val;

            float deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            X = MathHelper.Lerp(X,x,8*deltaSeconds);
        }
    }
}
