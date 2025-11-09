using System.Text.Json.Serialization;

namespace PocketData;

public class TestBattler
{
	[JsonPropertyName("actorId")]
	public int ActorId { get; set; }

	[JsonPropertyName("level")]
	public int Level { get; set; }

	[JsonPropertyName("equips")]
	public List<int> Equips { get; set; } = [];
}