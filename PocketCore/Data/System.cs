// ReSharper disable InconsistentNaming
namespace PocketCore.Data;

/// <summary>
///     The game object class for system data, translated from rmmz_objects.js.
/// </summary>
public class System
{
    public Advanced advanced { get; set; }
    public Vehicle airship { get; set; }
    public string[] armorTypes { get; set; }
    public AttackMotions[] attackMotions { get; set; }
    public Audio battleBgm { get; set; }
    public string battleBack1Name { get; set; }
    public string battleBack2Name { get; set; }
    public int battlerHue { get; set; }
    public string battlerName { get; set; }
    public int battleSystem { get; set; }
    public Vehicle boat { get; set; }
    public string currencyUnit { get; set; }
    public Audio defeatMe { get; set; }
    public int editMapId { get; set; }
    public string[] elements { get; set; }
    public string[] equipTypes { get; set; }
    public string gameTitle { get; set; }
    public Audio gameOverMe { get; set; }
    public bool[] itemCategories { get; set; }
    public string locale { get; set; }
    public int[] magicSkills { get; set; }
    public bool[] menuCommands { get; set; }
    public bool optAutosave { get; set; }
    public bool optDisplayTp { get; set; }
    public bool optDrawTitle { get; set; }
    public bool optExtraExp { get; set; }
    public bool optFloorDeath { get; set; }
    public bool optFollowers { get; set; }
    public bool optKeyItemsNumber { get; set; }
    public bool optSideView { get; set; }
    public bool optSlipDeath { get; set; }
    public bool optTransparent { get; set; }
    public int[] partyMembers { get; set; }
    public Vehicle ship { get; set; }
    public string[] skillTypes { get; set; }
    public Audio[] sounds { get; set; }
    public int startMapId { get; set; }
    public int startX { get; set; }
    public int startY { get; set; }
    public string[] switches { get; set; }
    public Terms terms { get; set; }
    public TestBattlers[] testBattlers { get; set; }
    public int testTroopId { get; set; }
    public string title1Name { get; set; }
    public string title2Name { get; set; }
    public Audio titleBgm { get; set; }
    public TitleCommandWindow titleCommandWindow { get; set; }
    public string[] variables { get; set; }
    public int versionId { get; set; }
    public Audio victoryMe { get; set; }
    public string[] weaponTypes { get; set; }
    public int[] windowTone { get; set; }
    public Editor editor { get; set; }
    public int faceSize { get; set; }
    public int iconSize { get; set; }
    public bool optSplashScreen { get; set; }
    public bool optMessageSkip { get; set; }
    public int tileSize { get; set; }

    public class Advanced
    {
        public int gameId { get; set; }
        public int screenWidth { get; set; }
        public int screenHeight { get; set; }
        public int uiAreaWidth { get; set; }
        public int uiAreaHeight { get; set; }
        public string numberFontFilename { get; set; }
        public string fallbackFonts { get; set; }
        public int fontSize { get; set; }
        public string mainFontFilename { get; set; }
        public int screenScale { get; set; }
        public int windowOpacity { get; set; }
        public int picturesUpperLimit { get; set; }
    }

    public class AttackMotions
    {
        public int type { get; set; }
        public int weaponImageId { get; set; }
    }

    public class Terms
    {
        public string[] basic { get; set; }
        public string[] commands { get; set; }
        public string[] @params { get; set; }
        public Messages messages { get; set; }
    }

    public class Messages
    {
        public string alwaysDash { get; set; }
        public string commandRemember { get; set; }
        public string touchUi { get; set; }
        public string bgmVolume { get; set; }
        public string bgsVolume { get; set; }
        public string meVolume { get; set; }
        public string seVolume { get; set; }
        public string possession { get; set; }
        public string expTotal { get; set; }
        public string expNext { get; set; }
        public string saveMessage { get; set; }
        public string loadMessage { get; set; }
        public string file { get; set; }
        public string autosave { get; set; }
        public string partyName { get; set; }
        public string emerge { get; set; }
        public string preemptive { get; set; }
        public string surprise { get; set; }
        public string escapeStart { get; set; }
        public string escapeFailure { get; set; }
        public string victory { get; set; }
        public string defeat { get; set; }
        public string obtainExp { get; set; }
        public string obtainGold { get; set; }
        public string obtainItem { get; set; }
        public string levelUp { get; set; }
        public string obtainSkill { get; set; }
        public string useItem { get; set; }
        public string criticalToEnemy { get; set; }
        public string criticalToActor { get; set; }
        public string actorDamage { get; set; }
        public string actorRecovery { get; set; }
        public string actorGain { get; set; }
        public string actorLoss { get; set; }
        public string actorDrain { get; set; }
        public string actorNoDamage { get; set; }
        public string actorNoHit { get; set; }
        public string enemyDamage { get; set; }
        public string enemyRecovery { get; set; }
        public string enemyGain { get; set; }
        public string enemyLoss { get; set; }
        public string enemyDrain { get; set; }
        public string enemyNoDamage { get; set; }
        public string enemyNoHit { get; set; }
        public string evasion { get; set; }
        public string magicEvasion { get; set; }
        public string magicReflection { get; set; }
        public string counterAttack { get; set; }
        public string substitute { get; set; }
        public string buffAdd { get; set; }
        public string debuffAdd { get; set; }
        public string buffRemove { get; set; }
        public string actionFailure { get; set; }
    }

    public class TestBattlers
    {
        public int actorId { get; set; }
        public int level { get; set; }
        public int[] equips { get; set; }
    }

    public class TitleCommandWindow
    {
        public int background { get; set; }
        public int offsetX { get; set; }
        public int offsetY { get; set; }
    }

    public class Editor
    {
        public int messageWidth1 { get; set; }
        public int messageWidth2 { get; set; }
        public int jsonFormatLevel { get; set; }
    }
}