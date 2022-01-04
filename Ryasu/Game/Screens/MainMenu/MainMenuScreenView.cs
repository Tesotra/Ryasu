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
using Wobble.Managers;

namespace Ryasu.Game.Screens.MainMenu
{
    public class MainMenuScreenView : ScreenView
    {
        private BackgroundImage Parallax { get; set; }

        const int osu_circles_delay = 2200;

        private TimeSpan ElapsedTime = TimeSpan.Zero;

        private bool osu;
        private bool osuStart;

        public MainMenuScreenView(Screen screen) : base(screen)
        {
            Texture2D background = null;

            int dim = 30;

            osu = true;

            if (osu)
            {
                var osuCircles = RyasuGame.Instance.Resources.Get("Ryasu.Resources/osu/Music/circles.mp3");
                background = TextureManager.Load("Ryasu.Resources/osu/Images/background.jpg");
                AudioEngine.Load(osuCircles);
                dim = 100;
            }
            else
            {
                background = TextureManager.Load("Ryasu.Resources/Menu/background.jpg");
            }

            Parallax = new BackgroundImage(background, dim)
            {
                Parent = Container
            };
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

            if(osu && !osuStart)
            {
                ElapsedTime += gameTime.ElapsedGameTime;

                if (ElapsedTime >= TimeSpan.FromMilliseconds(osu_circles_delay))
                {
                    osuStart = true;

                    Parallax.Dim = 30;
                }
            }
        }
    }
}
