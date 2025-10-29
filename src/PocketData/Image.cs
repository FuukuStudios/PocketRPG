using System.Text.Json.Serialization;

namespace PocketData;

public class Image
{
	[JsonPropertyName("tileId")] public int TileId { get; set; }

	[JsonPropertyName("characterName")] public string CharacterName { get; set; } = string.Empty;

	[JsonPropertyName("direction")] public int Direction { get; set; }

	[JsonPropertyName("pattern")] public int Pattern { get; set; }

	[JsonPropertyName("characterIndex")] public int CharacterIndex { get; set; }
}