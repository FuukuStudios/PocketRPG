using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataCommonEvent
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("list")]
	public required List<DataCommonEventList> List { get; set; } = [];

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("switchId")]
	public int SwitchId { get; set; }

	[JsonPropertyName("trigger")]
	public int Trigger { get; set; }
}