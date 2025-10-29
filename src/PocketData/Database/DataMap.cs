using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataMap
{
    [JsonPropertyName("autoplayBgm")]
    public bool AutoplayBgm { get; set; }

    [JsonPropertyName("autoplayBgs")]
    public bool AutoplayBgs { get; set; }

    [JsonPropertyName("battleback1Name")]
    public string Battleback1Name { get; set; } = string.Empty;

    [JsonPropertyName("battleback2Name")]
    public string Battleback2Name { get; set; } = string.Empty;

    [JsonPropertyName("bgm")]
    public required Bgm Bgm { get; set; }

    [JsonPropertyName("bgs")]
    public required Bgm Bgs { get; set; }

    [JsonPropertyName("disableDashing")]
    public bool DisableDashing { get; set; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("encounterList")]
    public List<object> EncounterList { get; set; } = [];

    [JsonPropertyName("encounterStep")]
    public int EncounterStep { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("note")]
    public string Note { get; set; } = string.Empty;

    [JsonPropertyName("parallaxLoopX")]
    public bool ParallaxLoopX { get; set; }

    [JsonPropertyName("parallaxLoopY")]
    public bool ParallaxLoopY { get; set; }

    [JsonPropertyName("parallaxName")]
    public string ParallaxName { get; set; } = string.Empty;

    [JsonPropertyName("parallaxShow")]
    public bool ParallaxShow { get; set; }

    [JsonPropertyName("parallaxSx")]
    public int ParallaxSx { get; set; }

    [JsonPropertyName("parallaxSy")]
    public int ParallaxSy { get; set; }

    [JsonPropertyName("scrollType")]
    public int ScrollType { get; set; }

    [JsonPropertyName("specifyBattleback")]
    public bool SpecifyBattleback { get; set; }

    [JsonPropertyName("tilesetId")]
    public int TilesetId { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("data")]
    public List<int> Data { get; set; } = [];

    [JsonPropertyName("events")]
    public List<Event?> Events { get; set; } = [];
}