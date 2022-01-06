using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wobble;
using Wobble.Window;
using Wobble.Managers;
using Microsoft.Xna.Framework.Content;
using Wobble.Screens;
using Ryasu.Game.Screens.MainMenu;
using Wobble.IO;
using Wobble.Graphics.UI.Debugging;
using Ryasu.Game.Screens.Load;
using Ryasu.Game.Audio;

namespace Ryasu.Game
{
    public class RyasuGame : WobbleGame
    {
        public static RyasuGame Instance { get; private set; }

        public static bool DebugLogging { get; private set; }
        public static List<string> LaunchArguments { get; set; }

        protected override bool IsReadyToUpdate { get; set; }

        public const string WindowTitle = "Ryasu";

        public static ContentManager RyasuContent { get; private set; }

        private FpsCounter Fps { get; set; }

        protected override void Initialize()
        {
            WindowManager.ChangeScreenResolution(new Point(1280, 720));

            DebugLogging = LaunchArguments.Contains("--log");

            Resources.AddStore(new DllResourceStore("Ryasu.Resources.dll"));

            Window.Title = WindowTitle;

            Instance = this;

            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Graphics.SynchronizeWithVerticalRetrace = false;
            TargetElapsedTime = TimeSpan.FromSeconds(1d / 240);
            IsFixedTimeStep = true;
            WaylandVsync = false;

            Window.AllowUserResizing = true;

            Content.RootDirectory = "Content";

            GlobalUserInterface.Cursor.Hide(0);

            IsMouseVisible = true;

            base.Initialize();
        }

        /// <inheritdoc />
        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();

            Fps = new FpsCounter(FontManager.LoadBitmapFont("gotham"),16)
            {
                Parent = GlobalUserInterface,
                Alignment = Wobble.Graphics.Alignment.BotRight,
                X = -10
            };

            RyasuContent = Content;

            AudioEngine.LoadSample("Ryasu.Resources/osu/Samples/Intro/welcome.mp3",true);
            AudioEngine.LoadSample("Ryasu.Resources/osu/Samples/Intro/seeYouNextTime.mp3",true);
            AudioEngine.LoadSample("Ryasu.Resources/osu/Samples/Menu/logo-select.wav",true);

            IsReadyToUpdate = true;

            ScreenManager.ChangeScreen(new LoadScreen());
        }

        /// <inheritdoc />
        /// <summary>
        ///     UnloadContent will be called once per game and is the place to unload
        ///     game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        /// <inheritdoc />
        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            if (!IsReadyToUpdate)
                return;

            base.Update(gameTime);

            GlobalUserInterface?.Update(gameTime);
        }

        /// <inheritdoc />
        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            if (!IsReadyToUpdate)
                return;

            base.Draw(gameTime);

            GlobalUserInterface?.Draw(gameTime);
        }
    }
}
