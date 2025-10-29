using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataCommonEventList
{
	[JsonPropertyName("code")]
	public int Code { get; set; }
	
	[JsonPropertyName("indent")]
	public int Indent { get; set; }
	
	[JsonPropertyName("parameters")]
	public required List<object> Parameters { get; set; } = []; // TODO: List types should be (List<int>, bool, ParameterClass, int, and string)
}