using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataWeapon : DataEquipItem
{
	[JsonPropertyName("animationId")]
	public int AnimationId { get; set; }
	
	[JsonPropertyName("wtypeId")]
	public int WtypeId { get; set; }
}