using System.Numerics;
using System.Text.Json.Serialization;

namespace PocketData.Database;

public class Animation
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
	public Vector3 Rotation { get; set; }

	[JsonPropertyName("scale")]
	public int Scale { get; set; }

	[JsonPropertyName("soundTimings")]
	public List<SoundTiming> SoundTimings { get; set; } = [];

	[JsonPropertyName("speed")]
	public int Speed { get; set; }

	public class Timing
	{
		[JsonPropertyName("flashColor")]
		public required Tuple<int, int, int, int> FlashColor { get; set; }

		[JsonPropertyName("flashDuration")]
		public int FlashDuration { get; set; }

		[JsonPropertyName("flashScope")]
		public int FlashScope { get; set; }

		[JsonPropertyName("frame")]
		public int Frame { get; set; }

		[JsonPropertyName("se")]
		public required Audio Audio { get; set; }
	}

	public class FlashTiming
	{
		[JsonPropertyName("frame")]
		public int Frame { get; set; }

		[JsonPropertyName("duration")]
		public int Duration { get; set; }

		[JsonPropertyName("color")]
		public required Tuple<int, int, int, int> Color { get; set; }
	}
	
	public class SoundTiming
	{
		[JsonPropertyName("frame")]
		public int Frame { get; set; }

		[JsonPropertyName("se")]
		public required Audio Audio { get; set; }
	}
}