using System.Text.Json.Serialization;

namespace PocketData.Database;

public class Event
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("note")]
	public string Note { get; set; } = string.Empty;

	[JsonPropertyName("pages")]
	public List<Page> Pages { get; set; } = [];

	[JsonPropertyName("x")]
	public int X { get; set; }

	[JsonPropertyName("y")]
	public int Y { get; set; }
	
	public class Page
	{
		[JsonPropertyName("conditions")] 
		public required Conditions Conditions { get; set; }

		[JsonPropertyName("directionFix")] 
		public bool DirectionFix { get; set; }

		[JsonPropertyName("image")] 
		public required Image Image { get; set; }

		[JsonPropertyName("list")]
		public List<EventCommand> List { get; set; } = [];

		[JsonPropertyName("moveFrequency")] 
		public int MoveFrequency { get; set; } = 3;

		[JsonPropertyName("moveRoute")]
		public required MoveRoute MoveRoute { get; set; }

		[JsonPropertyName("moveSpeed")]
		public int MoveSpeed { get; set; }

		[JsonPropertyName("moveType")]
		public int MoveType { get; set; }

		[JsonPropertyName("priorityType")]
		public int PriorityType { get; set; }

		[JsonPropertyName("stepAnime")]
		public bool StepAnime { get; set; }

		[JsonPropertyName("through")]
		public bool Through { get; set; }

		[JsonPropertyName("trigger")]
		public int Trigger { get; set; }

		[JsonPropertyName("walkAnime")]
		public bool WalkAnime { get; set; }
	}
}