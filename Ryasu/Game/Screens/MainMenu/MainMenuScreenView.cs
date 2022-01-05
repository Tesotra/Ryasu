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

        private Sprite RyasuLogo { get; set; }

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

            RyasuLogo = new Sprite()
            {
                Size = new ScalableVector2(512, 512),
                Alignment = Alignment.MidCenter,
                Image = ryasuLogo,
                Parent = Container
            };

            

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
        }
    }
}
