using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataArmor
{
	[JsonPropertyName("atypeId")]
	public int AtypeId { get; set; }
}