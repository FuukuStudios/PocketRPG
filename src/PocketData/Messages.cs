using System.Text.Json.Serialization;

namespace PocketData;

public class Messages
{
	[JsonPropertyName("alwaysDash")]
	public string AlwaysDash { get; set; } = string.Empty;

	[JsonPropertyName("commandRemember")]
	public string CommandRemember { get; set; } = string.Empty;

	[JsonPropertyName("touchUI")]
	public string TouchUi { get; set; } = string.Empty;

	[JsonPropertyName("bgmVolume")]
	public string BgmVolume { get; set; } = string.Empty;

	[JsonPropertyName("bgsVolume")]
	public string BgsVolume { get; set; } = string.Empty;

	[JsonPropertyName("meVolume")]
	public string MeVolume { get; set; } = string.Empty;

	[JsonPropertyName("seVolume")]
	public string SeVolume { get; set; } = string.Empty;

	[JsonPropertyName("possession")]
	public string Possession { get; set; } = string.Empty;

	[JsonPropertyName("expTotal")]
	public string ExpTotal { get; set; } = string.Empty;

	[JsonPropertyName("expNext")]
	public string ExpNext { get; set; } = string.Empty;

	[JsonPropertyName("saveMessage")]
	public string SaveMessage { get; set; } = string.Empty;

	[JsonPropertyName("loadMessage")]
	public string LoadMessage { get; set; } = string.Empty;

	[JsonPropertyName("file")]
	public string File { get; set; } = string.Empty;

	[JsonPropertyName("autosave")]
	public string Autosave { get; set; } = string.Empty;

	[JsonPropertyName("partyName")]
	public string PartyName { get; set; } = string.Empty;

	[JsonPropertyName("emerge")]
	public string Emerge { get; set; } = string.Empty;

	[JsonPropertyName("preemptive")]
	public string Preemptive { get; set; } = string.Empty;

	[JsonPropertyName("surprise")]
	public string Surprise { get; set; } = string.Empty;

	[JsonPropertyName("escapeStart")]
	public string EscapeStart { get; set; } = string.Empty;

	[JsonPropertyName("escapeFailure")]
	public string EscapeFailure { get; set; } = string.Empty;

	[JsonPropertyName("victory")]
	public string Victory { get; set; } = string.Empty;

	[JsonPropertyName("defeat")]
	public string Defeat { get; set; } = string.Empty;

	[JsonPropertyName("obtainExp")]
	public string ObtainExp { get; set; } = string.Empty;

	[JsonPropertyName("obtainGold")]
	public string ObtainGold { get; set; } = string.Empty;

	[JsonPropertyName("obtainItem")]
	public string ObtainItem { get; set; } = string.Empty;

	[JsonPropertyName("levelUp")]
	public string LevelUp { get; set; } = string.Empty;

	[JsonPropertyName("obtainSkill")]
	public string ObtainSkill { get; set; } = string.Empty;

	[JsonPropertyName("useItem")]
	public string UseItem { get; set; } = string.Empty;

	[JsonPropertyName("criticalToEnemy")]
	public string CriticalToEnemy { get; set; } = string.Empty;

	[JsonPropertyName("criticalToActor")]
	public string CriticalToActor { get; set; } = string.Empty;

	[JsonPropertyName("actorDamage")]
	public string ActorDamage { get; set; } = string.Empty;

	[JsonPropertyName("actorRecovery")]
	public string ActorRecovery { get; set; } = string.Empty;

	[JsonPropertyName("actorGain")]
	public string ActorGain { get; set; } = string.Empty;

	[JsonPropertyName("actorLoss")]
	public string ActorLoss { get; set; } = string.Empty;

	[JsonPropertyName("actorDrain")]
	public string ActorDrain { get; set; } = string.Empty;

	[JsonPropertyName("actorNoDamage")]
	public string ActorNoDamage { get; set; } = string.Empty;

	[JsonPropertyName("actorNoHit")]
	public string ActorNoHit { get; set; } = string.Empty;

	[JsonPropertyName("enemyDamage")]
	public string EnemyDamage { get; set; } = string.Empty;

	[JsonPropertyName("enemyRecovery")]
	public string EnemyRecovery { get; set; } = string.Empty;

	[JsonPropertyName("enemyGain")]
	public string EnemyGain { get; set; } = string.Empty;

	[JsonPropertyName("enemyLoss")]
	public string EnemyLoss { get; set; } = string.Empty;

	[JsonPropertyName("enemyDrain")]
	public string EnemyDrain { get; set; } = string.Empty;

	[JsonPropertyName("enemyNoDamage")]
	public string EnemyNoDamage { get; set; } = string.Empty;

	[JsonPropertyName("enemyNoHit")]
	public string EnemyNoHit { get; set; } = string.Empty;

	[JsonPropertyName("evasion")]
	public string Evasion { get; set; } = string.Empty;

	[JsonPropertyName("magicEvasion")]
	public string MagicEvasion { get; set; } = string.Empty;

	[JsonPropertyName("magicReflection")]
	public string MagicReflection { get; set; } = string.Empty;

	[JsonPropertyName("counterAttack")]
	public string CounterAttack { get; set; } = string.Empty;

	[JsonPropertyName("substitute")]
	public string Substitute { get; set; } = string.Empty;

	[JsonPropertyName("buffAdd")]
	public string BuffAdd { get; set; } = string.Empty;

	[JsonPropertyName("debuffAdd")]
	public string DebuffAdd { get; set; } = string.Empty;

	[JsonPropertyName("buffRemove")]
	public string BuffRemove { get; set; } = string.Empty;

	[JsonPropertyName("actionFailure")]
	public string ActionFailure { get; set; } = string.Empty;
}