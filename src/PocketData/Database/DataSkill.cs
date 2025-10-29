using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataSkill : Data
{
	[JsonPropertyName("message1")]
	public string Message1 { get; set; } = string.Empty;

	[JsonPropertyName("message2")]
	public string Message2 { get; set; } = string.Empty;

	[JsonPropertyName("messageType")]
	public int MessageType { get; set; }

	[JsonPropertyName("mpCost")]
	public int MpCost { get; set; }

	[JsonPropertyName("requiredWtypeId1")]
	public int RequiredWtypeId1 { get; set; }

	[JsonPropertyName("requiredWtypeId2")]
	public int RequiredWtypeId2 { get; set; }

	[JsonPropertyName("stypeId")]
	public int StypeId { get; set; }

	[JsonPropertyName("tpCost")]
	public int TpCost { get; set; }
}