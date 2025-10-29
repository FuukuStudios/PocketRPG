using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace PocketCore;

public enum TextAlign
{
	Left,
	Center,
	Right
}

public class Bitmap : IDisposable
{
	private readonly GraphicsDevice _graphicsDevice;
	private bool _isDisposed;
	private RenderTarget2D _renderTarget;

	// --- Constructor ---

	/// <summary>
	///     Creates a blank Bitmap.
	/// </summary>
	public Bitmap(GraphicsDevice graphicsDevice, int width, int height, FontSystem? fontSystem = null)
	{
		ArgumentNullException.ThrowIfNull(graphicsDevice);
		ArgumentNullException.ThrowIfNull(fontSystem);

		if (width <= 0) width = 1;
		if (height <= 0) height = 1;

		_graphicsDevice = graphicsDevice;
		FontSystem = fontSystem;
		// Create the render target (our "canvas")
		_renderTarget = new RenderTarget2D(
			_graphicsDevice,
			width,
			height,
			false, // No mipmaps needed generally
			SurfaceFormat.Color, // Standard format
			DepthFormat.None, // No depth buffer needed for 2D
			0,
			RenderTargetUsage.PreserveContents // Important for drawing onto it multiple times
		);

		// Initialize with transparency
		Clear();
	}

	// --- Core Properties ---
	public Texture2D Texture => _renderTarget;
	public int Width => _renderTarget.Width;
	public int Height => _renderTarget.Height;
	public Rectangle Bounds => _renderTarget.Bounds;

	// --- State Properties (Defaults match RMMZ reasonably) ---
	public bool Smooth { get; set; } = true; // Use linear filtering by default
	public float PaintOpacity { get; set; } = 1.0f; // MonoGame uses 0.0 to 1.0

	// --- Font Properties (Using FontStashSharp) ---
	// Consider injecting or statically holding the FontSystem
	public FontSystem? FontSystem { get; set; }
	public int FontSize { get; set; } = 26; // Default size, adjust as needed
	public bool FontBold { get; set; } = false; // FontStashSharp handles styles via font files/names
	public bool FontItalic { get; set; } = false; // FontStashSharp handles styles via font files/names
	public Color TextColor { get; set; } = Color.White;
	public Color OutlineColor { get; set; } = new(0, 0, 0, 128);
	public int OutlineAmount { get; set; } = 4; // FontStashSharp uses amount instead of width

	// --- IDisposable Implementation ---

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this); // Prevent finalizer from running
	}

	// --- Static Load Method ---

	/// <summary>
	///     Loads a Bitmap from a texture file via ContentManager.
	///     Assumes the texture exists in the content pipeline.
	/// </summary>
	public static Bitmap Load(ContentManager content, GraphicsDevice graphicsDevice, FontSystem fontSystem,
		string assetPath)
	{
		if (string.IsNullOrEmpty(assetPath))
			throw new ArgumentNullException(nameof(assetPath));

		var texture = content.Load<Texture2D>(assetPath);

		// Create a new Bitmap RenderTarget and draw the loaded texture onto it
		var bitmap = new Bitmap(graphicsDevice, texture.Width, texture.Height, fontSystem);

		// Use a temporary SpriteBatch to draw the loaded texture
		using var spriteBatch = new SpriteBatch(graphicsDevice);

		graphicsDevice.SetRenderTarget(bitmap._renderTarget);
		graphicsDevice.Clear(Color.Transparent); // Start clean
		spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
		spriteBatch.Draw(texture, bitmap.Bounds, Color.White);
		spriteBatch.End();
		graphicsDevice.SetRenderTarget(null); // Reset render target

		// Note: The original texture loaded by ContentManager is managed by it.
		// We've copied its contents to our RenderTarget.
		return bitmap;
	}


	// --- Static Snap Method ---
	/// <summary>
	///     Creates a Bitmap by taking a snapshot of the current screen (back buffer).
	/// </summary>
	public static Bitmap Snap(GraphicsDevice graphicsDevice, FontSystem fontSystem)
	{
		// Get the current back buffer dimensions
		var pp = graphicsDevice.PresentationParameters;
		var width = pp.BackBufferWidth;
		var height = pp.BackBufferHeight;

		// Create a RenderTarget2D with the same dimensions and format
		// Note: PreserveContents might not be strictly necessary here if we only draw once,
		// but it's safer if the underlying usage changes.
		using var screenshotTarget = new RenderTarget2D(
			graphicsDevice,
			width,
			height,
			false, // mipMap
			pp.BackBufferFormat,
			pp.DepthStencilFormat,
			0, // preferredMultiSampleCount
			RenderTargetUsage.DiscardContents // Discard after reading pixels
		);

		// Resolve the back buffer to the render target
		// Note: This needs to happen *outside* a SpriteBatch Begin/End block
		// that targets the backbuffer itself. Usually called after drawing is complete for the frame.
		graphicsDevice.SetRenderTarget(screenshotTarget);
		// We don't need to clear or draw anything here, the back buffer's content is implicitly copied
		// when we switch *away* from a render target (or resolve it), but GetData is safer.

		// Reset render target to the back buffer (or null)
		graphicsDevice.SetRenderTarget(null);

		// Create a Texture2D to hold the data
		var screenshotTexture = new Texture2D(graphicsDevice, width, height);
		var data = new Color[width * height];
		screenshotTarget.GetData(data);
		screenshotTexture.SetData(data);


		// Now create a Bitmap and draw this texture onto it
		var bitmap = new Bitmap(graphicsDevice, width, height, fontSystem);
		using (var spriteBatch = new SpriteBatch(graphicsDevice))
		{
			graphicsDevice.SetRenderTarget(bitmap._renderTarget);
			graphicsDevice.Clear(Color.Transparent); // Should already be clear, but safety first
			spriteBatch.Begin();
			spriteBatch.Draw(screenshotTexture, Vector2.Zero, Color.White);
			spriteBatch.End();
			graphicsDevice.SetRenderTarget(null);
		}

		// Dispose the temporary texture since its data is now in the Bitmap's RenderTarget
		screenshotTexture.Dispose();

		return bitmap;
	}


	// --- Drawing Methods ---

	private void PrepareSpriteBatch(ref SpriteBatch? spriteBatch, out bool nullSpriteBatch)
	{
		nullSpriteBatch = spriteBatch == null;
		spriteBatch ??= new SpriteBatch(_graphicsDevice);

		// Set the render target
		_graphicsDevice.SetRenderTarget(_renderTarget);

		// Begin drawing
		spriteBatch.Begin(
			SpriteSortMode.Deferred,
			BlendState.AlphaBlend, // Standard alpha blending
			Smooth ? SamplerState.LinearClamp : SamplerState.PointClamp,
			DepthStencilState.None,
			RasterizerState.CullNone
		);
	}

	private void FinishSpriteBatch(SpriteBatch spriteBatch, bool ownSpriteBatch)
	{
		// End drawing
		spriteBatch.End();

		// Reset the render target
		_graphicsDevice.SetRenderTarget(null);

		if (ownSpriteBatch) spriteBatch.Dispose();
	}

	/// <summary>
	///     Clears the entire Bitmap to transparent.
	/// </summary>
	public void Clear(SpriteBatch? spriteBatch = null)
	{
		PrepareSpriteBatch(ref spriteBatch, out var nullSpriteBatch);

		// Use GraphicsDevice.Clear for efficiency
		_graphicsDevice.Clear(Color.Transparent);

		FinishSpriteBatch(spriteBatch!, nullSpriteBatch);
	}

	/// <summary>
	///     Clears a rectangular area to transparent.
	/// </summary>
	public void ClearRect(Rectangle rect, SpriteBatch? spriteBatch = null)
	{
		// Clamp rectangle to bitmap bounds
		rect = Rectangle.Intersect(rect, Bounds);
		if (rect.IsEmpty) return;

		PrepareSpriteBatch(ref spriteBatch, out var nullSpriteBatch);

		// Draw a transparent rectangle
		// Ensure you have a 1x1 white texture available (e.g., from MonoGame.Extended or create one)
		// Assuming TextureUtils.GetWhitePixel(spriteBatch) exists or similar helper
		spriteBatch.FillRectangle(rect, Color.Transparent * 0f); // Use FillRectangle from MG.Extended

		FinishSpriteBatch(spriteBatch!, nullSpriteBatch);
	}

	/// <summary>
	///     Fills the entire Bitmap with a color.
	/// </summary>
	public void FillAll(Color color, SpriteBatch? spriteBatch = null)
	{
		PrepareSpriteBatch(ref spriteBatch, out var nullSpriteBatch);

		_graphicsDevice.Clear(color * PaintOpacity); // Apply opacity here

		FinishSpriteBatch(spriteBatch!, nullSpriteBatch);
	}

	/// <summary>
	///     Fills a rectangle with a solid color.
	/// </summary>
	public void FillRect(Rectangle rect, Color color, SpriteBatch? spriteBatch = null)
	{
		// Clamp rectangle to bitmap bounds
		rect = Rectangle.Intersect(rect, Bounds);
		if (rect.IsEmpty) return;

		PrepareSpriteBatch(ref spriteBatch, out var ownSpriteBatch);

		spriteBatch.FillRectangle(rect, color * PaintOpacity); // MG.Extended

		FinishSpriteBatch(spriteBatch!, ownSpriteBatch);
	}

	/// <summary>
	///     Draws the outline of a rectangle.
	/// </summary>
	public void StrokeRect(Rectangle rect, Color color, int thickness = 1, SpriteBatch? spriteBatch = null)
	{
		// Clamp rectangle to bitmap bounds - adjust rect slightly if needed based on thickness?
		// For simplicity, we'll draw within the bounds. Clipping might occur.
		if (rect.Width <= 0 || rect.Height <= 0) return;

		PrepareSpriteBatch(ref spriteBatch, out var ownSpriteBatch);

		spriteBatch.DrawRectangle(rect, color * PaintOpacity, thickness); // MG.Extended

		FinishSpriteBatch(spriteBatch!, ownSpriteBatch);
	}

	/// <summary>
	///     Draws a circle outline.
	/// </summary>
	public void DrawCircle(Vector2 center, float radius, Color color, int thickness = 1, int sides = 32,
		SpriteBatch? spriteBatch = null)
	{
		// Consider bounds checking if necessary
		PrepareSpriteBatch(ref spriteBatch, out var ownSpriteBatch);

		spriteBatch.DrawCircle(center, radius, sides, color * PaintOpacity, thickness); // MG.Extended

		FinishSpriteBatch(spriteBatch!, ownSpriteBatch);
	}

	/// <summary>
	/// Fills a circle with a solid color. Requires some manual drawing or a filled circle primitive.
	/// Using MG.Extended.Shapes requires Begin/End. Let's use a simpler DrawCircle approach for now.
	/// To fill accurately, you'd need Texture2D.SetData or a shader.
	/// Alternatively, MonoGame.Extended.Shapes allows filling within its own Begin/End.
	/// Let's stick to outline for simplicity matching `drawCircle`. If fill is needed, MG.Extended.Shapes is better.
	/// </summary>
	public void FillCircle() => throw new NotImplementedException(); // TODO: Requires more setup or different library usage.

	/// <summary>
	///     Draws text onto the Bitmap. Uses FontStashSharp.
	/// </summary>
	public void DrawText(string text, float x, float y, float? maxWidth = null, Color? color = null,
		TextAlign align = TextAlign.Left, SpriteBatch? spriteBatch = null)
	{
		if (string.IsNullOrEmpty(text) || FontSystem == null) return;

		PrepareSpriteBatch(ref spriteBatch, out var ownSpriteBatch);

		var font = FontSystem.GetFont(FontSize); // Get font at the specified size
		var position = new Vector2(x, y);
		var drawColor = (color ?? TextColor) * PaintOpacity;

		// Handle alignment if maxWidth is provided
		if (maxWidth.HasValue)
		{
			var size = font.MeasureString(text);
			switch (align)
			{
				case TextAlign.Left:
					break;
				case TextAlign.Center:
					position.X += (maxWidth.Value - size.X) / 2f;
					break;
				case TextAlign.Right:
					position.X += maxWidth.Value - size.X;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(align), align, null);
			}
			
			// FontStashSharp doesn't have built-in maxWidth clipping for DrawString,
			// manual wrapping or clipping would be needed if text exceeds maxWidth.
		}


		// FontStashSharp DrawString for text with outline
		font.DrawText(
			spriteBatch,
			text,
			position,
			drawColor,
			// effect: FontSystemEffect.Stroked, // Use Stroked for outline
			// effectAmount: OutlineAmount,      // Outline thickness
			// strokeColor: OutlineColor * PaintOpacity, // Outline color with opacity
			// origin: Vector2.Zero,            // Top-left origin
			// scale: Vector2.One               // Normal scale
			// Newer FontStashSharp might use different parameters or SpriteFontBase directly
			effect: FontSystemEffect.Stroked,
			effectAmount: OutlineAmount,
			// TODO: effectColor: OutlineColor * PaintOpacity,
			scale: Vector2.One,
			rotation: 0f,
			origin: Vector2.Zero
		);

		FinishSpriteBatch(spriteBatch!, ownSpriteBatch);
	}

	/// <summary>
	///     Measures the width of the text. Uses FontStashSharp.
	/// </summary>
	public float MeasureTextWidth(string text)
	{
		if (string.IsNullOrEmpty(text) || FontSystem == null) return 0;

		var font = FontSystem.GetFont(FontSize);
		return font.MeasureString(text).X;
	}

	/// <summary>
	///     Performs a block transfer (blitting). Draws a portion of the source bitmap onto this bitmap.
	/// </summary>
	public void Blt(Bitmap source, Rectangle sourceRect, Rectangle destRect, Color? color = null,
		SpriteBatch? spriteBatch = null)
	{
		if (sourceRect.IsEmpty || destRect.IsEmpty) return;

		// Basic bounds check/clamping (can be more sophisticated)
		sourceRect = Rectangle.Intersect(sourceRect, source.Bounds);
		// We don't clamp destRect here, SpriteBatch handles drawing outside bounds

		if (sourceRect.IsEmpty) return;

		
		PrepareSpriteBatch(ref spriteBatch, out var ownSpriteBatch);

		spriteBatch!.Draw(
			source.Texture,
			destRect,
			sourceRect,
			(color ?? Color.White) * PaintOpacity // Apply color modulation and opacity
		);

		FinishSpriteBatch(spriteBatch, ownSpriteBatch);
	}

	/// <summary>
	///     Simplified Blt using destination coordinates directly.
	/// </summary>
	public void Blt(Bitmap source, Rectangle sourceRect, Vector2 destPosition, Color? color = null,
		SpriteBatch? spriteBatch = null)
	{
		Blt(source, sourceRect,
			new Rectangle((int)destPosition.X, (int)destPosition.Y, sourceRect.Width, sourceRect.Height), color,
			spriteBatch);
	}

	/// <summary>
	///     Gets the color of a pixel at the specified coordinates.
	///     NOTE: This can be slow! Avoid using it frequently in loops.
	/// </summary>
	public Color GetPixel(int x, int y)
	{
		if (_isDisposed || x < 0 || y < 0 || x >= Width || y >= Height)
			return Color.Transparent; // Or throw an exception

		var data = new Color[1];
		var sourceRect = new Rectangle(x, y, 1, 1);

		// GetData can be slow, especially on some platforms.
		// Consider alternative approaches if performance is critical.
		_renderTarget.GetData(0, sourceRect, data, 0, 1);

		return data[0];
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_isDisposed)
		{
			if (disposing)
				// Dispose managed resources
				_renderTarget.Dispose();

			// Dispose unmanaged resources (if any) - not typical here

			_isDisposed = true;
		}
	}

	~Bitmap() // Finalizer (optional, good practice with IDisposable)
	{
		Dispose(false);
	}
}