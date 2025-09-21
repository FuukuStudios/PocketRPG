using System;
using System.IO;
using FontStashSharp;
using FontStashSharp.RichText;

namespace PocketCore.Managers;

/// <summary>
/// A static class that handles font files.
/// </summary>
public static class FontManager
{
    public static FontSystem Load(string filename)
    {
        FontSystem fs = new();
        
        if (filename.EndsWith(".ttf") || filename.EndsWith(".otf"))
            filename = filename[..^4];
        var path = $@"Content\fonts\{filename}";
        
        try
        {
            if (File.Exists($"{path}.ttf"))
                fs.AddFont(File.ReadAllBytes($"{path}.ttf"));
            else if (File.Exists($"{path}.otf"))
                fs.AddFont(File.ReadAllBytes($"{path}.otf"));
            else
                throw new FileNotFoundException($"Could not find font with path {path}");
            return fs;
        }
        catch
        {
            throw new FileNotFoundException($"Could not find font with path {path}");
        }
    }
}