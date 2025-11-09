using System.Text.Json.Serialization;

namespace PocketData.Database;

public class Weapon
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("animationId")]
	public int AnimationId { get; set; }

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

	[JsonPropertyName("wtypeId")]
	public int WtypeId { get; set; }
}