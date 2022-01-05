using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wobble.Screens;

namespace Ryasu.Game.Screens.Load
{
    public class LoadScreen : Screen
    {
        public override ScreenView View { get; protected set; }
        public LoadScreen()
        {
            View = new LoadScreenView(this);
        }
    }
}
