using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            // Setup window properties
            Window.Title = "PocketRPG";
            _graphics.PreferredBackBufferWidth = 816;
            _graphics.PreferredBackBufferHeight = 624;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Initialize the PocketCore static managers
            PocketCore.Graphics.Initialize(GraphicsDevice, _spriteBatch, Window);
            PocketCore.Input.Initialize();

            // TODO: Load your game content here (e.g., SceneManager.GoTo(new Scene_Boot()))
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update core managers
            PocketCore.Input.Update();

            // TODO: Update the current scene here (e.g., SceneManager.Update(gameTime))

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // TODO: Draw the current scene here (e.g., SceneManager.Draw(_spriteBatch))

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}