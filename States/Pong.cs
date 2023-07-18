using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monogame_pong.Components;



namespace monogame_pong.States
{
    public class Pong
    {
        private SpriteFont pongFont;
        private Players players;
        private Texture2D blackRectangle; // Add this texture to draw rectangles
        private Ball ball;



        public Pong(SpriteFont font, Texture2D rectangleTexture, Texture2D ballTexture, GraphicsDevice graphicsDevice)
        {
            pongFont = font;
            blackRectangle = rectangleTexture; // Set the texture for drawing rectangles



            // Initialize the ball
            ball = new Ball(ballTexture, graphicsDevice);

            // Initialize the players
            players = new Players();
        }

        public void Update(GameTime gameTime,GraphicsDevice graphicsDevice)
        {
            // Update the players
            players.Update(gameTime, graphicsDevice);

            // Step the physics simulation
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;




            ball.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            // Draw players
            spriteBatch.Draw(blackRectangle, players.Player1, Color.White);
            spriteBatch.Draw(blackRectangle, players.Player2, Color.White);

            ball.Draw(spriteBatch);



            spriteBatch.DrawString(pongFont, "Pong", new Vector2(graphicsDevice.Viewport.Width / 2, graphicsDevice.Viewport.Height / 2), Color.White, 0f, pongFont.MeasureString("Pong") / 2, 1f, SpriteEffects.None, 0f);
        }
    }
}
