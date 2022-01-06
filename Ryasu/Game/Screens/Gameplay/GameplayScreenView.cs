using Microsoft.Xna.Framework;
using Wobble.Screens;

namespace Ryasu.Game.Screens.Gameplay
{
    public class GameplayScreenView : ScreenView
    {
        public GameplayScreenView(Screen screen) : base(screen)
        {

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