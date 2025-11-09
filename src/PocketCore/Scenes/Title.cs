using MonoGame.Extended.Graphics;

namespace PocketCore.Scenes;

public partial class Scene
{
	public class Title : Base
	{
		private Sprite? _background;
		private Sprite? _bgFrame;
		
		// >> Overrides <<
		public override void Create()
		{
			base.Create();
			CreateBackground();
		}

		public override void Start()
		{
			base.Start();
			// TODO: Scene stack
		}

		// >> Private Methods <<
		private void CreateBackground()
		{
			_background = new Sprite(ImageManager.LoadTitleBackground(Core.System.Title1Name));
			_bgFrame = new Sprite(ImageManager.LoadTitleFrame(Core.System.Title2Name));
			Children.Add(_background);
			Children.Add(_bgFrame);
		}
	}
}