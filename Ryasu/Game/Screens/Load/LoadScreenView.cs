using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Ryasu.Game.Audio;
using Wobble.Screens;
using System.Threading.Tasks;
using Ryasu.Game.Screens.MainMenu;
using Wobble.Graphics.Sprites;
using Wobble.Managers;
using Wobble.Graphics.UI;
using Wobble.Graphics;

namespace Ryasu.Game.Screens.Load
{
    public class LoadScreenView : ScreenView
    {
        private MainMenuScreen MenuScreen { get; set; }

        private BackgroundImage BackgroundImage { get; set; }

        private SpriteTextBitmap Welcome { get; set; }

        private float SizeX, SizeY;

        public LoadScreenView(Screen screen) : base(screen)
        {
            MenuScreen = new MainMenuScreen();

            BackgroundImage = new BackgroundImage(Wobble.Assets.WobbleAssets.WhiteBox, 100, false)
            {
                Parent = Container
            };

            Welcome = new SpriteTextBitmap(FontManager.LoadBitmapFont("gotham"), "welcome")
            {
                Parent = Container,
                Alignment = Alignment.MidCenter,
            };

            Welcome.FontSize = 64;

            SizeX = Welcome.Size.X.Value / 2.3f;
            SizeY = Welcome.Size.Y.Value / 2.3f;

            Task.Run(() => Osu());
        }

        public override void Destroy()
        {
            Container?.Destroy();
        }

        public override void Draw(GameTime gameTime)
        {
            Container?.Draw(gameTime);
        }

        public async void Osu()
        {
            byte[] osuCircles = RyasuGame.Instance.Resources.Get("Ryasu.Resources/osu/Music/welcomeToOsu.mp3");
            AudioEngine.Load(osuCircles);

            await Task.Delay(2400);
            MenuScreen.PlayAudio();
            ScreenManager.ChangeScreen(MenuScreen);
        }

        public override void Update(GameTime gameTime)
        {
            Container?.Update(gameTime);

            double delta = gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 lerp = MathHelper.Lerp(new Vector2(Welcome.Size.X.Value, Welcome.Size.Y.Value),new Vector2(SizeX,SizeY), (float)(3*delta));

            Welcome.Size = new ScalableVector2(lerp.X, lerp.Y);
        }
    }
}
