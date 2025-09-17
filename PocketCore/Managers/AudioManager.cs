using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Content;

namespace PocketCore.Managers
{
    /// <summary>
    /// Manages loading and playing audio by directly loading from files,
    /// allowing for dynamic, user-provided assets.
    /// </summary>
    public static class AudioManager
    {
        private static ContentManager _content;
        private static Dictionary<string, SoundEffect> _seCache = new Dictionary<string, SoundEffect>();

        public static void Initialize(ContentManager content)
        {
            _content = content;
        }
        // TODO: Add BGM/ME/BGS handling with Song class

        public static void PlaySe(string filename)
        {
            if (string.IsNullOrEmpty(filename)) return;

            string assetName = $"audio/se/{filename}";

            if (!_seCache.TryGetValue(assetName, out var soundEffect))
            {
                try
                {
                    soundEffect = _content.Load<SoundEffect>(assetName); // We need to add _content to AudioManager
                    _seCache[assetName] = soundEffect;
                }
                catch (System.Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Failed to load sound effect: {assetName} - {ex.Message}");
                    return;
                }
            }

            soundEffect.Play();
        }

        public static void Clear()
        {
            foreach (var sfx in _seCache.Values)
            {
                sfx.Dispose();
            }

            _seCache.Clear();
        }
    }
}