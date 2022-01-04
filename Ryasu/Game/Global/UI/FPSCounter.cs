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

        private TimeSpan ElapsedTimeUpdate { get; set; }
        private TimeSpan ElapsedTimeDraw { get; set; }

        private int updateCount = 0;
        private int frameCount = 0;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="cacheToRenderTarget"></param>
        public FPSCounter(BitmapFont font, int size, bool cacheToRenderTarget = true) : base(font, "FPS: 0\nUPS: 0", cacheToRenderTarget)
        {
            ElapsedTimeUpdate = TimeSpan.Zero;
            ElapsedTimeDraw = TimeSpan.Zero;
            FontSize = size;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            ElapsedTimeUpdate += gameTime.ElapsedGameTime;

            if(ElapsedTimeUpdate >= TimeSpan.FromSeconds(1))
            {
                //Update Text
                base.Text = $"FPS: {updateCount}\nUPS: {frameCount}";

                //Reset Count
                updateCount = 0;
                frameCount = 0;

                //Reset Elapsed Time
                ElapsedTimeUpdate = TimeSpan.Zero;
                ElapsedTimeDraw = TimeSpan.Zero;
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
