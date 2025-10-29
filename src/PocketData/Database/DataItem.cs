using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataItem : Data
{
	[JsonPropertyName("itypeId")]
	public int ItypeId { get; set; }
	
	[JsonPropertyName("price")]
	public int Price { get; set; }
}