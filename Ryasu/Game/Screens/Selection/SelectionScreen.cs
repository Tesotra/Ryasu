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

        public SelectionScreen(Texture2D bg)
        {
            View = new SelectionScreenView(this,bg);
        }
    }
}
