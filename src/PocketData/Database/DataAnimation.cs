using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataAnimation
{
	[JsonPropertyName("id")]
	public int Id { get; set; }
	
	[JsonPropertyName("displayType")]
	public int DisplayType { get; set; }
	
	[JsonPropertyName("effectName")]
	public string EffectName { get; set; } = string.Empty;
	
	[JsonPropertyName("flashTimings")]
	public List<FlashTiming> FlashTimings { get; set; } = [];
	
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;
	
	[JsonPropertyName("offsetX")]
	public int OffsetX { get; set; }
	
	[JsonPropertyName("offsetY")]
	public int OffsetY { get; set; }
	
	[JsonPropertyName("rotation")]
	public required Rotation Rotation { get; set; }
	
	[JsonPropertyName("scale")]
	public int Scale { get; set; }
	
	[JsonPropertyName("soundTimings")]
	public List<SoundTiming> SoundTimings { get; set; } = [];
	
	[JsonPropertyName("speed")]
	public int Speed { get; set; }
}