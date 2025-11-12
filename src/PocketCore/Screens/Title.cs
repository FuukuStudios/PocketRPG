using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
		
		private FontSystem _fontSystem = null!;
		
		// >> Overrides <<
		public override void LoadContent()
		{
			base.LoadContent();
			
			_background = ImageManager.LoadTitleBackground(Game, Core.DataSystem.Title1Name);
			_bgFrame = ImageManager.LoadTitleFrame(Game, Core.DataSystem.Title2Name);

			_fontSystem = Game.FontManager.Get(CGame.System.MainFontFace);
		}

		public override void Draw(GameTime gameTime)
		{
			Game.GraphicsDevice.Clear(Color.Black);
			Game.SpriteBatch.Begin();
			// Background
			Game.SpriteBatch.Draw(_background, Vector2.Zero, Color.White);
			Game.SpriteBatch.Draw(_bgFrame, Vector2.Zero, Color.White);
			// Foreground
			var font = _fontSystem.GetFont(72);
			var text = Core.DataSystem.GameTitle;
			var position = new Vector2(20, Game.GraphicsDevice.PresentationParameters.BackBufferHeight / 4f);
			Game.SpriteBatch.DrawString(font, text, position, Color.White, effect: FontSystemEffect.Stroked, effectAmount: 2);
			Game.SpriteBatch.End();
		}

		public override void Start()
		{
			base.Start();
			// TODO: Scene stack
		}
	}
}