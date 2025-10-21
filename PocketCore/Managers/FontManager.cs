using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using FontStashSharp;

namespace PocketCore.Managers;

/// <summary>
///     A static class that handles font files.
/// </summary>
public static class FontManager
{
	public static FontSystem Load(string filename)
	{
		FontSystem fs = new();

		if (filename.EndsWith(".ttf") || filename.EndsWith(".otf"))
			filename = filename[..^4];

		var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		var path = Path.Combine(exePath ?? string.Empty, "Content", "fonts", filename);

		Debug.WriteLine($"Attempting to load font from path: {path}");

		try
		{
			if (File.Exists($"{path}.ttf"))
				fs.AddFont(File.ReadAllBytes($"{path}.ttf"));
			else if (File.Exists($"{path}.otf"))
				fs.AddFont(File.ReadAllBytes($"{path}.otf"));
			else
				throw new FileNotFoundException($"Could not find font with path {path}");
			return fs;
		}
		catch (Exception e)
		{
			throw new FileNotFoundException($"Could not find font with path {path}", e);
		}
	}
}