using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoMSDF;
using CGame = PocketCore.Objects.Game;

namespace PocketCore.Managers;

public class FontManager
{
	private readonly MSDFTextRenderer _textRenderer;
	private PocketGame Game { get; }
	private readonly Matrix _projectionMatrix;
	
	public FontManager(PocketGame game)
	{
		Game = game;
		_textRenderer = new MSDFTextRenderer(Game.GraphicsDevice, Game.Content);

		// Create the projection matrix once (as per README)
		_projectionMatrix = Matrix.CreateOrthographicOffCenter(0,
			Game.GraphicsDevice.Viewport.Width,
			Game.GraphicsDevice.Viewport.Height,
			0, -1f, 1f);
	}

    public void LoadContent()
    {
        // Load the main font atlas defined in RMMZ's System.json
        // This assumes your "msdf-atlas-gen" output is in "Content/fonts/msdf/"
        // and the filenames match the font name (e.g., "MPlus1p-Regular.json")
        var fontName = CGame.System.MainFontFace; 
        
        var arr = fontName.Split('.');
        var noExt = arr.Length > 1 ? string.Join("", arr[..^1]) : fontName;
        
        // You'll need to adjust this path based on where you store your atlases
        var atlasJsonPath = Path.Combine("fonts", $"{noExt}.json");
        var atlasPngPath = Path.Combine("fonts", $"{noExt}.png");

        try
        {
            _textRenderer.LoadAtlas(atlasJsonPath, atlasPngPath);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"FATAL: Could not load main font atlas '{fontName}'. Check paths. {ex.Message}");
            // You might want to load a known-good fallback font here
            throw;
        }
    }

    /// <summary>
    /// Queues text to be rendered at the end of the frame.
    /// </summary>
    public void QueueText(string text, Vector2 position, float size, Color color, Color strokeColor)
    {
        // Use the "quick and dirty" method from the README.
        // For static text (like "New Game", "Load Game"), you should
        // refactor to use GenerateGeometry/AddTextInstance for better performance.
        _textRenderer.OneShotText(text, position, size, color, strokeColor);
    }

    /// <summary>
    /// Renders all queued text for this frame.
    /// Called by PocketGame.cs after base.Draw()
    /// </summary>
    public void RenderText()
    {
        _textRenderer.RenderInstances(
            Matrix.Identity,       // View matrix
            _projectionMatrix,     // Projection matrix
            FontDrawType.StandardTextWithStroke // Enable outlines
        );
    }
    
    /// <summary>
    /// Measures a string.
    /// !!! WARNING: MonoMSDF README does not provide a MeasureString API.
    /// You will need to find the real method for this.
    /// This is a DUMMY implementation that will NOT align correctly.
    /// </summary>
    public static Vector2 MeasureString(string text, float size)
    {
	    // TODO: Find the real measurement API in MonoMSDF.
	    // This is a placeholder and will break alignment.
	    // A *very* rough guess:
	    return new Vector2(text.Length * size * 0.55f, size);
    }
}