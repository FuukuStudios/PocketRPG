using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using FontStashSharp;
using PocketCore.Managers;

namespace PocketCore.Graphics
{
    /// <summary>
    /// A wrapper for MonoGame's Texture2D with extra drawing and manipulation
    /// capabilities.
    /// </summary>
    public class Bitmap : IDisposable
    {
        public RenderTarget2D Texture { get; private set; }
        private bool _disposed;

        public int Width => Texture?.Width ?? 0;
        public int Height => Texture?.Height ?? 0;
        public Rectangle Rect => new Rectangle(0, 0, Width, Height);

        public FontSystem FontFace { get; set; } = FontManager.Load("sans-serif");
        public int FontSize { get; set; } = 16;
        public Color TextColor { get; set; } = Color.White;
        public Color OutlineColor { get; set; } = new (0, 0, 0, 0.5f);
        public int OutlineWidth { get; set; } = 3;

        public Bitmap(int width, int height)
        {
            if (width > 0 && height > 0)
            {
                Texture = new RenderTarget2D(
                    PocketGraphics.GraphicsDevice,
                    width,
                    height,
                    false,
                    PocketGraphics.GraphicsDevice.PresentationParameters.BackBufferFormat,
                    DepthFormat.Depth24);
            }
        }
        
        public Bitmap(Texture2D texture)
        {
             // To make a regular Texture2D drawable, we copy it to a RenderTarget2D
            Texture = new RenderTarget2D(
                PocketGraphics.GraphicsDevice,
                texture.Width,
                texture.Height,
                false,
                PocketGraphics.GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);
                
            PocketGraphics.GraphicsDevice.SetRenderTarget(Texture);
            PocketGraphics.GraphicsDevice.Clear(Color.Transparent);
            PocketGraphics.SpriteBatch.Begin();
            PocketGraphics.SpriteBatch.Draw(texture, new Rectangle(0, 0, texture.Width, texture.Height), Color.White);
            PocketGraphics.SpriteBatch.End();
            PocketGraphics.GraphicsDevice.SetRenderTarget(null);
        }

        public void Clear()
        {
            PocketGraphics.GraphicsDevice.SetRenderTarget(Texture);
            PocketGraphics.GraphicsDevice.Clear(Color.Transparent);
            PocketGraphics.GraphicsDevice.SetRenderTarget(null);
        }

        public enum TextAlignment
        {
            Left,
            Center,
            Right
        }
        
        public void DrawText(string text, int x, int y, int maxWidth, int lineHeight, TextAlignment align)
        {
            if (string.IsNullOrEmpty(text)) return;

            PocketGraphics.GraphicsDevice.SetRenderTarget(Texture);
            PocketGraphics.SpriteBatch.Begin();

            var size = FontFace.GetFont(FontSize).MeasureString(text);
            var position = new Vector2
            {
                X = align switch
                {
                    TextAlignment.Center => x + (maxWidth - size.X) / 2,
                    TextAlignment.Right => x + (maxWidth - size.X),
                    _ => x,
                },
                Y = y + (lineHeight - size.Y) / 2
            };

            PocketGraphics.SpriteBatch.DrawString(FontFace.GetFont(FontSize), text, position, TextColor); //, effect: FontSystemEffect.Stroked, effectAmount: OutlineWidth);

            PocketGraphics.SpriteBatch.End();
            PocketGraphics.GraphicsDevice.SetRenderTarget(null);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Texture?.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
