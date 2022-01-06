using System;
using System.Collections.Generic;
using System.Text;
using Wobble.Screens;

namespace Ryasu.Game.Screens.Gameplay
{
    public class GameplayScreen : Screen
    {
        public override ScreenView View { get; protected set; }

        public bool Failed { get; set; }
        public bool Paused { get; set; }

        public GameplayScreen()
        {
            View = new GameplayScreenView(this);
        }
    }
}
