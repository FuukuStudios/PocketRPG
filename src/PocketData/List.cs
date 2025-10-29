using System.Text.Json.Serialization;

namespace PocketData;

public class List // Not to be confused with ParameterList
{
	[JsonPropertyName("code")] public int Code { get; set; }

	[JsonPropertyName("indent")] public int Indent { get; set; }

	[JsonPropertyName("parameters")] public List<int> Parameters { get; set; } = [];
}