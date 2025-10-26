using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PocketCore;

public class Bitmap : IDisposable
{
    private Texture2D? _texture;
    private RenderTarget2D? _renderTarget; // Used only if dynamically created/drawn onto

    public string Path { get; private set; } = ""; // Path used for loading
    private LoadingState _loadingState = LoadingState.None;
    private bool _isDisposed;

    // --- Font Properties ---
    public FontSystem FontFace { get; set; } // Default
    public int FontSize { get; set; } = 16;      // Default
    public bool FontBold { get; set; } = false;
    public bool FontItalic { get; set; } = false;
    public Color TextColor { get; set; } = Color.White;
    public Color OutlineColor { get; set; } = new Color(0f, 0f, 0f, 0.5f);
    public int OutlineWidth { get; set; } = 3;

    // --- Loading State Enum ---
    private enum LoadingState
    {
        None,
        Loading,
        Loaded,
        Error
    }

    public enum TextAlignment
    {
	    Left,
	    Center,
	    Right
    }

    // --- Constructor for dynamic Bitmaps ---
    /// <summary>
    /// Creates a new, blank Bitmap that can be drawn onto.
    /// Requires GraphicsDevice access.
    /// </summary>
    public Bitmap(int width, int height)
    {
	    _loadingState = LoadingState.None;
	    
	    // ArgumentNullException.ThrowIfNull(graphicsDevice);
        if (width <= 0 || height <= 0)
	        throw new ArgumentOutOfRangeException(width <= 0 ? nameof(width) : nameof(height), "Width and height must be positive.");

        // Create a RenderTarget to allow drawing
        _renderTarget = new RenderTarget2D(
            Graphics.GraphicsDevice,
            width,
            height,
            false,						// No mipmap
            SurfaceFormat.Color,				// Default format
            DepthFormat.None,					// No depth buffer needed usually
            0,			// No multisampling
            RenderTargetUsage.PreserveContents	// Important for drawing over time
        );

        _texture = _renderTarget; // The RenderTarget itself can be used as a Texture2D
    }

    // --- Private constructor for loaded Bitmaps ---
    private Bitmap()
    {
        // Used internally by Load method
    }

    // --- Static Load method (Mimics Bitmap.load) ---
    /// <summary>
    /// Asynchronously loads a Bitmap from the Content pipeline.
    /// Requires ContentManager access.
    /// </summary>
    public static Bitmap Load(ContentManager content, string path)
    {
        var bitmap = new Bitmap();
        bitmap.Path = path;
		
        // v StartLoading merge v
        bitmap._loadingState = LoadingState.Loading;
        try
        {
            // Assuming 'path' is the asset name without extension (e.g., "img/system/Window")
            bitmap._texture = content.Load<Texture2D>(path);
            bitmap._loadingState = LoadingState.Loaded;
            
            // TODO: Add load listeners logic if needed here or manage externally
        }
        catch (Exception ex) // < OnError merge
        {
            bitmap._loadingState = LoadingState.Error;
            Console.WriteLine($"Error loading Bitmap '{path}': {ex.Message}");
        }
        return bitmap;
    }

    // --- Properties ---
    public int Width => _texture?.Width ?? 0;
    public int Height => _texture?.Height ?? 0;
    public Rectangle Rect => new Rectangle(0, 0, Width, Height);
    public bool IsReady() => _loadingState == LoadingState.Loaded;
    public bool IsError() => _loadingState == LoadingState.Error;

    /// <summary>
    /// Provides access to the underlying MonoGame Texture2D for drawing.
    /// </summary>
    public Texture2D? Texture => _texture;

    // --- Drawing Methods (Require GraphicsDevice & SpriteBatch) ---
    // These need to be called within a Begin/End block, potentially using the internal RenderTarget

    // /// <summary>
    // /// Clears the entire Bitmap (only works if created dynamically with width/height).
    // /// </summary>
    // public void Clear(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    // {
    //     if (_renderTarget != null && !_isDisposed)
    //     {
    //         ClearRenderTarget(graphicsDevice, Color.Transparent);
    //          _isRenderTargetDirty = true;
    //     }
    // }
    //
    // /// <summary>
    // /// Fills a rectangle on the Bitmap (only works if created dynamically).
    // /// </summary>
    // public void FillRect(Rectangle rect, Color color)
    // {
	   //  if (_renderTarget == null || _isDisposed) return;
	   //  
    //      // 1. Set RenderTarget
    //      Graphics.GraphicsDevice.SetRenderTarget(_renderTarget);
    //
    //      // 2. Begin SpriteBatch (consider blend state for opacity)
    //      Graphics.SpriteBatch.Begin();
    //
    //      // 3. Draw a filled rectangle (using a 1x1 white texture is common)
    //      Texture2D pixel = GetPixelTexture(Graphics.GraphicsDevice); // Helper to get/create 1x1 white texture
    //      Color finalColor = color * (PaintOpacity / 255f);
    //      Graphics.SpriteBatch.Draw(pixel, rect, finalColor);
    //
    //      // 4. End SpriteBatch
    //      Graphics.SpriteBatch.End();
    //
    //      // 5. Reset RenderTarget
    //      Graphics.GraphicsDevice.SetRenderTarget(null);
    //      _isRenderTargetDirty = true;
    // }

    /// <summary>
    /// Draws text onto the Bitmap (only works if created dynamically).
    /// Needs access to SpriteFont.
    /// </summary>
    public void DrawText(string text, int x, int y, int maxWidth, int lineHeight, TextAlignment align)
    {
	    if (string.IsNullOrEmpty(text)) return;

	    if (FontFace == null)
		    throw new Exception("Font has not been set for this bitmap.");

	    Graphics.GraphicsDevice.SetRenderTarget(_renderTarget);
	    Graphics.SpriteBatch.Begin();

	    var font = FontFace.GetFont(FontSize);
	    if (font == null)
		    throw new Exception($"Font could not be loaded for size {FontSize}");

	    var size = font.MeasureString(text);
	    var position = new Vector2
	    {
		    X = align switch
		    {
			    TextAlignment.Center => x + (maxWidth - size.X) / 2,
			    TextAlignment.Right => x + (maxWidth - size.X),
			    _ => x
		    },
		    Y = y + (lineHeight - size.Y) / 2
	    };

	    Graphics.SpriteBatch.DrawString(font, text, position, TextColor); //, effect: FontSystemEffect.Stroked, effectAmount: OutlineWidth);

	    Graphics.SpriteBatch.End();
	    Graphics.GraphicsDevice.SetRenderTarget(null);
    }

    // /// <summary>
    // /// Performs a block transfer (Draws a source Bitmap/Texture onto this one).
    // /// Only works if this Bitmap was created dynamically.
    // /// </summary>
    // public void Blt(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Bitmap sourceBitmap, Rectangle sourceRect, Rectangle destRect)
    // {
    //      Blt(graphicsDevice, spriteBatch, sourceBitmap.Texture, sourceRect, destRect);
    // }
    //
    // public void Blt(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Texture2D sourceTexture, Rectangle sourceRect, Rectangle destRect)
    // {
    //     if (_renderTarget != null && !_isDisposed && sourceTexture != null)
    //     {
    //          graphicsDevice.SetRenderTarget(_renderTarget);
    //          // Consider BlendState based on PaintOpacity? Or source alpha?
    //          spriteBatch.Begin();
    //
    //          spriteBatch.Draw(sourceTexture, destRect, sourceRect, Color.White * (PaintOpacity / 255f));
    //
    //          spriteBatch.End();
    //          graphicsDevice.SetRenderTarget(null);
    //          _isRenderTargetDirty = true;
    //     }
    // }
    //
    // // Add other drawing methods like ClearRect, StrokeRect, GradientFillRect, DrawCircle as needed...
    // // They will follow the pattern: SetRenderTarget, Begin, Draw operations, End, ResetRenderTarget.
    //
    // // --- Helper Methods ---
    // private void ClearRenderTarget(GraphicsDevice graphicsDevice, Color color)
    // {
    //      if (_renderTarget != null && !_isDisposed)
    //      {
    //          graphicsDevice.SetRenderTarget(_renderTarget);
    //          graphicsDevice.Clear(color);
    //          graphicsDevice.SetRenderTarget(null);
    //      }
    // }
    //
    // // Helper to get a 1x1 white texture for drawing solid colors
    // private static Texture2D _pixelTexture;
    // private static Texture2D GetPixelTexture(GraphicsDevice graphicsDevice)
    // {
    //      if (_pixelTexture == null || _pixelTexture.IsDisposed)
    //      {
    //          _pixelTexture = new Texture2D(graphicsDevice, 1, 1);
    //          _pixelTexture.SetData(new[] { Color.White });
    //      }
    //      return _pixelTexture;
    // }


    // --- IDisposable Implementation ---
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {
                // Dispose managed resources
                // If the texture *is* the rendertarget, disposing RT disposes texture
                _renderTarget?.Dispose();
                // If texture was loaded from Content, ContentManager handles disposal.
                // If texture was created manually AND is not the RT, dispose it:
                // if (_texture != _renderTarget) _texture?.Dispose();

                // For simplicity, assume RT handles texture or ContentManager handles texture.
            }
            // Dispose unmanaged resources if any

            _texture = null;
            _renderTarget = null;
            _loadingState = LoadingState.None;
            _isDisposed = true;
        }
    }

    // --- Finalizer (optional, good practice) ---
     ~Bitmap()
     {
         Dispose(false);
     }
}