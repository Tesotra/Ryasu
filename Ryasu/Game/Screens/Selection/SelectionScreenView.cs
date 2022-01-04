using Microsoft.Xna.Framework;
using Ryasu.Game.Screens.Selection.UI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wobble.Screens;
using Ryasu.API.Maps.Osu;
using Wobble.Graphics.UI.Buttons;
using Wobble.Assets;
using Wobble.Graphics;
using Wobble.Graphics.Sprites;
using Wobble.Graphics.UI;
using Microsoft.Xna.Framework.Graphics;
using Ryasu.API.Maps;
using Ryasu.Game.Audio;
using Ryasu.Game.Managers;

namespace Ryasu.Game.Screens.Selection
{
    public class SelectionScreenView : ScreenView
    {
        public Dictionary<int, BeatmapButton> Beatmaps = new Dictionary<int, BeatmapButton>();
        public Rys Old { get; private set; }
        public Rys New { get; private set; }
        private ScrollContainer Scroll { get; set; }
        private BackgroundImage Parallax { get; set; }

        public SelectionScreenView(Screen screen, Texture2D bg) : base(screen)
        {
            Parallax = new BackgroundImage(bg,30);

            Parallax.Parent = Container;

            Scroll = new ScrollContainer(new ScalableVector2(800, 768), new ScalableVector2(650, 3000));

            Scroll.Parent = Container;

            Scroll.ScrollSpeed = 120;

            Scroll.InputEnabled = true;

            Scroll.X = 700;

            Scroll.Alpha = 0f;

            Task.Run(() => LoadOsuManiaMaps());
        }

        private void LoadOsuManiaMaps()
        {
            PathableString osuDir = "[osu]/Songs/";

            var files = Directory.GetFiles(osuDir.Text,"*.osu",SearchOption.AllDirectories);

            float y = 0;

            int i = 0;

            foreach(var f in files)
            {
                var rys = new OsuBeatmap(f,true).ToRys(false,true);

                if (rys == null || !rys.IsValid())
                    continue;

                var button = new TextButton(WobbleAssets.WhiteBox,"exo2-regular",$"{rys.MapName}\n{rys.Artist} // {rys.MapAuthor}\n{rys.Difficulty} ({rys.KeyCount}k)",16, (o,e) => {
                    LoadMap(rys);
                });

                button.Size = new ScalableVector2(900,90);

                button.Text.Alignment = Alignment.MidLeft;

                button.Tint = new Color(61, 37, 133);
                button.AddBorder(Color.Black, 1.4f);

                button.X = 20;

                y = (95 * i) + 95;

                button.Y = y;

                button.Parent = Container;

                Scroll.AddContainedDrawable(button);

                Scroll.ContentContainer.Size = new ScalableVector2(650, y);

                Beatmaps.Add(i, new BeatmapButton(button, rys));

                i++;
            }
        }

        public void LoadMap(Rys map)
        {
            if(New != map)
            {
                Old = New;
                New = map;
                Task.Run(() => Refresh());
            }
            else
            {
                //Load Code Here
            }
        }

        private void Refresh()
        {
            Parallax.Image = CustomTextureManager.Load($"{New.DirectoryPath}/{New.Background}");
            if(Old == null || ($"{Old.DirectoryPath}/{Old.Audio}" != $"{New.DirectoryPath}/{New.Audio}"))
            {
                AudioEngine.Load($"{New.DirectoryPath}/{New.Audio}");
                AudioEngine.Track.Seek(New.PreviewTime);
                AudioEngine.Track.Play();
            }
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
