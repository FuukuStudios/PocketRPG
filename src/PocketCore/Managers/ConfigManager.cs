namespace PocketCore.Managers;

public static class ConfigManager
{
	public static bool AlwaysDash { get; set; }
	public static bool CommandRemember { get; set; }
	
	public static bool IsLoaded { get; private set; }
	
	// TODO: getters and setters for AudioManager volumes

	public static void Load()
	{
		// TODO: Load save config file
	}
}