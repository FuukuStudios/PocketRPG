using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PocketCore.Graphics;
using System.Collections.Generic;
using System.IO;

namespace PocketCore.Managers
{
    /// <summary>
    /// A static class that manages loading and caching of image assets (Bitmaps).
    /// </summary>
    public static class ImageManager
    {
        private static ContentManager _content;
        private static Dictionary<string, Bitmap> _cache = new Dictionary<string, Bitmap>();

        public static void Initialize(ContentManager content)
        {
            _content = content;
        }

        /// <summary>
        /// Loads a generic content asset from the Content pipeline.
        /// Ideal for compiled assets like SpriteFonts.
        /// </summary>
        public static T Load<T>(string assetName)
        {
            return _content.Load<T>(assetName);
        }

        public static Bitmap LoadSystem(string filename)
        {
            return LoadBitmap($"img/system/{filename}");
        }

        public static Bitmap LoadTitle(string filename)
        {
            return LoadBitmap($"img/titles1/{filename}");
        }

        /// <summary>
        /// Loads a Bitmap using the Content Pipeline.
        /// Assumes the asset has been added to Content.mgcb and compiled.
        /// </summary>
        private static Bitmap LoadBitmap(string assetName)
        {
            if (_cache.TryGetValue(assetName, out var bitmap))
            {
                return bitmap;
            }

            try
            {
                var texture = _content.Load<Texture2D>(assetName);
                var newBitmap = new Bitmap(texture);
                _cache[assetName] = newBitmap;
                return newBitmap;
            }
            catch (ContentLoadException ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to load texture: {assetName} - {ex.Message}");
                // Return an empty bitmap if file not found or error occurs
                return new Bitmap(1, 1);
            }
        }

        public static Bitmap LoadTitle1(string filename)
        {
            return LoadBitmap($"img/titles1/{filename}");
        }

        public static Bitmap LoadTitle2(string filename)
        {
            return LoadBitmap($"img/titles2/{filename}");
        }

        public static void Clear()
        {
            foreach (var bitmap in _cache.Values)
            {
                bitmap.Dispose();
            }

            _cache.Clear();
        }
    }
}