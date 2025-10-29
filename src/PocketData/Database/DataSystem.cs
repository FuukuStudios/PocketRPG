using System.Text.Json.Serialization;

namespace PocketData.Database;

public class DataSystem
{
    [JsonPropertyName("advanced")]
    public required Advanced Advanced { get; set; }

    [JsonPropertyName("airship")]
    public required Airship Airship { get; set; }

    [JsonPropertyName("armorTypes")]
    public List<string> ArmorTypes { get; set; } = [];

    [JsonPropertyName("attackMotions")]
    public required List<AttackMotion> AttackMotions { get; set; } = [];

    [JsonPropertyName("battleBgm")]
    public required BattleBgm BattleBgm { get; set; }

    [JsonPropertyName("battleback1Name")]
    public string Battleback1Name { get; set; } = string.Empty;

    [JsonPropertyName("battleback2Name")]
    public string Battleback2Name { get; set; } = string.Empty;

    [JsonPropertyName("battlerHue")]
    public int BattlerHue { get; set; }

    [JsonPropertyName("battlerName")]
    public string BattlerName { get; set; } = string.Empty;

    [JsonPropertyName("battleSystem")]
    public int BattleSystem { get; set; }

    [JsonPropertyName("boat")]
    public required Airship Boat { get; set; }

    [JsonPropertyName("currencyUnit")]
    public string CurrencyUnit { get; set; } = string.Empty;

    [JsonPropertyName("defeatMe")]
    public required BattleBgm DefeatMe { get; set; }

    [JsonPropertyName("editMapId")]
    public int EditMapId { get; set; }

    [JsonPropertyName("elements")]
    public List<string> Elements { get; set; } = [];

    [JsonPropertyName("equipTypes")]
    public List<string> EquipTypes { get; set; } = [];

    [JsonPropertyName("gameTitle")]
    public string GameTitle { get; set; } = string.Empty;

    [JsonPropertyName("gameoverMe")]
    public required BattleBgm GameoverMe { get; set; }

    [JsonPropertyName("itemCategories")]
    public List<bool> ItemCategories { get; set; } = [];

    [JsonPropertyName("locale")]
    public string Locale { get; set; } = string.Empty;

    [JsonPropertyName("magicSkills")]
    public List<int> MagicSkills { get; set; } = [];

    [JsonPropertyName("menuCommands")]
    public List<bool> MenuCommands { get; set; } = [];

    [JsonPropertyName("optAutosave")]
    public bool OptAutosave { get; set; }

    [JsonPropertyName("optDisplayTp")]
    public bool OptDisplayTp { get; set; }

    [JsonPropertyName("optDrawTitle")]
    public bool OptDrawTitle { get; set; }

    [JsonPropertyName("optExtraExp")]
    public bool OptExtraExp { get; set; }

    [JsonPropertyName("optFloorDeath")]
    public bool OptFloorDeath { get; set; }

    [JsonPropertyName("optFollowers")]
    public bool OptFollowers { get; set; }

    [JsonPropertyName("optKeyItemsNumber")]
    public bool OptKeyItemsNumber { get; set; }

    [JsonPropertyName("optSideView")]
    public bool OptSideView { get; set; }

    [JsonPropertyName("optSlipDeath")]
    public bool OptSlipDeath { get; set; }

    [JsonPropertyName("optTransparent")]
    public bool OptTransparent { get; set; }

    [JsonPropertyName("partyMembers")]
    public List<int> PartyMembers { get; set; } = [];

    [JsonPropertyName("ship")]
    public required Airship Ship { get; set; }

    [JsonPropertyName("skillTypes")]
    public List<string> SkillTypes { get; set; } = [];

    [JsonPropertyName("sounds")]
    public required List<BattleBgm> Sounds { get; set; } = [];

    [JsonPropertyName("startMapId")]
    public int StartMapId { get; set; }

    [JsonPropertyName("startX")]
    public int StartX { get; set; }

    [JsonPropertyName("startY")]
    public int StartY { get; set; }

    [JsonPropertyName("switches")]
    public List<string> Switches { get; set; } = [];

    [JsonPropertyName("terms")]
    public required Terms Terms { get; set; }

    [JsonPropertyName("testBattlers")]
    public required List<TestBattler> TestBattlers { get; set; } = [];

    [JsonPropertyName("testTroopId")]
    public int TestTroopId { get; set; }

    [JsonPropertyName("title1Name")]
    public string Title1Name { get; set; } = string.Empty;

    [JsonPropertyName("title2Name")]
    public string Title2Name { get; set; } = string.Empty;

    [JsonPropertyName("titleBgm")]
    public required BattleBgm TitleBgm { get; set; }

    [JsonPropertyName("titleCommandWindow")]
    public required TitleCommandWindow TitleCommandWindow { get; set; }

    [JsonPropertyName("variables")]
    public List<string> Variables { get; set; } = [];

    [JsonPropertyName("versionId")]
    public int VersionId { get; set; }

    [JsonPropertyName("victoryMe")]
    public required BattleBgm VictoryMe { get; set; }

    [JsonPropertyName("weaponTypes")]
    public List<string> WeaponTypes { get; set; } = [];

    [JsonPropertyName("windowTone")]
    public List<int> WindowTone { get; set; } = [];
}