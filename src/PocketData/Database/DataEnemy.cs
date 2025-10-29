using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataEnemy : Data
{
	[JsonPropertyName("actions")]
	public required List<Action> Actions { get; set; } = [];

	[JsonPropertyName("battlerHue")]
	public int BattlerHue { get; set; }

	[JsonPropertyName("battlerName")]
	public string BattlerName { get; set; } = string.Empty;

	[JsonPropertyName("dropItems")]
	public required List<DropItem> DropItems { get; set; } = [];

	[JsonPropertyName("exp")]
	public int Exp { get; set; }

	[JsonPropertyName("traits")]
	public required List<Trait> Traits { get; set; } = [];

	[JsonPropertyName("gold")]
	public int Gold { get; set; }

	[JsonPropertyName("params")]
	public List<int> Params { get; set; } = [];
}