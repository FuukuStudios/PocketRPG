using Microsoft.Xna.Framework.Input;

namespace PocketCore
{
    /// <summary>
    /// A static class that handles keyboard and gamepad input.
    /// It mimics the RPG Maker MZ Input class for easier translation.
    /// </summary>
    public static class Input
    {
        private static KeyboardState _previousKeyboardState;
        private static KeyboardState _currentKeyboardState;

        // TODO: Implement Gamepad logic similar to keyboard

        public static void Initialize()
        {
            _previousKeyboardState = Keyboard.GetState();
            _currentKeyboardState = Keyboard.GetState();
        }

        public static void Update()
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();
        }

        /// <summary>
        /// Checks if a key is currently being pressed down.
        /// </summary>
        public static bool IsPressed(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// Checks if a key was just pressed in the current frame.
        /// </summary>
        public static bool IsTriggered(Keys key)
        {
            return _currentKeyboardState.IsKeyDown(key) && !_previousKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// Checks if a key was just released in the current frame.
        /// </summary>
        public static bool IsReleased(Keys key)
        {
            return !_currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyDown(key);
        }

        // TODO: Add IsRepeated and IsLongPressed logic if needed, which requires tracking press duration.
    }
}