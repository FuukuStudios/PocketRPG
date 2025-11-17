using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using PocketCore;
using PocketCore.Managers;
using PocketCore.Screens;
using Screen = PocketCore.Screens.Screen;

namespace PocketCore;

public class PocketGame : Game
{
	private GraphicsDeviceManager Graphics { get; }
	public SpriteBatch SpriteBatch { get; private set; } = null!;
	private readonly ScreenManager _screenManager;
	
	public Core Core { get; } = new();
	public FontManager FontManager { get; }

	public PocketGame()
	{
		Graphics = new GraphicsDeviceManager(this);
		Content.RootDirectory = "Content"; // Routes to PocketContent
		IsMouseVisible = true;

		Graphics.PreferredBackBufferWidth = 816;
		Graphics.PreferredBackBufferHeight = 624;
		Graphics.ApplyChanges();
		
		_screenManager = new ScreenManager();
		FontManager = new FontManager(this);
		Components.Add(_screenManager);
	}

	protected override void Initialize()
	{
		base.Initialize();
	}

	protected override void LoadContent()
	{
		SpriteBatch = new SpriteBatch(GraphicsDevice);
		
		Services.AddService(SpriteBatch);
		Services.AddService(Core);
		Services.AddService(FontManager);

		GoToScreen(new Screen.Boot(this));
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
	
	public void GoToScreen(Screen.Base screen)
	{
		_screenManager.ShowScreen(screen); // TODO: Implement MonoGame.Extended's new scene methods.
	}
}