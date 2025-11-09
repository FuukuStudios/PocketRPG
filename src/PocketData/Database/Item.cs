using System.Text.Json.Serialization;

namespace PocketData.Database;

public class Item
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("animationId")]
	public int AnimationId { get; set; }

	[JsonPropertyName("damage")]
	public required Damage Damage { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; } = string.Empty;

	[JsonPropertyName("effects")]
	public List<Effect> Effects { get; set; } = [];

	[JsonPropertyName("hitType")]
	public int HitType { get; set; }

	[JsonPropertyName("iconIndex")]
	public int IconIndex { get; set; }

	[JsonPropertyName("message1")]
	public string Message1 { get; set; } = string.Empty;

	[JsonPropertyName("message2")]
	public string Message2 { get; set; } = string.Empty;

	[JsonPropertyName("mpCost")]
	public int MpCost { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("note")]
	public string Note { get; set; } = string.Empty;

	[JsonPropertyName("occasion")]
	public int Occasion { get; set; }

	[JsonPropertyName("repeats")]
	public int Repeats { get; set; }

	[JsonPropertyName("requiredWtypeId1")]
	public int RequiredWtypeId1 { get; set; }

	[JsonPropertyName("requiredWtypeId2")]
	public int RequiredWtypeId2 { get; set; }

	[JsonPropertyName("scope")]
	public int Scope { get; set; }

	[JsonPropertyName("speed")]
	public int Speed { get; set; }

	[JsonPropertyName("stypeId")]
	public int StypeId { get; set; }

	[JsonPropertyName("successRate")]
	public int SuccessRate { get; set; }

	[JsonPropertyName("tpCost")]
	public int TpCost { get; set; }

	[JsonPropertyName("tpGain")]
	public int TpGain { get; set; }

	[JsonPropertyName("messageType")]
	public int MessageType { get; set; }

	[JsonPropertyName("price")]
	public int Price { get; set; }

	[JsonPropertyName("itypeId")]
	public int ItypeId { get; set; }
}