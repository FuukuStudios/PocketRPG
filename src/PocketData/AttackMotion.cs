using System.Text.Json.Serialization;

namespace PocketData;

public class AttackMotion
{
	[JsonPropertyName("type")] public int Type { get; set; }

	[JsonPropertyName("weaponImageId")] public int WeaponImageId { get; set; }
}