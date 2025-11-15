using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.StrokeEffect;
using PocketCore.Managers;

namespace PocketCore;

public static class Sprite
{
	public enum TextAlign
	{
		Left,
		Center,
		Right
	}public static void DrawText(PocketGame game, string text, Vector2 position, int maxWidth, int lineHeight, TextAlign align = TextAlign.Left, SpriteSettings? settings = null)
	{
		settings ??= new SpriteSettings();

		// Get size for alignment
		// !!! This uses the DUMMY MeasureString. Alignment will be broken
		// until you find the real API in MonoMSDF.
		var size = FontManager.MeasureString(text, settings.FontSize);

		var drawPos = new Vector2
		{
			X = align switch
			{
				TextAlign.Center => position.X + (maxWidth - size.X) / 2,
				TextAlign.Right => position.X + (maxWidth - size.X),
				_ => position.X
			},
			// Use FontSize for Y-centering, as MeasureString.Y is unreliable
			Y = position.Y + (lineHeight - settings.FontSize) / 2f
		};
        
		// No more texture creation. No more SpriteBatch.
		// Just queue the text to be rendered later.
		game.FontManager.QueueText(
			text,
			drawPos,
			settings.FontSize,
			settings.FontColor,
			settings.OutlineColor
		);
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