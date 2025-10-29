using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataItemBase : Data
{
	[JsonPropertyName("description")]
	public string Description { get; set; } = string.Empty;
	
	[JsonPropertyName("iconIndex")]
	public int IconIndex { get; set; }
}