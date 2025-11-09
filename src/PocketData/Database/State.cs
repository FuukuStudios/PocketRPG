using System.Text.Json.Serialization;

namespace PocketData.Database;

public class State
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("autoRemovalTiming")]
	public int AutoRemovalTiming { get; set; }

	[JsonPropertyName("chanceByDamage")]
	public int ChanceByDamage { get; set; }

	[JsonPropertyName("iconIndex")]
	public int IconIndex { get; set; }

	[JsonPropertyName("maxTurns")]
	public int MaxTurns { get; set; }

	[JsonPropertyName("message1")]
	public string Message1 { get; set; } = string.Empty;

	[JsonPropertyName("message2")]
	public string Message2 { get; set; } = string.Empty;

	[JsonPropertyName("message3")]
	public string Message3 { get; set; } = string.Empty;

	[JsonPropertyName("message4")]
	public string Message4 { get; set; } = string.Empty;

	[JsonPropertyName("minTurns")]
	public int MinTurns { get; set; }

	[JsonPropertyName("motion")]
	public int Motion { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("note")]
	public string Note { get; set; } = string.Empty;

	[JsonPropertyName("overlay")]
	public int Overlay { get; set; }

	[JsonPropertyName("priority")]
	public int Priority { get; set; }

	[JsonPropertyName("releaseByDamage")]
	public bool ReleaseByDamage { get; set; }

	[JsonPropertyName("removeAtBattleEnd")]
	public bool RemoveAtBattleEnd { get; set; }

	[JsonPropertyName("removeByDamage")]
	public bool RemoveByDamage { get; set; }

	[JsonPropertyName("removeByRestriction")]
	public bool RemoveByRestriction { get; set; }

	[JsonPropertyName("removeByWalking")]
	public bool RemoveByWalking { get; set; }

	[JsonPropertyName("restriction")]
	public int Restriction { get; set; }

	[JsonPropertyName("stepsToRemove")]
	public int StepsToRemove { get; set; }

	[JsonPropertyName("traits")]
	public List<Trait> Traits { get; set; } = [];

	[JsonPropertyName("messageType")]
	public int MessageType { get; set; }
}