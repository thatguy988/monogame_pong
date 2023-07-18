using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace monogame_pong.Components
{
    public class Ball
    {
        private Texture2D ballTexture;
        private Vector2 position;


        public Ball(Texture2D ballTexture, GraphicsDevice graphicsDevice)
        {
            this.ballTexture = ballTexture;
            position = new Vector2(graphicsDevice.Viewport.Width / 2 - ballTexture.Width / 2, graphicsDevice.Viewport.Height / 2 - ballTexture.Height / 2);

          

        }

        public void Update(GameTime gameTime)
        {
           
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(ballTexture, position, Color.White);
        }
    }
}





