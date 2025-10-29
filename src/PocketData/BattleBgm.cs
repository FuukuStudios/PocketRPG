using System.Text.Json.Serialization;

namespace PocketData;

public class BattleBgm
{
	[JsonPropertyName("name")] public string Name { get; set; } = string.Empty;

	[JsonPropertyName("pan")] public int Pan { get; set; }

	[JsonPropertyName("pitch")] public int Pitch { get; set; }

	[JsonPropertyName("volume")] public int Volume { get; set; }
}