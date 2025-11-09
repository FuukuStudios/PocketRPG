using System.Text.Json.Serialization;

namespace PocketData;

public class Action
{
	[JsonPropertyName("conditionParam1")]
	public int ConditionParam1 { get; set; }

	[JsonPropertyName("conditionParam2")]
	public int ConditionParam2 { get; set; }

	[JsonPropertyName("conditionType")]
	public int ConditionType { get; set; }

	[JsonPropertyName("rating")]
	public int Rating { get; set; }

	[JsonPropertyName("skillId")]
	public int SkillId { get; set; }
}