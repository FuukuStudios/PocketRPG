using System.Net.Mime;
using Microsoft.Xna.Framework;
using PocketCore.Scenes;

namespace PocketCore.Managers;

public class SceneManager : GameComponent
{
	private Scene.Base? _scene;
	private Scene.Base? _nextScene;
	private Scene.Base? _previousScene;
	private Type? _previousClass;

	private bool _exiting;

	public SceneManager(Game game) : base(game)
	{
		game.Services.AddService(this);
	}
	
	public void Run<TScene>() where TScene : Scene.Base, new()
	{
		try
		{
			// Goto
			_nextScene = new TScene();
			_nextScene.Game = Game;
			_scene?.Stop();
		} 
		catch (Exception ex)
		{
			Console.WriteLine($"Error running scene {typeof(TScene).Name}: {ex}"); // TODO: RMMZ's exception handling
		}
	}

	public override void Update(GameTime gameTime)
	{
		try
		{
			// TODO: Input update
			ChangeScene();
			UpdateScene();
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error during SceneManager update: {ex}"); // TODO: RMMZ's exception handling
		}
		
		base.Update(gameTime);
	}

	public void Draw(GameTime gameTime)
	{
		
	}

	public void ChangeScene()
	{
		if (!IsSceneChanging || IsCurrentSceneBusy) return;

		if (_scene != null)
		{
			_scene.Terminate();
			// OnSceneTerminate
			_previousScene = _scene;
			_previousClass = _scene.GetType();
		}
		
		_scene = _nextScene;
		_nextScene = null;
		 
		if (_scene != null)
		{
			_scene.Create();
			Graphics.StartLoading(); // OnSceneCreate
		}

		if (_exiting) Environment.Exit(0);
	}

	public void UpdateScene()
	{
		if (_scene == null) return;

		if (_scene.IsStarted)
		{
			if (Game.IsActive) _scene.Update();
		}
		else if (_scene.IsReady)
		{
			_previousScene = null; // OnBeforeSceneStart
			_scene.Start();
			Graphics.EndLoading(); // OnSceneStart
		}
	}
	
	public bool IsSceneChanging => _exiting || _nextScene != null;

	public bool IsCurrentSceneBusy => _scene?.IsBusy ?? false;

	public void GoTo<TScene>() where TScene : Scene.Base, new()
	{
		_nextScene = new TScene();
		_nextScene.Game = Game;
		_scene?.Stop();
	}
}