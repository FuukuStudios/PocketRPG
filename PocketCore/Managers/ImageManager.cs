using System.Collections.Concurrent;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PocketCore.Graphics;

namespace PocketCore.Managers;

/// <summary>
///     A static class that manages loading and caching of image assets (Bitmaps).
/// </summary>
public static class ImageManager
{
    private static ContentManager _content;
    private static readonly ConcurrentDictionary<string, Bitmap> Cache = new();

    public static void Initialize(ContentManager content)
    {
        _content = content;
    }

    /// <summary>
    ///     Loads a generic content asset from the Content pipeline.
    ///     Ideal for compiled assets like SpriteFonts.
    /// </summary>
    public static T Load<T>(string assetName)
    {
        return _content.Load<T>(assetName);
    }

    public static Bitmap LoadSystem(string filename)
    {
        return LoadBitmap(Path.Combine("img", "system"), filename);
    }

    public static Bitmap LoadTitle1(string filename)
    {
        return LoadBitmap(Path.Combine("img", "titles1"), filename);
    }

    public static Bitmap LoadTitle2(string filename)
    {
        return LoadBitmap(Path.Combine("img", "titles2"), filename);
    }

    /// <summary>
    ///     Loads a Bitmap using the Content Pipeline.
    ///     Assumes the asset has been added to Content.mgcb and compiled.
    /// </summary>
    private static Bitmap LoadBitmap(string folder, string filename)
    {
        // split parameters so we can use the methods above without breaking the game with empty filenames
        return !string.IsNullOrWhiteSpace(filename)
            ? Cache.GetOrAdd(Path.Combine(folder, filename), key => new Bitmap(_content.Load<Texture2D>(key)))
            : new Bitmap(1, 1);
    }

    public static void Clear()
    {
        foreach (var bitmap in Cache.Values) bitmap.Dispose();

        Cache.Clear();
    }
}