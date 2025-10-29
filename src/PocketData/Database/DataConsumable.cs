using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataConsumable : DataItemBase
{
	[JsonPropertyName("animationId")]
	public int AnimationId { get; set; }

	[JsonPropertyName("damage")]
	public required Damage Damage { get; set; }

	[JsonPropertyName("effects")]
	public required List<Effect> Effects { get; set; }

	[JsonPropertyName("hitType")]
	public int HitType { get; set; }

	[JsonPropertyName("occasion")]
	public int Occasion { get; set; }

	[JsonPropertyName("repeats")]
	public int Repeats { get; set; }

	[JsonPropertyName("scope")]
	public int Scope { get; set; }

	[JsonPropertyName("speed")]
	public int Speed { get; set; }

	[JsonPropertyName("successRate")]
	public int SuccessRate { get; set; }

	[JsonPropertyName("tpGain")]
	public int TpGain { get; set; }
}