using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace PocketCore.Graphics
{
    /// <summary>
    /// A wrapper for MonoGame's Texture2D with extra drawing and manipulation
    /// capabilities.
    /// </summary>
    public class Bitmap : IDisposable
    {
        public RenderTarget2D Texture { get; private set; }
        private bool _disposed = false;

        public int Width => Texture?.Width ?? 0;
        public int Height => Texture?.Height ?? 0;
        public Rectangle Rect => new Rectangle(0, 0, Width, Height);

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

        public void DrawText(string text, int x, int y, int maxWidth, int lineHeight, string align, SpriteFont font, Color color)
        {
            if (string.IsNullOrEmpty(text)) return;

            PocketGraphics.GraphicsDevice.SetRenderTarget(Texture);
            PocketGraphics.SpriteBatch.Begin();

            Vector2 size = font.MeasureString(text);
            Vector2 position = new Vector2(x, y);

            if (align == "center")
            {
                position.X = x + (maxWidth - size.X) / 2;
            }
            else if (align == "right")
            {
                position.X = x + (maxWidth - size.X);
            }
            
            // Basic vertical alignment
            position.Y += (lineHeight - size.Y) / 2;

            PocketGraphics.SpriteBatch.DrawString(font, text, position, color);

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
