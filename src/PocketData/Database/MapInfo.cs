using System.Text.Json.Serialization;

namespace PocketData.Database;

public class MapInfo
{
	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("expanded")]
	public bool Expanded { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	[JsonPropertyName("order")]
	public int Order { get; set; }

	[JsonPropertyName("parentId")]
	public int ParentId { get; set; }

	[JsonPropertyName("scrollX")]
	public double ScrollX { get; set; }

	[JsonPropertyName("scrollY")]
	public double ScrollY { get; set; }
}