using System.Text.Json.Serialization;

namespace PocketData.Database;

public class Class
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("expParams")]
	public List<int> ExpParams { get; set; } = [];

	[JsonPropertyName("traits")]
	public List<Trait> Traits { get; set; } = [];

	[JsonPropertyName("learnings")]
	public List<Learning> Learnings { get; set; } = [];

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("note")]
	public string Note { get; set; } = string.Empty;

	[JsonPropertyName("params")]
	public List<List<int>> Params { get; set; } = [];
}