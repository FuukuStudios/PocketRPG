using System.Text.Json.Serialization;

namespace PocketData.Database;

public class Enemy
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("actions")]
	public List<Action> Actions { get; set; } = [];

	[JsonPropertyName("battlerHue")]
	public int BattlerHue { get; set; }

	[JsonPropertyName("battlerName")]
	public string BattlerName { get; set; } = string.Empty;

	[JsonPropertyName("dropItems")]
	public List<DropItem> DropItems { get; set; } = [];

	[JsonPropertyName("exp")]
	public int Exp { get; set; }

	[JsonPropertyName("traits")]
	public List<Trait> Traits { get; set; } = [];

	[JsonPropertyName("gold")]
	public int Gold { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("note")]
	public string Note { get; set; } = string.Empty;

	[JsonPropertyName("params")]
	public required int[] Params { get; set; } = new int[8];
}