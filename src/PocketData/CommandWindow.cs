using System.Text.Json.Serialization;

namespace PocketData;

public class CommandWindow
{
	[JsonPropertyName("offsetX")]
	public int OffsetX { get; set; }

	[JsonPropertyName("offsetY")]
	public int OffsetY { get; set; }

	[JsonPropertyName("background")]
	public int Background { get; set; }
}