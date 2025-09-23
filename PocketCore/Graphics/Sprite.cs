using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PocketCore.Graphics;

/// <summary>
///     A basic display object.
///     This is the base for most visible elements in the game.
/// </summary>
public class Sprite(Bitmap bitmap)
{
    public Bitmap Bitmap { get; set; } = bitmap;
    public Vector2 Position { get; set; } = Vector2.Zero;
    public Vector2 Origin { get; set; } = Vector2.Zero;
    public Vector2 Scale { get; set; } = Vector2.One;
    public float Rotation { get; set; } = 0f;
    public Color Tone { get; set; } = Color.White;
    public float Opacity { get; set; } = 255f;
    public bool Visible { get; set; } = true;

    public Rectangle? SourceRect { get; set; }

    public float X
    {
        get => Position.X;
        set => Position = new Vector2(value, Position.Y);
    }

    public float Y
    {
        get => Position.Y;
        set => Position = new Vector2(Position.X, value);
    }

    public int Width => SourceRect?.Width ?? Bitmap?.Width ?? 0;
    public int Height => SourceRect?.Height ?? Bitmap?.Height ?? 0;

    public virtual void Update()
    {
        // To be implemented by subclasses
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        if (Visible && Opacity > 0 && Bitmap?.Texture != null)
            spriteBatch.Draw(
                Bitmap.Texture,
                Position,
                SourceRect,
                Tone * (Opacity / 255f),
                Rotation,
                Origin,
                Scale,
                SpriteEffects.None,
                0f
            );
    }
}