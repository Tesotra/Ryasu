using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wobble.Audio.Samples;
using Wobble.Graphics;
using Wobble.Graphics.Animations;
using Wobble.Graphics.Sprites;
using Wobble.Graphics.UI.Buttons;

namespace Ryasu.Game.Screens.MainMenu.UI
{
    public class RyasuLogo : Button
    {
        private AudioSample ClickedSample { get; set; }

        private bool ButtonClicked { get; set; }

        const float PressedX = -400;

        private Drawable OptionsContainer { get; set; }

        private TimeSpan TimeElaspedSinceLastClick { get; set; } = TimeSpan.Zero;

        private List<TextButton> Options = new List<TextButton>();

        public RyasuLogo()
        {
            byte[] LogoClicked = RyasuGame.Instance.Resources.Get("Ryasu.Resources/osu/Samples/Menu/logo-select.wav");
            ClickedSample = new AudioSample(LogoClicked);

            Clicked += (o, e) => OnClicked();

            OptionsContainer = new Container();
            OptionsContainer.Alignment = Alignment.MidCenter;
        }

        public void AddButton(TextButton button)
        {
            button.Size = new ScalableVector2(160, 64);
            button.Alignment = Alignment.MidCenter;
            button.Alpha = 0f;
            button.Tint = new Color(255, 127, 127);
            button.Parent = OptionsContainer;

            Options.Add(button);
        }

        private void OpenMenu()
        {
            for (int i = 0; i < Options.Count; i++)
            {
                var option = Options[i];

                lock (option.Animations)
                {
                    option.Animations.Clear();
                    option.Animations.Add(new Animation(AnimationProperty.X, Easing.OutCirc, option.X, (160 * i) + 205, 300f));
                    option.Animations.Add(new Animation(AnimationProperty.Alpha, Easing.Linear, option.Alpha, 1, 160f));
                }
            }
        }

        private void CloseMenu()
        {
            for (int i = 0; i < Options.Count; i++)
            {
                var option = Options[i];
                option.Visible = true;

                lock (option.Animations)
                {
                    option.Animations.Clear();
                    option.Animations.Add(new Animation(AnimationProperty.X, Easing.OutCirc, option.X, 0, 300f));
                    option.Animations.Add(new Animation(AnimationProperty.Alpha, Easing.Linear, option.Alpha, 0, 300f));
                }
            }
        }

        public static string GetOptionName(int id)
        {
            switch (id+1)
            {
                case 1:
                    return "Singleplayer";
                case 2:
                    return "Options";
                case 3:
                    return "Quit";
            }

            return "Undefined";
        }

        public void Visualize(float data, float elapsed)
        {
            var delta = 9 * elapsed;

            float Default = ButtonClicked ? 256 : 512;

            Vector2 newSize = MathHelper.Lerp(new Vector2(Size.X.Value, Size.Y.Value), new Vector2(Default + data, Default + data), delta);

            Size = new ScalableVector2(newSize.X, newSize.Y);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            OptionsContainer?.Update(gameTime);
            OptionsContainer.X = X;
            OptionsContainer.Y = Y;

            if(ButtonClicked)
                TimeElaspedSinceLastClick += gameTime.ElapsedGameTime;

            if(TimeElaspedSinceLastClick >= TimeSpan.FromSeconds(10f) && ButtonClicked)
            {
                ButtonClicked = false;

                lock (Animations)
                {
                    Animations.Clear();
                    Animations.Add(new Animation(AnimationProperty.X, Easing.OutCirc, X, 0, 550f));
                    Animations.Add(new Animation(AnimationProperty.Width, Easing.OutCirc, Width, 512, 500f));
                    Animations.Add(new Animation(AnimationProperty.Height, Easing.OutCirc, Height, 512, 500f));
                }

                TimeElaspedSinceLastClick = TimeSpan.Zero;

                CloseMenu();
            }
        }

        void OnClicked()
        {
            if(!ButtonClicked)
                ClickedSample.CreateChannel().Play();

            ButtonClicked = true;

            TimeElaspedSinceLastClick = TimeSpan.Zero;

            lock (Animations)
            {
                Animations.Clear();
                Animations.Add(new Animation(AnimationProperty.X,Easing.OutCirc, X, PressedX, 90f));
                Animations.Add(new Animation(AnimationProperty.Width, Easing.OutCirc, Width, 256, 70f));
                Animations.Add(new Animation(AnimationProperty.Height, Easing.OutCirc, Height, 256, 70f));
            }

            OpenMenu();
        }

        public override void Draw(GameTime gameTime)
        {
            OptionsContainer?.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
