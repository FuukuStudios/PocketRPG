using PocketCore.Managers;

namespace PocketCore.Scenes;

public partial class Scene
{
	public class Splash : Base
	{
		// >> Overrides <<
		public override void Create()
		{
			base.Create();
			// if (Core.DataSystem.OptSplashScreen) CreateBackground();
		}
		
		// >> Unique Methods <<
	}
}