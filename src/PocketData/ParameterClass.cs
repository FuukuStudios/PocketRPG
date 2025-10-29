using System.Text.Json.Serialization;

namespace PocketData;

public class ParameterClass
{
	[JsonPropertyName("name")]
	public string? Name { get; set; }
	
	[JsonPropertyName("volume")]
	public int? Volume { get; set; }
	
	[JsonPropertyName("pitch")]
	public int? Pitch { get; set; }
	
	[JsonPropertyName("pan")]
	public int? Pan { get; set; }
	
	[JsonPropertyName("list")]
	public List<ParameterList>? List { get; set; }
	
	[JsonPropertyName("repeat")]
	public bool? Repeat { get; set; }
	
	[JsonPropertyName("skippable")]
	public bool? Skippable { get; set; }
	
	[JsonPropertyName("wait")]
	public bool? Wait { get; set; }
	
	[JsonPropertyName("code")]
	public int? Code { get; set; }
	
	[JsonPropertyName("parameters")]
	public List<object>? Parameters { get; set; } // TODO: Define a proper type for parameters (supposed to be int or string)
}