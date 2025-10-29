using System.Text.Json.Serialization;

namespace PocketData;

public class DropItem
{
	[JsonPropertyName("kind")] public int Kind { get; set; }

	[JsonPropertyName("dataId")] public int DataId { get; set; }

	[JsonPropertyName("denominator")] public int Denominator { get; set; }
}