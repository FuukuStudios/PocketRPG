using PocketCore.Managers;

namespace PocketCore.Scenes;

public partial class Scene
{
	public class Boot : Base
	{
		private bool _databaseLoaded;
		
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
				
			}

			// TODO: ResizeScreen();
			
			Game.Window.Title = Core.DataSystem.GameTitle;
		}

		// TODO: public override bool IsReady => base.IsReady && IsPlayerDataLoaded;
		
		// >> Unique Methods <<
		public static bool IsPlayerDataLoaded => DataManager.IsGlobalInfoLoaded && ConfigManager.IsLoaded;

		public void CheckPlayerLocation()
		{
			if (Core.DataSystem.StartMapId == 0) throw new Exception("Player's starting position is 0 (Which is invalid).");
		}
		
		// >> Private Methods <<
		
		private void LoadGameFonts()
		{
			var advanced = Core.DataSystem.Advanced;
			FontManager.Load("mainfont", advanced.MainFontFilename);
			FontManager.Load("numberfont", advanced.NumberFontFilename);
		}
	}
}