using System.Text.Json.Serialization;

namespace PocketData;

public class Vehicle
{
	[JsonPropertyName("bgm")] public required Audio Bgm { get; set; }

	[JsonPropertyName("characterIndex")] public int CharacterIndex { get; set; }

	[JsonPropertyName("characterName")] public string CharacterName { get; set; } = string.Empty;

	[JsonPropertyName("startMapId")] public int StartMapId { get; set; }

	[JsonPropertyName("startX")] public int StartX { get; set; }

	[JsonPropertyName("startY")] public int StartY { get; set; }
}