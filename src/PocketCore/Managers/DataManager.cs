using System.Reflection;
using System.Text.Json;
using PocketData.Database;

namespace PocketCore.Managers;

public static class DataManager
{
	public static object? _globalInfo; // TODO: define type

	public static T LoadDataFile<T>(string filename)
	{
		return JsonSerializer.Deserialize<T>(File.ReadAllText(Path.Combine("Content", "data", $"{filename}.json"))) ?? throw new Exception($"Failed to load data file '{filename}'.");
	}
	
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
		// TODO: SelectSavefileForNewGame();
	}

	public static void CreateGameObjects()
	{
		
	}
	
}