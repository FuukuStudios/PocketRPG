using System.Text.Json.Serialization;

namespace PocketData.Database;

public class Event : Data
{
	[JsonPropertyName("pages")]
	public required List<Page> Pages { get; set; }
	
	[JsonPropertyName("x")]
	public int X { get; set; }
	
	[JsonPropertyName("y")]
	public int Y { get; set; }
}