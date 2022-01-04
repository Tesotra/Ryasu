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

        const int osu_circles_delay = 2400;

        private bool OsuStart;

        public MainMenuScreenView(Screen screen) : base(screen)
        {
            Texture2D background = null;

            int dim = 30;

            byte[] osuCircles = new byte[] { };

            if(RyasuGame.LaunchArguments.Contains("--osu"))
            {
                osuCircles = RyasuGame.Instance.Resources.Get("Ryasu.Resources/osu/Music/circles.mp3");
                background = TextureManager.Load("Ryasu.Resources/osu/Images/background.jpg");
                dim = 100;
                AudioEngine.Load(osuCircles);

                Task.Factory.StartNew(() =>
                {
                    Osu();
                });
            }
            else
            {
                background = TextureManager.Load("Ryasu.Resources/Menu/background.jpg");
                InitializeMenu();
            }

            Parallax = new BackgroundImage(background, dim)
            {
                Parent = Container
            };
        }

        void InitializeMenu()
        {

        }

        public async void Osu()
        {
            AudioEngine.Track.Play();
            await Task.Delay(osu_circles_delay);
            OsuStart = true;
            InitializeMenu();
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

            if (OsuStart)
            {
                Parallax.Dim = (int)MathHelper.Lerp(Parallax.Dim,30,(float)(9 * gameTime.ElapsedGameTime.TotalSeconds));
            }
        }
    }
}
