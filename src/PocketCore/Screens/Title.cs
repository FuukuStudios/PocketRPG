using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Graphics;
using PocketCore.Managers;
using CGame = PocketCore.Objects.Game;

namespace PocketCore.Screens;

public partial class Screen
{
	public class Title(PocketGame game) : Base(game)
	{
		private Texture2D _background = null!;
		private Texture2D _bgFrame = null!;
		
		private SpriteSettings _settings = new SpriteSettings();
		private KeyboardState _previousKeyboardState;
		
		// >> Overrides <<
		public override void Initialize()
		{
			_previousKeyboardState = Keyboard.GetState();
			
			_settings.FontSize = 97;
			_settings.FontFace = CGame.System.MainFontFace;
			_settings.OutlineWidth = 3;
			_settings.OutlineColor = Color.Black;
			
			base.Initialize();
		}

		public override void LoadContent()
		{
			base.LoadContent();
			
			_background = ImageManager.LoadTitleBackground(Game, Core.DataSystem.Title1Name);
			_bgFrame = ImageManager.LoadTitleFrame(Game, Core.DataSystem.Title2Name);
		}

		/// <summary>
		/// Purely for debugging font size adjustment.
		/// </summary>
		public override void Update(GameTime gameTime)
		{
			var currentKeyboardState = Keyboard.GetState();

			// Check for "just pressed" the Up key
			if (currentKeyboardState.IsKeyDown(Keys.Up) && _previousKeyboardState.IsKeyUp(Keys.Up))
			{
				_settings.FontSize++; // Increment the counter
				Console.WriteLine($"FontSize: {_settings.FontSize}");
			}

			// Check for "just pressed" the Down key
			if (currentKeyboardState.IsKeyDown(Keys.Down) && _previousKeyboardState.IsKeyUp(Keys.Down))
			{
				_settings.FontSize--; // Decrement the counter
				Console.WriteLine($"FontSize: {_settings.FontSize}");
			}

			// Update the previous state for the next frame
			_previousKeyboardState = currentKeyboardState;
			
			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			Game.GraphicsDevice.Clear(Color.Black);
			Game.SpriteBatch.Begin();
			
			// Background
			Game.SpriteBatch.Draw(_background, Vector2.Zero, Color.White);
			Game.SpriteBatch.Draw(_bgFrame, Vector2.Zero, Color.White);
			
			// Foreground
			var text = Core.DataSystem.GameTitle;
			var position = new Vector2(20, Game.GraphicsDevice.PresentationParameters.BackBufferHeight / 4f);
			var maxWidth = (int)(Game.GraphicsDevice.PresentationParameters.BackBufferWidth - position.X * 2);
			Sprite.DrawText(Game, text, position, maxWidth, 48, align: Sprite.TextAlign.Center, settings: _settings);
			
			Game.SpriteBatch.End();
		}
	}
}