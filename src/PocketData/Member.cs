using System.Text.Json.Serialization;

namespace PocketData;

public class Member
{
	[JsonPropertyName("enemyId")] public int EnemyId { get; set; }

	[JsonPropertyName("x")] public int X { get; set; }

	[JsonPropertyName("y")] public int Y { get; set; }

	[JsonPropertyName("hidden")] public bool Hidden { get; set; }
}