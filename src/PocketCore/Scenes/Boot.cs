using Microsoft.Xna.Framework;
using PocketCore.Managers;

namespace PocketCore.Scenes;

public partial class Scene
{
	public class Boot : Base
	{
		// >> Overrides <<
		public override void Create()
		{
			base.Create();
			// TODO: Load System Images
			// TODO: Load Player Data
			LoadGameFonts();
		}

		public override void Start()
		{
			base.Start();
			
			// TODO: Preload important sounds from SoundManager
			
			if (DataManager.IsBattleTest)
			{
				// TODO: Setup Battle Test Scene
			}
			else if (DataManager.IsEventTest)
			{
				// TODO: Setup Event Test Scene
			}
			else if (DataManager.IsTitleSkip)
			{
				// TODO: go to map instead
			}
			else
			{
				CheckPlayerLocation();
				// TODO: DataManager SetupNewGame();
				// PRIORITY: Process title command window
				SceneManager.GoTo<Title>();
			}

			// TODO: ResizeScreen();
			
			Game.Window.Title = Core.System.GameTitle;
		}

		// TODO: public override bool IsReady => base.IsReady && IsPlayerDataLoaded;
		
		// >> Unique Methods <<
		public static bool IsPlayerDataLoaded => DataManager.IsGlobalInfoLoaded && ConfigManager.IsLoaded;

		private void CheckPlayerLocation()
		{
			if (Core.System.StartMapId == 0) throw new Exception("Player's starting position is 0 (Which is invalid).");
		}
		
		// >> Private Methods <<
		
		private void LoadGameFonts()
		{
			var advanced = Core.System.Advanced;
			FontManager.Load("mainfont", advanced.MainFontFilename);
			FontManager.Load("numberfont", advanced.NumberFontFilename);
		}
	}
}