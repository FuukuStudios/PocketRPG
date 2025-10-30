using Microsoft.Xna.Framework;

namespace PocketCore.Scenes;

public partial class Scene
{
	public class Base
	{
		public Game Game { get; set; } = null!;
		
		public bool IsStarted { get; private set; }
		private bool _active;
		private int _fadeSign;
		private int _fadeDuration;
		private int _fadeWhite;
		private int _fadeOpacity;
		
		public virtual void Create() {}
		
		public virtual void Start()
		{
			IsStarted = true;
			_active = true;
		}

		public virtual void Update() {}
	
		public void Stop() => _active = false;
		
		public virtual bool IsReady => true; // TODO: ImageManager.IsReady && EffectManager.IsReady && FontManager.IsReady
		
		public bool IsBusy => _fadeDuration > 0;
		
		public virtual void Terminate() {}
	}
}