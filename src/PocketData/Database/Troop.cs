using System.Text.Json.Serialization;

namespace PocketData.Database;

public class Troop
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("members")]
	public List<Member> Members { get; set; } = [];

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("pages")]
	public List<Page> Pages { get; set; } = [];

	public class Member {
		[JsonPropertyName("enemyId")]
		public int EnemyId { get; set; }

		[JsonPropertyName("x")]
		public int X { get; set; }

		[JsonPropertyName("y")]
		public int Y { get; set; }

		[JsonPropertyName("hidden")]
		public bool Hidden { get; set; }
	}

	public class Page {
		[JsonPropertyName("conditions")]
		public required Conditions Conditions { get; set; }

		[JsonPropertyName("list")]
		public List<EventCommand> List { get; set; } = [];

		[JsonPropertyName("span")]
		public int Span { get; set; }
	}

	public class Condition {
		[JsonPropertyName("actorHp")]
		public int ActorHp { get; set; }

		[JsonPropertyName("actorId")]
		public int ActorId { get; set; }

		[JsonPropertyName("actorValid")]
		public bool ActorValid { get; set; }

		[JsonPropertyName("enemyHp")]
		public int EnemyHp { get; set; }

		[JsonPropertyName("enemyIndex")]
		public int EnemyIndex { get; set; }

		[JsonPropertyName("enemyValid")]
		public bool EnemyValid { get; set; }

		[JsonPropertyName("switchId")]
		public int SwitchId { get; set; }

		[JsonPropertyName("switchValid")]
		public bool SwitchValid { get; set; }

		[JsonPropertyName("turnA")]
		public int TurnA { get; set; }

		[JsonPropertyName("turnB")]
		public int TurnB { get; set; }

		[JsonPropertyName("turnEnding")]
		public bool TurnEnding { get; set; }

		[JsonPropertyName("turnValid")]
		public bool TurnValid { get; set; }
	}
}