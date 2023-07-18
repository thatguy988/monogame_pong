using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_pong.Components
{
    public class Players
    {
        private const int PlayerWidth = 10;
        private const int PlayerHeight = 80;
        private const int PlayerSpeed = 5;

        public Rectangle Player1 { get; private set; }
        public Rectangle Player2 { get; private set; }

        public Players()
        {
            // Initialize player positions
            Player1 = new Rectangle(50, 50, PlayerWidth, PlayerHeight);
            Player2 = new Rectangle(750, 50, PlayerWidth, PlayerHeight);
        }

        public void Update(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            // Player 1 movement
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                MovePlayer1(-PlayerSpeed, graphicsDevice);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                MovePlayer1(PlayerSpeed, graphicsDevice);
            }

            // Player 2 movement
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                MovePlayer2(-PlayerSpeed, graphicsDevice);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                MovePlayer2(PlayerSpeed, graphicsDevice);
            }
        }

        private void MovePlayer1(int yOffset, GraphicsDevice graphicsDevice)
        {
            // Create a new Rectangle with the updated position
            Player1 = new Rectangle(Player1.X, MathHelper.Clamp(Player1.Y + yOffset, 0, graphicsDevice.Viewport.Height - Player1.Height), Player1.Width, Player1.Height);
        }

        private void MovePlayer2(int yOffset, GraphicsDevice graphicsDevice)
        {
            // Create a new Rectangle with the updated position
            Player2 = new Rectangle(Player2.X, MathHelper.Clamp(Player2.Y + yOffset, 0, graphicsDevice.Viewport.Height - Player2.Height), Player2.Width, Player2.Height);
        }
    }
}
