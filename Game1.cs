using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using monogame_pong.States;

namespace monogame_pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private MainMenu mainMenu;
        private SpriteFont gameFont;

        private Pong pongScreen;
        private SpriteFont pongFont;


        private bool mainMenuIsActive = true;
        private bool pongIsActive = false;

        private Texture2D pixel;
        private Texture2D ball;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the pong font
            pongFont = Content.Load<SpriteFont>("galleryFont");
            pixel = Content.Load<Texture2D>("pong");

            ball = Content.Load<Texture2D>("target");

            // Initialize the pong screen
            pongScreen = new Pong(pongFont,pixel,ball,GraphicsDevice);

            // Load the menu font
            gameFont = Content.Load<SpriteFont>("galleryFont");

            // Initialize the main menu
            mainMenu = new MainMenu(gameFont);

            // Subscribe to the QuitSelected event
            mainMenu.QuitSelected += QuitGame;
            mainMenu.StartSelected += StartGame;





        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (mainMenuIsActive)
            {
                mainMenu.Update(gameTime);
                return;
            }
            if (pongIsActive)
            {
                pongScreen.Update(gameTime, GraphicsDevice);
                return;
            }

            
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            if (mainMenuIsActive)
            {
                mainMenu.Draw(_spriteBatch, GraphicsDevice);
            }
            else
            {
                pongScreen.Draw(_spriteBatch, GraphicsDevice);
            }

            _spriteBatch.End();
        }


        private void StartGame()
        {
            mainMenuIsActive = false;
            pongIsActive = true;

            // Perform any additional logic to start the game or transition to the Pong screen
        }

        private void QuitGame()
        {
            Exit();
        }
    }
}