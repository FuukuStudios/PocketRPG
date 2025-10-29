using System.Text.Json.Serialization;

namespace PocketData;

public class Rotation
{
	[JsonPropertyName("x")] public int X { get; set; }

	[JsonPropertyName("y")] public int Y { get; set; }

	[JsonPropertyName("z")] public int Z { get; set; }
}