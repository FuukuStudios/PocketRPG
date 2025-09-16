using System;

namespace PocketCore
{
    /// <summary>
    /// A static class for general utility methods.
    /// </summary>
    public static class Utils
    {
        public const string APP_NAME = "PocketRPG";
        public const string APP_VERSION = "0.1.0-alpha";
        public const string MONOGAME_VERSION = "3.8.4";

        private static readonly Random _random = new Random();

        /// <summary>
        /// Generates a random integer from 0 to max-1.
        /// </summary>
        public static int RandomInt(int max)
        {
            if (max <= 0) return 0;
            return _random.Next(max);
        }
    }
}