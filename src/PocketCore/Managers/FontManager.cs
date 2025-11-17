using FontStashSharp;
using Microsoft.Xna.Framework.Graphics;

namespace PocketCore.Managers;

public class FontManager
{
	private Dictionary<string, FontSystem> _fontSystems = [];
	
	private readonly string _contentDir = Path.Combine("Content", "fonts");
	private readonly string[] _supportedExtensions = ["ttf", "otf"];
	
	public Effect OutlineEffect { get; private set; }

	public FontManager(PocketGame game)
	{
		FontSystemDefaults.FontResolutionFactor = 2.0f;
		FontSystemDefaults.KernelWidth = 2;
		FontSystemDefaults.KernelHeight = 2;
		
		OutlineEffect = game.Content.Load<Effect>("Stroke");
	}

	public void Load(string name, string fontFileName)
	{
		byte[]? font = null;
		var fontSystem = new FontSystem();
		
		try
		{
			var arr = fontFileName.Split('.');
			var noExt = arr.Length > 1 ? string.Join("", arr[..^1]) : fontFileName;
			
			foreach (var ext in _supportedExtensions)
			{
				Console.WriteLine($"Attempt to load font at '{Path.Combine(_contentDir, $"{noExt}.{ext}")}'...");
				if (!File.Exists(Path.Combine(_contentDir, $"{noExt}.{ext}"))) continue;
				Console.WriteLine("Found.");
				
				font = File.ReadAllBytes(Path.Combine(_contentDir, $"{noExt}.{ext}"));
				break;
			}
			if (font is null) throw new InvalidDataException($"Font file {noExt} not found or has unsupported extension.");
			fontSystem.AddFont(font);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error loading font '{fontFileName}': {ex}");
			throw;
		}
		_fontSystems[name] = fontSystem;
	}
	
	public FontSystem Get(string name)
	{
		_fontSystems.TryGetValue(name, out var value);
		return value ?? throw new KeyNotFoundException($"Font system '{name}' not found.");
	}
}