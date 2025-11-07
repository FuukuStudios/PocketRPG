using System.Text.Json;
using PocketCore.Managers;
using PocketData.Database;

namespace PocketCore;

public class Core
{
	public DataActor?[] DataActors { get; internal set; }
	public DataClass?[] DataClasses { get; internal set; }
	public DataSkill?[] DataSkills { get; internal set; }
	public DataItem?[] DataItems { get; internal set; }
	public DataWeapon?[] DataWeapons { get; internal set; }
	public DataArmor?[] DataArmors { get; internal set; }
	public DataEnemy?[] DataEnemies { get; internal set; }
	public DataTroop?[] DataTroops { get; internal set; }
	public DataState?[] DataStates { get; internal set; }
	public DataAnimation?[] DataAnimations { get; internal set; }
	public DataTileset?[] DataTilesets { get; internal set; }
	public DataCommonEvent?[] DataCommonEvents { get; internal set; }
	public DataSystem DataSystem { get; internal set; }
	public DataMapInfo?[] DataMapInfos { get; internal set; }
    
	public Event? TestEvent { get; internal set; }

	public Core()
	{
		var test = DataManager.IsBattleTest || DataManager.IsEventTest;
		var prefix = test ? "Test_" : string.Empty;
		
		DataActors = DataManager.LoadDataFile<DataActor?[]>($"{prefix}Actors");
		DataClasses = DataManager.LoadDataFile<DataClass?[]>($"{prefix}Classes");
		DataSkills = DataManager.LoadDataFile<DataSkill?[]>($"{prefix}Skills");
		DataItems = DataManager.LoadDataFile<DataItem?[]>($"{prefix}Items");
		DataWeapons = DataManager.LoadDataFile<DataWeapon?[]>($"{prefix}Weapons");
		DataArmors = DataManager.LoadDataFile<DataArmor?[]>($"{prefix}Armors");
		DataEnemies = DataManager.LoadDataFile<DataEnemy?[]>($"{prefix}Enemies");
		DataTroops = DataManager.LoadDataFile<DataTroop?[]>($"{prefix}Troops");
		DataStates = DataManager.LoadDataFile<DataState?[]>($"{prefix}States");
		DataAnimations = DataManager.LoadDataFile<DataAnimation?[]>($"{prefix}Animations");
		DataTilesets = DataManager.LoadDataFile<DataTileset?[]>($"{prefix}Tilesets");
		DataCommonEvents = DataManager.LoadDataFile<DataCommonEvent?[]>($"{prefix}CommonEvents");
		DataSystem = DataManager.LoadDataFile<DataSystem>($"{prefix}System");
		DataMapInfos = DataManager.LoadDataFile<DataMapInfo?[]>($"{prefix}MapInfos");
		
		if (DataManager.IsEventTest)
			TestEvent = JsonSerializer.Deserialize<Event?>(File.ReadAllText(Path.Combine("Content", "data", $"{prefix}Event.json"))) ?? throw new Exception($"Failed to load data file '{prefix}Event'.");
	}
}