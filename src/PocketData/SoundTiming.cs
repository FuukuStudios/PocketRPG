using System.Text.Json.Serialization;

namespace PocketData;

public class SoundTiming
{
	[JsonPropertyName("frame")] public int Frame { get; set; }

	[JsonPropertyName("se")] public required SE Se { get; set; }
}