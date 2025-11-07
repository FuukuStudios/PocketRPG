namespace PocketCore.Objects;

public partial class Game
{
	public class Actor : Battler
	{
		public int ActorId { get; private set; }
		// Use null-forgiving operator because these will be set in Setup method
		public string Name { get; private set; } = null!;
		public string Nickname { get; set; } = null!;
		public string Profile { get; set; } = null!;

		private int _classId;
		private int _level;
		
		public Actor(int actorId)
		{
			Setup(actorId);
		}

		public void Setup(int actorId)
		{
			// TODO:
			// var actor = Core.DataActors[actorId]!;
			// ActorId = actorId;
			// Name = actor.Name;
			// Nickname = actor.Nickname;
			// Profile = actor.Profile;
			// _classId = actor.ClassId;
			// _level = actor.InitialLevel;
			// TODO: the rest
		}
	}
}