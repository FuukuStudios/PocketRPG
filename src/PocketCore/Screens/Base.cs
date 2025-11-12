using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using PocketCore.Managers;

namespace PocketCore.Screens;

public static partial class Screen
{
	public abstract class Base : GameScreen
	{
		protected new PocketGame Game => (PocketGame) base.Game;
		protected Core Core => Game.Core;

		private bool _startRan;
		
		public Base(PocketGame game) : base(game) {}

		public virtual void Start() {}

		public override void Update(GameTime gameTime)
		{
			if (!_startRan)
			{
				Console.WriteLine($"Starting screen '{GetType().Name}'");
				Start();
				_startRan = true;
			}
		}
		
		public override void Draw(GameTime gameTime) {}
	}
}