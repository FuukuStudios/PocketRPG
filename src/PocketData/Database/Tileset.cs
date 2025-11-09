using System.Text.Json.Serialization;

namespace PocketData.Database;

public class Tileset
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("flags")]
	public List<int> Flags { get; set; } = [];

	[JsonPropertyName("mode")]
	public int Mode { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("note")]
	public string Note { get; set; } = string.Empty;

	[JsonPropertyName("tilesetNames")]
	public List<string> TilesetNames { get; set; } = [];
}