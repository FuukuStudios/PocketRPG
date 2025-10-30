using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PocketCore.Managers;
using PocketCore.Scenes;

namespace PocketDesktopGL;

public class PocketGame : Game
{
	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;
	
	private FontSystem _fontSystem; // TODO: optimize usage
	private readonly SceneManager _sceneManager;

	public PocketGame()
	{
		_graphics = new GraphicsDeviceManager(this);
		Content.RootDirectory = "Content"; // Routes to PocketContent
		IsMouseVisible = true;
		
		_sceneManager = new SceneManager(this);
		Components.Add(_sceneManager);
	}

	protected override void Initialize()
	{
		base.Initialize();
	}

	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);
		_fontSystem = new FontSystem();
		
		_sceneManager.Run<Scene.Boot>();
	}

	protected override void Update(GameTime gameTime)
	{
		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.Black);

		base.Draw(gameTime);
	}
}