using System.Text.Json;
using PocketCore.Managers;
using PocketData.Database;

namespace PocketCore;

public class Core
{
	public Actor?[] DataActors { get; internal set; }
	public Class?[] DataClasses { get; internal set; }
	public DataSkill?[] DataSkills { get; internal set; }
	public Item?[] DataItems { get; internal set; }
	public Weapon?[] DataWeapons { get; internal set; }
	public Armor?[] DataArmors { get; internal set; }
	public Enemy?[] DataEnemies { get; internal set; }
	public Troop?[] DataTroops { get; internal set; }
	public State?[] DataStates { get; internal set; }
	public Animation?[] DataAnimations { get; internal set; }
	public Tileset?[] DataTilesets { get; internal set; }
	public CommonEvent?[] DataCommonEvents { get; internal set; }
	public PocketData.Database.System System { get; internal set; }
	public MapInfo?[] DataMapInfos { get; internal set; }
    
	public Event? TestEvent { get; internal set; }

	public Core()
	{
		var test = DataManager.IsBattleTest || DataManager.IsEventTest;
		var prefix = test ? "Test_" : string.Empty;
		
		DataActors = DataManager.LoadDataFile<Actor?[]>($"{prefix}Actors");
		DataClasses = DataManager.LoadDataFile<Class?[]>($"{prefix}Classes");
		DataSkills = DataManager.LoadDataFile<DataSkill?[]>($"{prefix}Skills");
		DataItems = DataManager.LoadDataFile<Item?[]>($"{prefix}Items");
		DataWeapons = DataManager.LoadDataFile<Weapon?[]>($"{prefix}Weapons");
		DataArmors = DataManager.LoadDataFile<Armor?[]>($"{prefix}Armors");
		DataEnemies = DataManager.LoadDataFile<Enemy?[]>($"{prefix}Enemies");
		DataTroops = DataManager.LoadDataFile<Troop?[]>($"{prefix}Troops");
		DataStates = DataManager.LoadDataFile<State?[]>($"{prefix}States");
		DataAnimations = DataManager.LoadDataFile<Animation?[]>($"{prefix}Animations");
		DataTilesets = DataManager.LoadDataFile<Tileset?[]>($"{prefix}Tilesets");
		DataCommonEvents = DataManager.LoadDataFile<CommonEvent?[]>($"{prefix}CommonEvents");
		System = DataManager.LoadDataFile<PocketData.Database.System>($"{prefix}System");
		DataMapInfos = DataManager.LoadDataFile<MapInfo?[]>($"{prefix}MapInfos");
		
		if (DataManager.IsEventTest)
			TestEvent = JsonSerializer.Deserialize<Event?>(File.ReadAllText(Path.Combine("Content", "data", $"{prefix}Event.json"))) ?? throw new Exception($"Failed to load data file '{prefix}Event'.");
	}
}