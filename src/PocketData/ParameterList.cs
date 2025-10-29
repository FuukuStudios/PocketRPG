using System.Text.Json.Serialization;

namespace PocketData;

public class ParameterList
{
	[JsonPropertyName("code")] public int Code { get; set; }

	[JsonPropertyName("parameters")] public List<int?> Parameters { get; set; } = [];
}