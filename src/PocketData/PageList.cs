using System.Text.Json.Serialization;

namespace PocketData;

public class PageList
{
	[JsonPropertyName("code")] public int Code { get; set; }

	[JsonPropertyName("indent")] public int? Indent { get; set; }

	[JsonPropertyName("parameters")]
	public List<object> Parameters { get; set; } = []; // TODO: do less messy type casting
}