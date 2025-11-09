using System.Text.Json.Serialization;

namespace PocketData.Database;

public class Armor
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("atypeId")]
	public int AtypeId { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; } = string.Empty;

	[JsonPropertyName("etypeId")]
	public int EtypeId { get; set; }

	[JsonPropertyName("traits")]
	public List<Trait> Traits { get; set; } = [];

	[JsonPropertyName("iconIndex")]
	public int IconIndex { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("note")]
	public string Note { get; set; } = string.Empty;

	[JsonPropertyName("params")]
	public List<int> Params { get; set; } = [];

	[JsonPropertyName("price")]
	public int Price { get; set; }
}