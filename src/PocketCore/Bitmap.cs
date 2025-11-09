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
	private string _path = string.Empty;
	
	private bool _isDisposed;
	private RenderTarget2D? _renderTarget;

	// --- Constructor ---

	/// <summary>
	///     Creates a blank Bitmap.
	/// </summary>
	public Bitmap(GraphicsDevice gd, int width = 0, int height = 0)
	{
		if (width <= 0 || height <= 0) return;
		
		// Create the render target (our "canvas")
		_renderTarget = new RenderTarget2D(
			gd,
			width,
			height,
			false, // No mipmaps needed generally
			SurfaceFormat.Color, // Standard format
			DepthFormat.None, // No depth buffer needed for 2D
			0,
			RenderTargetUsage.PreserveContents // Important for drawing onto it multiple times
		);
	}

	// --- Core Properties ---
	public Texture2D BaseTexture => _renderTarget;
	public int Width => _renderTarget.Width;
	public int Height => _renderTarget.Height;
	public Rectangle Bounds => _renderTarget.Bounds;

	// --- State Properties (Defaults match RMMZ reasonably) ---
	public bool Smooth { get; set; } = true; // Use linear filtering by default
	public float PaintOpacity { get; set; } = 1.0f; // MonoGame uses 0.0 to 1.0

	// --- Font Properties (Using FontStashSharp) ---
	// Consider injecting or statically holding the FontSystem
	public string FontFace { get; set; } = "sans-serif";
	public int FontSize { get; set; } = 26; // Default size, adjust as needed
	public bool FontBold { get; set; } = false; // FontStashSharp handles styles via font files/names
	public bool FontItalic { get; set; } = false; // FontStashSharp handles styles via font files/names
	public Color TextColor { get; set; } = Color.White;
	public Color OutlineColor { get; set; } = new(0, 0, 0, 128);
	public int OutlineAmount { get; set; } = 4; // FontStashSharp uses amount instead of width

	public static Bitmap Load(ContentManager contentManager, GraphicsDevice gd, string path)
	{
		var bitmap = new Bitmap(gd);
		bitmap._path = path;
		bitmap.Load(contentManager);
		return bitmap;
	}

	private void Load(ContentManager contentManager)
	{
		_renderTarget = contentManager.Load<RenderTarget2D>(_path);
	}

	// --- IDisposable Implementation ---
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this); // Prevent finalizer from running
	}

	protected virtual void Dispose(bool disposing)
	{
		if (_isDisposed) return;
		
		if (disposing) _renderTarget.Dispose();
		
		_isDisposed = true;
	}

	~Bitmap() => Dispose(false);
}