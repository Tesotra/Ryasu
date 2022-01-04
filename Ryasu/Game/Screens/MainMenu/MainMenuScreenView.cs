using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wobble.Screens;
using Ryasu.Game.Audio;
using Wobble.Graphics.UI;
using Microsoft.Xna.Framework.Graphics;

namespace Ryasu.Game.Screens.MainMenu
{
    public class MainMenuScreenView : ScreenView
    {
        private BackgroundImage Parallax { get; set; }

        public MainMenuScreenView(Screen screen) : base(screen)
        {
            //2.2 seconds
            const int osu_circles_delay = 2200;
            bool osu = false;

            Texture2D background = null;

            if (RyasuGame.LaunchArguments.Contains("--osu-menu-track"))
                osu = true;

            Task.Factory.StartNew(() =>
            {
                if (osu)
                {
                    PathableString osuTrack = "[dir]/Songs/osu!/circles.mp3";
                    AudioEngine.Load(osuTrack);
                    Task.Delay(osu_circles_delay);
                }
            });
        }

        public override void Destroy()
        {
            Container?.Destroy();
        }

        public override void Draw(GameTime gameTime)
        {
            Container?.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            Container?.Update(gameTime);
        }
    }
}
