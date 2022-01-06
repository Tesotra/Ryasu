using System;
using System.Collections.Generic;
using System.Text;
using Wobble.Screens;

namespace Ryasu.Game.Screens.MainMenu
{
    public class MainMenuScreen : Screen
    {
        public override ScreenView View { get; protected set; }

        public static MainMenuScreen Instance { get; private set; }

        public MainMenuScreen()
        {
            Instance = this;
            AutomaticallyDestroyOnScreenSwitch = false;
            View = new MainMenuScreenView(this);
        }

        public void PlayAudio()
        {
            Audio.AudioEngine.Track.Play();
        }
    }
}
