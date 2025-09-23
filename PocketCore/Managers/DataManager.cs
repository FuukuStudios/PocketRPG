using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace PocketCore.Managers;

/// <summary>
///     A static class that will manage the database objects, mimicking RMMZ's DataManager.
///     For now, it just holds a reference to a single Game_System object.
/// </summary>
public static class DataManager
{
    public static void LoadDatabase()
    {
        Pocket.LoadDatabase();
    }
}