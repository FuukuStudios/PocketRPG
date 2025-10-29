using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataClass : Data
{
	[JsonPropertyName("expParams")]
	public List<int> ExpParams { get; set; } = [];

	[JsonPropertyName("traits")]
	public required List<Trait> Traits { get; set; } = [];

	[JsonPropertyName("learnings")]
	public required List<Learning> Learnings { get; set; } = [];

	[JsonPropertyName("params")]
	public List<List<int>> Params { get; set; } = [];
}