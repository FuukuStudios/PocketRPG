using System.Text.Json.Serialization;

namespace PocketData;

public class MoveRoute
{
	[JsonPropertyName("list")]
	public List<MoveRouteCommand> List { get; set; } = [];

	[JsonPropertyName("repeat")]
	public bool Repeat { get; set; }

	[JsonPropertyName("skippable")]
	public bool Skippable { get; set; }

	[JsonPropertyName("wait")]
	public bool Wait { get; set; }
}