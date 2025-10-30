namespace PocketCore.Managers;

public static class StorageManager
{
	// TODO: load object

	public static void LoadObject(string saveName)
	{
		var zip = LoadZip(saveName);
		var json = ZipToJson(zip);
		return JsonToObject(json);
	}

	public static void LoadZip(string saveName)
	{
		
	}
}