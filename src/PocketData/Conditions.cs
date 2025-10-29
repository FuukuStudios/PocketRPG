using System.Text.Json.Serialization;

namespace PocketData;

public class Conditions
{
	[JsonPropertyName("actorId")] public int ActorId { get; set; }

	[JsonPropertyName("actorValid")] public bool ActorValid { get; set; }

	[JsonPropertyName("itemId")] public int ItemId { get; set; }

	[JsonPropertyName("itemValid")] public bool ItemValid { get; set; }

	[JsonPropertyName("selfSwitchCh")] public string SelfSwitchCh { get; set; } = string.Empty;

	[JsonPropertyName("selfSwitchValid")] public bool SelfSwitchValid { get; set; }

	[JsonPropertyName("switch1Id")] public int Switch1Id { get; set; }

	[JsonPropertyName("switch1Valid")] public bool Switch1Valid { get; set; }

	[JsonPropertyName("switch2Id")] public int Switch2Id { get; set; }

	[JsonPropertyName("switch2Valid")] public bool Switch2Valid { get; set; }

	[JsonPropertyName("variableId")] public int VariableId { get; set; }

	[JsonPropertyName("variableValid")] public bool VariableValid { get; set; }

	[JsonPropertyName("variableValue")] public int VariableValue { get; set; }
}