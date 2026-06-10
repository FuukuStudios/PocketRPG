using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
		var fontSys = game.FontManager.Get(settings.FontFace);
		var font = fontSys.GetFont(settings.FontSize);

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
		
		var effect = game.FontManager.OutlineEffect;
		if (settings.OutlineWidth > 0)
		{
			effect.Parameters["GlowColor"].SetValue(new Vector4(1.0f, 0.8f, 0.3f, 1.0f));
			effect.Parameters["GlowRadius"].SetValue(8.0f);
			effect.Parameters["Intensity"].SetValue(1.6f);
			effect.Parameters["Threshold"].SetValue(0.02f);
			effect.Parameters["Samples"].SetValue(16);
			effect.Parameters["Rings"].SetValue(3);
			effect.Parameters["Falloff"].SetValue(1.0f);
			effect.Parameters["TextureSize"].SetValue(new Vector2(fontSys.TextureWidth, fontSys.TextureHeight));
		
			game.SpriteBatch.End();
		
			game.SpriteBatch.Begin(
				sortMode: SpriteSortMode.Immediate, // Required for effects
				blendState: BlendState.AlphaBlend,
				samplerState: SamplerState.LinearClamp, // LinearClamp is good for fonts
				effect: effect
			);
		
			font.DrawText(game.SpriteBatch, text, drawPos, settings.FontColor);
			
			game.SpriteBatch.End();
			game.SpriteBatch.Begin();
		}
		else
		{
			font.DrawText(game.SpriteBatch, text, drawPos, settings.FontColor);
		}
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