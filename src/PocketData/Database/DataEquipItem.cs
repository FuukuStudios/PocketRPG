using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataEquipItem : DataItemBase
{
	[JsonPropertyName("etypeId")]
	public int EtypeId { get; set; }
	
	[JsonPropertyName("traits")]
	public List<Trait> Traits { get; set; } = [];
	
	[JsonPropertyName("params")]
	public List<int> Params { get; set; } = [];
	
	[JsonPropertyName("price")]
	public int Price { get; set; }
}