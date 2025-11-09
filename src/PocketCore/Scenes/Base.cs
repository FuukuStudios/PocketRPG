using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PocketCore.Managers;

namespace PocketCore.Scenes;

public static partial class Scene
{
	public abstract class Base
	{
		internal  Game Game { get; set; } = null!;
		protected Core Core => Game.Services.GetService<Core>();
		protected SceneManager SceneManager => Game.Services.GetService<SceneManager>();
		protected ImageManager ImageManager => Game.Services.GetService<ImageManager>();
		protected FontManager FontManager => Game.Services.GetService<FontManager>();
		
		public bool IsStarted { get; private set; }
		public bool IsActive { get; private set; }
		public List<object> Children { get; protected set; } = [];
		
		private int _fadeSign;
		private int _fadeDuration;
		private int _fadeWhite;
		private int _fadeOpacity;
		
		// >> Virtual Methods <<
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
			IsActive = true;
		}

		/// <summary>
		/// Ran by SceneManager every frame.
		/// Only for logic updates, not rendering.
		/// </summary>
		public virtual void Update()
		{
			// PRIORITY: Update fade logic
			UpdateChildren();
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			DrawChildren(spriteBatch);
		}
	
		/// <summary>
		/// Ran when a new scene is being changed to.
		/// </summary>
		public virtual void Stop() => IsActive = false;
		
		/// <summary>
		///  Ran when the old scene is finished preparing to change.
		/// </summary>
		public virtual void Terminate() {}
		
		// >> Properties <<
		/// <summary>
		/// Returns whether the scene is ready to start.
		/// </summary>
		public virtual bool IsReady => true; // TODO: ImageManager.IsReady && EffectManager.IsReady && FontManager.IsReady
		
		/// <summary>
		/// Returns whether the scene is currently working.
		/// </summary>
		public bool IsBusy => _fadeDuration > 0;
		
		// >> Protected Methods <<
		protected void UpdateChildren()
		{
			foreach (var child in Children)
			{
				if (child is ISceneChild ichild) ichild.Update();
			}
		}
		
		protected void DrawChildren(SpriteBatch spriteBatch)
		{
			foreach (var child in Children)
			{
				if (child is ISceneChild ichild) ichild.Draw(spriteBatch);
			}
		}
	}
}