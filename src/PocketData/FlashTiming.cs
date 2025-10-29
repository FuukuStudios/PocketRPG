using System.Text.Json.Serialization;

namespace PocketData;

public class FlashTiming
{
	[JsonPropertyName("frame")] public int Frame { get; set; }

	[JsonPropertyName("duration")] public int Duration { get; set; }

	[JsonPropertyName("color")] public List<int> Color { get; set; } = [];
}