using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PocketCore
{
    /// <summary>
    /// A static class that holds graphics-related singleton instances and properties.
    /// This acts as a service locator for graphics components, initialized by the main game project.
    /// </summary>
    public static class Graphics
    {
        public static GraphicsDevice GraphicsDevice { get; private set; }
        public static SpriteBatch SpriteBatch { get; private set; }
        public static GameWindow Window { get; private set; }

        /// <summary>
        /// The logical width of the game screen.
        /// </summary>
        public static int Width { get; set; } = 816;

        /// <summary>
        /// The logical height of the game screen.
        /// </summary>
        public static int Height { get; set; } = 624;

        /// <summary>
        /// The width of the UI area.
        /// </summary>
        public static int BoxWidth { get; set; } = 816;

        /// <summary>
        /// The height of the UI area.
        /// </summary>
        public static int BoxHeight { get; set; } = 624;

        public static void Initialize(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, GameWindow window)
        {
            GraphicsDevice = graphicsDevice;
            SpriteBatch = spriteBatch;
            Window = window;
        }
    }
}