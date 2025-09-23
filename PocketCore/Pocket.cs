using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace PocketCore;

public static class Pocket
{
    public static Data.System DataSystem { get; private set; }
    
    public static void LoadDatabase()
    {
        DataSystem = JsonSerializer.Deserialize<Data.System>(File.ReadAllText(@"Content\data\System.json"));
        Debug.WriteLine($"Game Title: {DataSystem.gameTitle}");
    }
}