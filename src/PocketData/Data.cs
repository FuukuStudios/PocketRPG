using System.Text.Json.Serialization;

namespace PocketData;

public abstract class Data
{
	[JsonPropertyName("id")] public int Id { get; set; }

	[JsonPropertyName("name")] public string Name { get; set; } = string.Empty;

	[JsonPropertyName("note")] public string Note { get; set; } = string.Empty;
}