using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PocketCore;
using PocketCore.Managers;
using PocketCore.Scenes;

namespace PocketDesktopGL;

public class PocketGame : Game
{
	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;
	
	private readonly Core _core = new ();
	private readonly SceneManager _sceneManager;
	private readonly ImageManager _imageManager;
	private readonly FontManager _fontManager = new ();

	public PocketGame()
	{
		_graphics = new GraphicsDeviceManager(this);
		Content.RootDirectory = "Content"; // Routes to PocketContent
		IsMouseVisible = true;
		
		_sceneManager = new SceneManager(this);
		Components.Add(_sceneManager);
		_imageManager = new ImageManager(Content, GraphicsDevice);
	}

	protected override void Initialize()
	{
		base.Initialize();
	}

	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);
		
		Services.AddService(_core);
		Services.AddService(_sceneManager);
		Services.AddService(_imageManager);
		Services.AddService(_fontManager);
		
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