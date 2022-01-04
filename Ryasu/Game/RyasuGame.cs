using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wobble;
using Wobble.Window;

namespace Ryasu.Game
{
    public class RyasuGame : WobbleGame
    {
        public static RyasuGame Instance { get; private set; }

        protected override bool IsReadyToUpdate { get; set; }

        public const string WindowTitle = "Ryasu";

        protected override void Initialize()
        {
            base.Initialize();

            Window.Title = WindowTitle;

            Instance = this;

            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            WindowManager.ChangeScreenResolution(new Point(1280, 720));

            Graphics.SynchronizeWithVerticalRetrace = false;
            TargetElapsedTime = TimeSpan.FromSeconds(1d / 240);
            IsFixedTimeStep = true;
            WaylandVsync = false;

            Window.AllowUserResizing = true;

            Content.RootDirectory = "Content";

            GlobalUserInterface.Cursor.Hide(0);

            IsMouseVisible = true;
        }

        /// <inheritdoc />
        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();

            IsReadyToUpdate = true;
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
