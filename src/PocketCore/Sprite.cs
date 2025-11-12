using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.StrokeEffect;

namespace PocketCore;

public static class Sprite
{
	public enum TextAlign
	{
		Left,
		Center,
		Right
	}
	
	public static void DrawText(PocketGame game, string text, Vector2 position, int maxWidth, int lineHeight, TextAlign align = TextAlign.Left, SpriteSettings? settings = null)
	{
		settings ??= new SpriteSettings();
		var font = game.FontManager.Get(settings.FontFace).GetFont(settings.FontSize);

		var size = font.MeasureString(text);
		var drawPos = new Vector2
		{
			X = align switch
			{
				TextAlign.Center => position.X + (maxWidth - size.X) / 2,
				TextAlign.Right => position.X + (maxWidth - size.X),
				_ => position.X
			},
			Y = position.Y + (lineHeight - size.Y) / 2
		};
		
		var texture = StrokeEffect.CreateStrokeSpriteFont(font, text, settings.FontColor, Vector2.One, settings.OutlineWidth, settings.OutlineColor, game.GraphicsDevice);
		game.SpriteBatch.Draw(texture, drawPos, Color.White);
	}
}

public class SpriteSettings
{
	public string FontFace { get; set; } = "sans-serif";
	public int FontSize { get; set; } = 16;
	public bool Bold { get; set; } = false;
	public bool Italic { get; set; } = false;
	public Color FontColor { get; set; } = Color.White;
	public Color OutlineColor { get; set; } = new Color(0, 0, 0, 0.5f);
	public int OutlineWidth { get; set; } = 3;
}