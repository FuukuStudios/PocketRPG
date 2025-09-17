
namespace PocketCore.Objects
{
    /// <summary>
    /// A static class that will manage the database objects, mimicking RMMZ's DataManager.
    /// For now, it just holds a reference to a single Game_System object.
    /// </summary>
    public static class DataManager
    {
        public static Game_System System { get; private set; }

        public static void LoadDatabase()
        {
            // In the future, this will load all JSON files (Actors, Classes, System, etc.)
            // For now, we just create a default system object.
            System = new Game_System();
        }
    }
}