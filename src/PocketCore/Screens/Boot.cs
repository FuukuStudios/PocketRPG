using Microsoft.Xna.Framework;
using PocketCore.Managers;

namespace PocketCore.Screens;

public partial class Screen
{
	public class Boot(PocketGame game) : Base(game)
	{
		// >> Overrides <<
		public override void Initialize()
		{
			base.Initialize();

			// TODO: ResizeScreen();
			
			Game.Window.Title = Core.DataSystem.GameTitle;
		}
		
		public override void LoadContent()
		{
			base.LoadContent();
			// TODO: Load System Images
			// TODO: Load Player Data
			LoadGameFonts();
		}

		public override void Start()
		{
			base.Start();
			
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
				Game.GoToScreen(new Title(Game));
			}
		}

		// TODO: public override bool IsReady => base.IsReady && IsPlayerDataLoaded;

		// >> Unique Methods <<
		public static bool IsPlayerDataLoaded => DataManager.IsGlobalInfoLoaded && ConfigManager.IsLoaded;

		private void CheckPlayerLocation()
		{
			if (Game.Core.DataSystem.StartMapId == 0) throw new Exception("Player's starting position is 0 (Which is invalid).");
		}
		
		// >> Private Methods <<
		private void LoadGameFonts()
		{
			var advanced = Core.DataSystem.Advanced;
			Game.FontManager.Load("rmmz-mainfont", advanced.MainFontFilename);
			Game.FontManager.Load("rmmz-numberfont", advanced.NumberFontFilename);
		}
	}
}