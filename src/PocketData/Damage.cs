using System.Text.Json.Serialization;

namespace PocketData;

public class Damage
{
	[JsonPropertyName("critical")] public bool Critical { get; set; }

	[JsonPropertyName("elementId")] public int ElementId { get; set; }

	[JsonPropertyName("formula")] public string Formula { get; set; } = string.Empty;

	[JsonPropertyName("type")] public int Type { get; set; }

	[JsonPropertyName("variance")] public int Variance { get; set; }
}