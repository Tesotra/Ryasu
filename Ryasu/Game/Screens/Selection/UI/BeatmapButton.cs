using Ryasu.API.Maps;
using System;
using System.Collections.Generic;
using System.Text;
using Wobble.Graphics.UI.Buttons;

namespace Ryasu.Game.Screens.Selection.UI
{
    public class BeatmapButton
    {
        public Rys Map { get; private set; }
        public TextButton Button { get; private set; }

        public BeatmapButton(TextButton button, Rys map)
        {
            Button = button;
            Map = map;
        }
    }
}
