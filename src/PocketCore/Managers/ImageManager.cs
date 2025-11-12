using System.Collections.Concurrent;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PocketCore.Managers;

public static class ImageManager
{
	public static Texture2D LoadTitleBackground(PocketGame game, string fileName)
	{
		return LoadTexture2D(game,Path.Combine("img", "titles1"), fileName);
	}

	public static Texture2D LoadTitleFrame(PocketGame game, string fileName)
	{
		return LoadTexture2D(game, Path.Combine("img", "titles2"), fileName);
	}
	
	public static Texture2D LoadTexture2D(PocketGame game, string folder, string fileName)
	{
		if (string.IsNullOrWhiteSpace(fileName)) return new Texture2D(game.GraphicsDevice, 1, 1);
		
		var path = Path.Combine(folder, fileName);
		return game.Content.Load<Texture2D>(path);
	}
}