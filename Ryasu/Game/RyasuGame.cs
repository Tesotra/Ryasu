using Microsoft.Xna.Framework;
using System;
using Ryasu.Game.Global.UI;
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

namespace Ryasu.Game
{
    public class RyasuGame : WobbleGame
    {
        public static RyasuGame Instance { get; private set; }

        public static List<string> LaunchArguments { get; set; }

        protected override bool IsReadyToUpdate { get; set; }

        public const string WindowTitle = "Ryasu";

        public static ContentManager RyasuContent { get; private set; }

        private FPSCounter Fps { get; set; }

        protected override void Initialize()
        {
            WindowManager.ChangeScreenResolution(new Point(1280, 720));

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

            Fps = new FPSCounter(FontManager.LoadBitmapFont("code-pro"),16)
            {
                Parent = GlobalUserInterface,
                Alignment = Wobble.Graphics.Alignment.BotRight,
                X = -14
            };

            RyasuContent = Content;

            IsReadyToUpdate = true;

            ScreenManager.ChangeScreen(new MainMenuScreen());
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
        }
    }
}
