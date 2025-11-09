using System.Text.Json.Serialization;

namespace PocketData;

public class Terms
{
	[JsonPropertyName("basic")] public List<string> Basic { get; set; } = [];

	[JsonPropertyName("commands")] public List<string> Commands { get; set; } = [];

	[JsonPropertyName("params")] public List<string> Params { get; set; } = [];

	[JsonPropertyName("messages")] public required Messages Messages { get; set; }
}