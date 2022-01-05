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
using Wobble.Graphics.UI.Buttons;
using Ryasu.Game.Screens.Selection;
using Wobble.Graphics.Sprites;
using Wobble.Graphics;
using Ryasu.Game.Screens.MainMenu.UI;
using Wobble.Window;

namespace Ryasu.Game.Screens.MainMenu
{
    public class MainMenuScreenView : ScreenView
    {
        private BackgroundImage Parallax { get; set; }

        private SelectionScreen SelectionScreen { get; set; }

        private RyasuLogo RyasuLogo { get; set; }

        private MenuAudioVisualizer Visualizer { get; set; }

        public MainMenuScreenView(Screen screen) : base(screen)
        {
            Texture2D background = TextureManager.Load("Ryasu.Resources/osu/Images/background.jpg");

            SelectionScreen = new SelectionScreen(background);

            Parallax = new BackgroundImage(background, 30)
            {
                Parent = Container
            };

            Texture2D ryasuLogo = TextureManager.Load("Ryasu.Resources/Images/ryasuLogo.png");

            RyasuLogo = new RyasuLogo()
            {
                Size = new ScalableVector2(512, 512),
                Alignment = Alignment.MidCenter,
                Image = ryasuLogo,
                Parent = Container
            };

            for (int i = 0; i < 3; i++)
            {
                var button = new TextButton(Wobble.Assets.WobbleAssets.WhiteBox, "gotham", RyasuLogo.GetOptionName(i), 18);

                button.AddBorder(Color.AliceBlue);

                RyasuLogo.AddButton(button);
            }

            //Run this in a task because it can take some time.
            Task.Run(() => InitializeMenu());
        }

        private void CreateAudioVisualizer() => Visualizer = new MenuAudioVisualizer((int)WindowManager.Width, 400, 150, 5,5, RyasuLogo)
        {
            Parent = Container,
            Alignment = Alignment.BotLeft,
        };

        private void InitializeMenu()
        {
            CreateAudioVisualizer();
        }

        private void PlayButtonClicked(object o, EventArgs e)
        {
            ScreenManager.ChangeScreen(SelectionScreen);
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

            //Update Loop
            if (AudioEngine.Track == null || AudioEngine.Track.IsDisposed)
                return;

            if (!AudioEngine.Track.IsPlaying)
                AudioEngine.Track.Play();
        }
    }
}
