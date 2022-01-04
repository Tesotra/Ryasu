using Microsoft.Xna.Framework;
using MonoGame.Extended.BitmapFonts;
using System;
using System.Collections.Generic;
using System.Text;
using Wobble.Graphics.Sprites;

namespace Ryasu.Game.Global.UI
{
    public class FPSCounter : SpriteTextBitmap
    {

        private TimeSpan elapsedTimeUpdate;
        private TimeSpan elapsedTimeDraw;

        private int updateCount = 0;
        private int frameCount = 0;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="cacheToRenderTarget"></param>
        public FPSCounter(BitmapFont font, string text, bool cacheToRenderTarget = true) : base(font, text, cacheToRenderTarget)
        {
            elapsedTimeUpdate = TimeSpan.Zero;
            elapsedTimeDraw = TimeSpan.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            elapsedTimeUpdate += gameTime.ElapsedGameTime;

            if(elapsedTimeUpdate >= TimeSpan.FromSeconds(1))
            {
                //Update Text
                base.Text = $"FPS: {updateCount}\nUPS: {frameCount}";

                //Reset Count
                updateCount = 0;
                frameCount = 0;

                //Reset Elapsed Time
                elapsedTimeUpdate = TimeSpan.Zero;
                elapsedTimeDraw = TimeSpan.Zero;
                return;
            }

            updateCount++;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            frameCount++;
        }
    }
}
