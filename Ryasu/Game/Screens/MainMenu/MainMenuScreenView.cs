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
using Wobble.Graphics.Animations;
using Wobble.Input;

namespace Ryasu.Game.Screens.MainMenu
{
    public class MainMenuScreenView : ScreenView
    {
        private bool Quitting { get; set; }

        private BackgroundImage Parallax { get; set; }

        private SelectionScreen SelectionScreen { get; set; }

        private TimeSpan ElapsedSecondsWhilePressingESC { get; set; } = TimeSpan.Zero;

        private RyasuLogo RyasuLogo { get; set; }

        private MenuAudioVisualizer Visualizer { get; set; }

        private Sprite BackgroundSprite { get; set; }

        public static MainMenuScreenView Instance { get; private set; }

        public MainMenuScreenView(Screen screen) : base(screen)
        {
            Instance = this;
            Texture2D background = TextureManager.Load("Ryasu.Resources/osu/Images/background.jpg");

            SelectionScreen = new SelectionScreen(background);

            Parallax = new BackgroundImage(background, 30)
            {
                Parent = Container
            };

            BackgroundSprite = new Sprite()
            {
                Size = new ScalableVector2((int)WindowManager.Width, (int)WindowManager.Height),
                Tint = Color.Black,
                Alpha = 0,
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

                button.Clicked += (o, e) => ProcessButtonEvent(i);

                RyasuLogo.AddButton(button);
            }

            CreateAudioVisualizer();
        }

        public void ProcessButtonEvent(int id)
        {
            switch (id+1)
            {
                case 1:
                    ScreenManager.ChangeScreen(SelectionScreen);
                    break;
                case 3:
                    Quit();
                    break;
            }
        }

        private void Quit()
        {
            Quitting = true;

            RyasuLogo.Quit();

            AudioEngine.Track.Volume = 0;
            AudioEngine.Track.Stop();

            lock (BackgroundSprite.Animations)
            {
                BackgroundSprite.Animations.Clear();

                BackgroundSprite.Animations.Add(new Animation(AnimationProperty.Alpha,Easing.Linear,0,1,200f));
            }

            AudioEngine.LoadSample("Ryasu.Resources/osu/Samples/Intro/seeYouNextTime.mp3", true).CreateChannel().Play();

            Task.Run(() => WaitForEnd());
        }

        private async void WaitForEnd()
        {
            await Task.Delay(2200);
            RyasuGame.Instance.Exit();
        }

        private void CreateAudioVisualizer() => Visualizer = new MenuAudioVisualizer((int)WindowManager.Width, 400, 150, 5,5, RyasuLogo)
        {
            Parent = Container,
            Alignment = Alignment.BotLeft,
        };

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

            if (Quitting)
                return;

            if(KeyboardManager.CurrentState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                ElapsedSecondsWhilePressingESC += gameTime.ElapsedGameTime;
            }
            else
            {
                ElapsedSecondsWhilePressingESC = TimeSpan.Zero;
            }

            float seconds = (float)ElapsedSecondsWhilePressingESC.TotalSeconds;
            float secondsDelta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            float alpha = seconds / 1.4f;

            BackgroundSprite.Alpha = MathHelper.Lerp(BackgroundSprite.Alpha,alpha,9*secondsDelta);

            if (seconds >= 1.4f)
            {
                Quit();
            }
            else
            {
                //Update Loop
                if (AudioEngine.Track == null || AudioEngine.Track.IsDisposed)
                    return;

                if (!AudioEngine.Track.IsPlaying)
                    AudioEngine.Track.Play();
            }
        }
    }
}
