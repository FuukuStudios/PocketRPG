using System.Text.Json.Serialization;

namespace PocketData;

public class Learning
{
	[JsonPropertyName("level")] 
	public int Level { get; set; }

	[JsonPropertyName("note")] 
	public string Note { get; set; } = string.Empty;

	[JsonPropertyName("skillId")] 
	public int SkillId { get; set; }
}