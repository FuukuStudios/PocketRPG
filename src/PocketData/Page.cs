using System.Text.Json.Serialization;

namespace PocketData;

public class Page
{
	[JsonPropertyName("conditions")] public required Conditions Conditions { get; set; }

	[JsonPropertyName("directionFix")] public bool DirectionFix { get; set; }

	[JsonPropertyName("image")] public required Image Image { get; set; }

	[JsonPropertyName("list")] public List<PageList> List { get; set; } = [];

	[JsonPropertyName("moveFrequency")] public int MoveFrequency { get; set; }

	[JsonPropertyName("moveRoute")] public required MoveRoute MoveRoute { get; set; }

	[JsonPropertyName("moveSpeed")] public int MoveSpeed { get; set; }

	[JsonPropertyName("moveType")] public int MoveType { get; set; }

	[JsonPropertyName("priorityType")] public int PriorityType { get; set; }

	[JsonPropertyName("stepAnime")] public bool StepAnime { get; set; }

	[JsonPropertyName("through")] public bool Through { get; set; }

	[JsonPropertyName("trigger")] public int Trigger { get; set; }

	[JsonPropertyName("walkAnime")] public bool WalkAnime { get; set; }
}