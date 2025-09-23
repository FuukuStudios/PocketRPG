using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PocketCore.Scenes;

namespace PocketCore.Managers;

/// <summary>
///     A static class that manages scene transitions.
/// </summary>
public static class SceneManager
{
    private static Base _scene;
    private static Base _nextScene;

    public static void Update(GameTime gameTime)
    {
        if (_nextScene != null)
        {
            _scene?.Terminate();
            _scene = _nextScene;
            _nextScene = null;
            _scene.Create();
            _scene.Start();
        }

        _scene?.Update(gameTime);
    }

    public static void Draw(SpriteBatch spriteBatch)
    {
        _scene?.Draw(spriteBatch);
    }

    public static void GoTo(Base newScene)
    {
        Debug.WriteLine($"Go to Scene: {newScene.GetType().Name}");
        _nextScene = newScene;
    }
}