namespace PocketCore.Objects
{
    /// <summary>
    /// The game object class for system data, translated from rmmz_objects.js.
    /// </summary>
    public class Game_System
    {
        // --- From $dataSystem ---
        public string GameTitle { get; set; } = "PocketRPG";
        public string Title1Name { get; set; } = "Title1"; // Filename for the first background
        public string Title2Name { get; set; } = "Title2"; // Filename for the second background
        public bool OptDrawTitle { get; set; } = true;

        // In a real implementation, these would be loaded from System.json
        public Game_System()
        {
            // Default values
        }
    }
}