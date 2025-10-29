using System.Text.Json.Serialization;

namespace PocketData;

public class Effect
{
	[JsonPropertyName("code")] public int Code { get; set; }

	[JsonPropertyName("dataId")] public int DataId { get; set; }

	[JsonPropertyName("value1")] public int Value1 { get; set; }

	[JsonPropertyName("value2")] public int Value2 { get; set; }
}