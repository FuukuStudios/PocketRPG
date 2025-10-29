using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataTroop : Data
{
	[JsonPropertyName("members")]
	public required List<Member> Members { get; set; } = [];

	[JsonPropertyName("pages")]
	public required List<Page> Pages { get; set; } = [];
}