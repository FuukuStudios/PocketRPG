using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PocketCore.Graphics;
using PocketCore.Input;
using PocketCore.Managers;
using PocketCore.Objects;
using PocketCore.Scenes;

namespace PocketDesktop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Window.Title = "PocketRPG";
            _graphics.PreferredBackBufferWidth = 816;
            _graphics.PreferredBackBufferHeight = 624;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            PocketGraphics.Initialize(GraphicsDevice, _spriteBatch, Window);
            PocketInput.Initialize();
            ImageManager.Initialize(Content);
            AudioManager.Initialize(Content); // Initialize AudioManager

            DataManager.LoadDatabase(); // Load the placeholder system data

            SceneManager.GoTo(new Boot());
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            PocketInput.Update();
            SceneManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clear the screen to black, not blue
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            SceneManager.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

