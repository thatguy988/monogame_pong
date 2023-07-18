using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Input;
using System;





namespace monogame_pong.States
{
    public class MainMenu
    {
        public enum MenuOption
        {
            StartGame,
            LoadGame,
            Quit
        }
        public MenuOption selectedOption { get; private set; }


        // private MenuOption selectedOption = MenuOption.StartGame;
        private bool keyPressed = false;

        private SpriteFont gameFont;

        public event Action StartSelected;
        public event Action QuitSelected;




        public MainMenu(SpriteFont font)
        {
            gameFont = font;
        }

        public void Update(GameTime gameTime)
        {

            if (!keyPressed)
            {
                // Menu navigation logic
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    selectedOption--;
                    if (selectedOption < MenuOption.StartGame)
                        selectedOption = MenuOption.Quit;
                    keyPressed = true;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    selectedOption++;
                    if (selectedOption > MenuOption.Quit)
                        selectedOption = MenuOption.StartGame;
                    keyPressed = true;
                }

            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down))
            {
                keyPressed = false;
            }

            // Menu selection logic
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !keyPressed)
            {
                keyPressed = true;
                switch (selectedOption)
                {
                    case MenuOption.StartGame:
                        StartSelected?.Invoke();
                        // Start game logic
                        break;
                    case MenuOption.LoadGame:
                        // Load game logic
                        break;
                    case MenuOption.Quit:
                        QuitSelected?.Invoke();
                        break;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {

            // Draw the menu options
            float x = graphicsDevice.Viewport.Width / 2;
            float y = graphicsDevice.Viewport.Height / 2;
            float spacing = 30f;

            Color startGameColor = selectedOption == MenuOption.StartGame ? Color.Yellow : Color.White;
            Color loadGameColor = selectedOption == MenuOption.LoadGame ? Color.Yellow : Color.White;
            Color quitColor = selectedOption == MenuOption.Quit ? Color.Yellow : Color.White;




            spriteBatch.DrawString(gameFont, "Start Game", new Vector2(x, y), startGameColor);
            spriteBatch.DrawString(gameFont, "Load Game", new Vector2(x, y + spacing), loadGameColor);
            spriteBatch.DrawString(gameFont, "Quit", new Vector2(x, y + 2 * spacing), quitColor);

        }
    }
}