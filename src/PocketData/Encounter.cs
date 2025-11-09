using System.Text.Json.Serialization;

namespace PocketData;

public class Encounter
{
	[JsonPropertyName("weight")]
	public int Weight { get; set; }

	[JsonPropertyName("troopId")]
	public int TroopId { get; set; }

	[JsonPropertyName("regionSet")]
	public List<int> RegionSet { get; set; } = [];
}