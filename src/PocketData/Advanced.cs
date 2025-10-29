using System.Text.Json.Serialization;

namespace PocketData;

public class Advanced
{
	[JsonPropertyName("gameId")] public int GameId { get; set; }

	[JsonPropertyName("screenWidth")] public int ScreenWidth { get; set; }

	[JsonPropertyName("screenHeight")] public int ScreenHeight { get; set; }

	[JsonPropertyName("uiAreaWidth")] public int UiAreaWidth { get; set; }

	[JsonPropertyName("uiAreaHeight")] public int UiAreaHeight { get; set; }

	[JsonPropertyName("numberFontFilename")]
	public string NumberFontFilename { get; set; } = string.Empty;

	[JsonPropertyName("fallbackFonts")] public string FallbackFonts { get; set; } = string.Empty;

	[JsonPropertyName("fontSize")] public int FontSize { get; set; }

	[JsonPropertyName("mainFontFilename")] public string MainFontFilename { get; set; } = string.Empty;
}