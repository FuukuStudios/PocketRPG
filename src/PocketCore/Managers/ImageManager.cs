using System.Collections.Concurrent;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PocketCore.Managers;

public class ImageManager(ContentManager content, GraphicsDevice graphicsDevice)
{
	private readonly ConcurrentDictionary<string, Bitmap> _cache = new();

	public Bitmap LoadTitleBackground(string fileName)
	{
		return LoadBitmap(Path.Combine("img", "titles1"), fileName);
	}

	public Bitmap LoadTitleFrame(string fileName)
	{
		return LoadBitmap(Path.Combine("img", "titles2"), fileName);
	}
	
	private Bitmap LoadBitmap(string folder, string fileName)
	{
		var path = Path.Combine(folder, fileName);
		return !string.IsNullOrWhiteSpace(fileName)
			? _cache.GetOrAdd(path, key => Bitmap.Load(content, graphicsDevice, key))
			: new Bitmap(graphicsDevice, 1, 1);
	}
}