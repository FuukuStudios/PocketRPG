using System.Text.Json.Serialization;

namespace PocketData;

public class Trait
{
	[JsonPropertyName("code")]
	public int Code { get; set; }

	[JsonPropertyName("dataId")]
	public int DataId { get; set; }

	[JsonPropertyName("value")]
	public double Value { get; set; }

}