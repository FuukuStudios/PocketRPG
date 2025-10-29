using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataActor : Data
{
	[JsonPropertyName("battlerName")] public string BattlerName { get; set; } = string.Empty;

	[JsonPropertyName("characterIndex")] public int CharacterIndex { get; set; }

	[JsonPropertyName("characterName")] public string CharacterName { get; set; } = string.Empty;

	[JsonPropertyName("classId")] public int ClassId { get; set; }

	[JsonPropertyName("equips")] public List<int> Equips { get; set; } = [];

	[JsonPropertyName("faceIndex")] public int FaceIndex { get; set; }

	[JsonPropertyName("faceName")] public string FaceName { get; set; } = string.Empty;

	[JsonPropertyName("traits")] public List<Trait> Traits { get; set; } = [];

	[JsonPropertyName("initialLevel")] public int InitialLevel { get; set; }

	[JsonPropertyName("maxLevel")] public int MaxLevel { get; set; }

	[JsonPropertyName("nickname")] public string Nickname { get; set; } = string.Empty;

	[JsonPropertyName("profile")] public string Profile { get; set; } = string.Empty;
}