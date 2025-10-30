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
			
			DataManager.LoadDatabase();
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
			}

			// TODO: ResizeScreen();
			
			Game.Window.Title = Core.DataSystem.GameTitle;
		}

		public override bool IsReady
		{
			get
			{
				if (_databaseLoaded) return base.IsReady && IsPlayerDataLoaded;
				
				if (!DataManager.IsDatabaseLoaded) return false;

				_databaseLoaded = true;
				OnDatabaseLoaded();

				return false;
			}
		}
		
		// >> Unique Methods <<
		public static void OnDatabaseLoaded()
		{
			// TODO: Load System Images
			// ColorManager.LoadWindowskin();
			// ImageManager.LoadSystem("IconSet");
			
			// Load Player Data
			DataManager.LoadGlobalInfo();
			ConfigManager.Load();
			
			// TODO: Load Game Fonts
			// FontManager.Load("rmmz-mainfont", Core.DataSystem.Advanced.MainFontFilename);
			// FontManager.Load("rmmz-numberfont", Core.DataSystem.Advanced.NumberFontFilename);
		}
		
		public static bool IsPlayerDataLoaded => DataManager.IsGlobalInfoLoaded && ConfigManager.IsLoaded;

		public static void CheckPlayerLocation()
		{
			if (Core.DataSystem.StartMapId == 0) throw new Exception("Player's starting position is 0 (Which is invalid).");
		}
	}
}