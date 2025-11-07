using Microsoft.Xna.Framework;
using PocketCore.Managers;

namespace PocketCore.Scenes;

public partial class Scene
{
	public abstract class Base
	{
		protected Game Game { get; private set; } = null!;
		protected Core Core { get; private set; } = null!;
		protected FontManager FontManager { get; private set; }
		
		public bool IsStarted { get; private set; }
		
		private bool _active;
		private int _fadeSign;
		private int _fadeDuration;
		private int _fadeWhite;
		private int _fadeOpacity;

		public void Init(Game game)
		{
			Game = game;
			Core = game.Services.GetService<Core>();
			FontManager = game.Services.GetService<FontManager>();
		}
		
		// Virtual Methods
		/// <summary>
		/// Ran when the scene is first created.
		/// </summary>
		public virtual void Create() {}
		
		/// <summary>
		/// Ran once the scene is ready.
		/// </summary>
		public virtual void Start()
		{
			IsStarted = true;
			_active = true;
		}

		/// <summary>
		/// Ran by SceneManager every frame.
		/// Only for logic updates, not rendering.
		/// </summary>
		public virtual void Update() {}
	
		/// <summary>
		/// Ran when a new scene is being changed to.
		/// </summary>
		public virtual void Stop() => _active = false;
		
		/// <summary>
		///  Ran when the old scene is finished preparing to change.
		/// </summary>
		public virtual void Terminate() {}
		
		// Virtual Properties
		/// <summary>
		/// Returns whether the scene is ready to start.
		/// </summary>
		public virtual bool IsReady => true; // TODO: ImageManager.IsReady && EffectManager.IsReady && FontManager.IsReady
		
		/// <summary>
		/// Returns whether the scene is currently working.
		/// </summary>
		public bool IsBusy => _fadeDuration > 0;
	}
}