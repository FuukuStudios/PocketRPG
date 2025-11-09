using System.Text.Json.Serialization;

namespace PocketData;

public class DropItem
{
	[JsonPropertyName("dataId")]
	public int DataId { get; set; }

	[JsonPropertyName("denominator")]
	public int Denominator { get; set; }

	[JsonPropertyName("kind")]
	public int Kind { get; set; }
}