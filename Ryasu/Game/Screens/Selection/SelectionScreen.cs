using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Wobble.Screens;

namespace Ryasu.Game.Screens.Selection
{
    public class SelectionScreen : Screen
    {
        public override ScreenView View { get; protected set; }
        public SelectionScreen Instance { get; private set; }

        public SelectionScreen(Texture2D bg)
        {
            Instance = this;
            AutomaticallyDestroyOnScreenSwitch = false;
            View = new SelectionScreenView(this,bg);
        }
    }
}
