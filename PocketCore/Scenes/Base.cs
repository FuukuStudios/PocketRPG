using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PocketCore.Graphics;

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
    
    public List<Sprite> Children = [];

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
	    foreach (var child in Children)
		    child.Update();
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
	    foreach (var child in Children)
		    child.Draw(spriteBatch);
    }

    public virtual void Stop() => Active = false;

    public virtual void Terminate() {}

    public static void ScaleSprite(Sprite sprite)
    {
	    var scale = Math.Max(1f, Math.Max(PocketGraphics.Width / sprite.Bitmap.Width, PocketGraphics.Height / sprite.Bitmap.Height));
	    sprite.Scale = new Vector2(scale, scale);
    }

    public static void CenterSprite(Sprite sprite)
    {
	    sprite.Position = new Vector2(PocketGraphics.Width / 2f, PocketGraphics.Height / 2f);
	    sprite.Origin = new Vector2(sprite.Width / 2f, sprite.Height / 2f);
    }
}