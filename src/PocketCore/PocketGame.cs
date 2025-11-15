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
	private GraphicsDeviceManager _graphics;
	public SpriteBatch SpriteBatch { get; private set; }
	private readonly ScreenManager _screenManager;
	
	public Core Core { get; } = new();
	public FontManager FontManager { get; }

	public PocketGame()
	{
		_graphics = new GraphicsDeviceManager(this);
		FontManager = new FontManager(this);
		Content.RootDirectory = "Content"; // Routes to PocketContent
		IsMouseVisible = true;

		_graphics.PreferredBackBufferWidth = 816;
		_graphics.PreferredBackBufferHeight = 624;
		_graphics.ApplyChanges();
		
		_screenManager = new ScreenManager();
		Components.Add(_screenManager);
	}

	protected override void LoadContent()
	{
		SpriteBatch = new SpriteBatch(GraphicsDevice);
		
		Services.AddService(SpriteBatch);
		Services.AddService(Core);
		Services.AddService(FontManager);
		
		FontManager.LoadContent();

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

		FontManager.RenderText();
	}
	
	public void GoToScreen(Screen.Base screen)
	{
		// TODO: take advantage of new ReplaceScreen and CloseScreen methods
		_screenManager.ShowScreen(screen);
	}
}