using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PocketCore.Scenes;

/// <summary>
///     The base class for all scenes in the game.
/// </summary>
public abstract class Base
{
    public bool Started { get; private set; }
    public bool Active { get; private set; }
    private int FadeSign = 0;
    private int FadeDuration = 0;
    private int FadeWhite = 0;
    private int FadeOpacity = 0;

    public virtual void Create()
    {
        Debug.WriteLine($"Create Scene: {GetType().Name}");
    }

    public virtual bool IsReady() => true; // TODO

    public virtual void Start()
    {
        Debug.WriteLine($"Start Scene: {GetType().Name}");
        Started = true;
        Active = true;
    }

    public virtual void Update(GameTime gameTime)
    {
    }

    public virtual void Stop() => Active = false;

    public virtual void Terminate() {}

    public virtual void Draw(SpriteBatch spriteBatch)
    {
    }
}