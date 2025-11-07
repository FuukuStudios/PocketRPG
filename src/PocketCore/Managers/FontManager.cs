using FontStashSharp;

namespace PocketCore.Managers;

public class FontManager
{
	private Dictionary<string, FontSystem> _fontSystems = [];

	public void Load(string name, string fontFileName)
	{
		var fontSystem = new FontSystem();
		try
		{
			var path = File.Exists($"{fontFileName}.ttf") 
				? $"{fontFileName}.ttf" 
				: File.Exists($"{fontFileName}.otf") 
					? $"{fontFileName}.otf" 
					: throw new FileNotFoundException($"Font file '{fontFileName}' not found.");
			
			fontSystem.AddFont(File.ReadAllBytes(Path.Combine("Content", "fonts", path)));
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error loading font '{fontFileName}': {ex}");
			throw;
		}
		_fontSystems[name] = fontSystem;
	}
}