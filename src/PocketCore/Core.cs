using PocketData.Database;

namespace PocketCore;

public static class Core
{
	public static DataActor?[] DataActors { get; internal set; }
	public static DataClass?[] DataClasses { get; internal set; }
	public static DataSkill?[] DataSkills { get; internal set; }
	public static DataItem?[] DataItems { get; internal set; }
	public static DataWeapon?[] DataWeapons { get; internal set; }
	public static DataArmor?[] DataArmors { get; internal set; }
	public static DataEnemy?[] DataEnemies { get; internal set; }
	public static DataTroop?[] DataTroops { get; internal set; }
	public static DataState?[] DataStates { get; internal set; }
	public static DataAnimation?[] DataAnimations { get; internal set; }
	public static DataTileset?[] DataTilesets { get; internal set; }
	public static DataCommonEvent?[] DataCommonEvents { get; internal set; }
	public static DataSystem DataSystem { get; internal set; }
	public static DataMapInfo?[] DataMapInfos { get; internal set; }
    
	public static Event? TestEvent { get; internal set; }
}