using System.Text.Json;
using PocketData.Database;

namespace PocketCore.Managers;

public static class DataManager
{
	public static object? _globalInfo; // TODO: define type
	
	/// <summary>
	/// Sets core data objects by loading from JSON files.
	/// </summary>
	public static void LoadDatabase()
	{
		IsDatabaseLoaded = false;

		try
		{
			var test = IsBattleTest || IsEventTest;
			var prefix = test ? "Test_" : string.Empty;
			
			Core.DataActors = LoadDataFile<DataActor?[]>($"{prefix}Actors");
			Core.DataClasses = LoadDataFile<DataClass?[]>($"{prefix}Classes");
			Core.DataSkills = LoadDataFile<DataSkill?[]>($"{prefix}Skills");
			Core.DataItems = LoadDataFile<DataItem?[]>($"{prefix}Items");
			Core.DataWeapons = LoadDataFile<DataWeapon?[]>($"{prefix}Weapons");
			Core.DataArmors = LoadDataFile<DataArmor?[]>($"{prefix}Armors");
			Core.DataEnemies = LoadDataFile<DataEnemy?[]>($"{prefix}Enemies");
			Core.DataTroops = LoadDataFile<DataTroop?[]>($"{prefix}Troops");
			Core.DataStates = LoadDataFile<DataState?[]>($"{prefix}States");
			Core.DataAnimations = LoadDataFile<DataAnimation?[]>($"{prefix}Animations");
			Core.DataTilesets = LoadDataFile<DataTileset?[]>($"{prefix}Tilesets");
			Core.DataCommonEvents = LoadDataFile<DataCommonEvent?[]>($"{prefix}CommonEvents");
			Core.DataSystem = LoadDataFile<DataSystem>($"{prefix}System");
			Core.DataMapInfos = LoadDataFile<DataMapInfo?[]>($"{prefix}MapInfos");
			
			if (IsEventTest)
				Core.TestEvent = JsonSerializer.Deserialize<Event?>(File.ReadAllText(Path.Combine("Content", "data", $"{prefix}Event.json"))) ?? throw new Exception($"Failed to load data file '{prefix}Event'.");
			
			IsDatabaseLoaded = true;
		}
		catch (Exception ex)
		{
			IsDatabaseLoaded = false;
			Console.WriteLine($"Error loading database: {ex}");
			throw;
		}
	}

	public static T LoadDataFile<T>(string filename)
	{
		return JsonSerializer.Deserialize<T>(File.ReadAllText(Path.Combine("Content", "data", $"{filename}.json"))) ?? throw new Exception($"Failed to load data file '{filename}'.");
	}
	
	public static bool IsDatabaseLoaded { get; private set; }
	
	public static bool IsBattleTest => Utils.IsOptionValid("btest");
	public static bool IsEventTest => Utils.IsOptionValid("etest");
	public static bool IsTitleSkip => Utils.IsOptionValid("tskip");
	
	public static void LoadGlobalInfo()
	{
		// TODO: Load "global" save data
	}
	
	public static bool IsGlobalInfoLoaded => _globalInfo != null;

	public static void SetupNewGame()
	{
		CreateGameObjects();
		SelectSavefileForNewGame();
	}

	public static void CreateGameObjects()
	{
		
	}
	
}