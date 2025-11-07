namespace PocketCore.Objects;

public partial class Game
{
	public class Action
	{
		public enum Effect
		{
			Escape = 0,
			RecoverHp = 11,
			RecoverMp = 12,
			GainTp = 13,
			AddState = 21,
			RemoveState = 22,
			AddBuff = 31,
			AddDebuff = 32,
			RemoveBuff = 33,
			RemoveDebuff = 34,
			Special = 41,
			Grow = 42,
			LearnSkill = 43,
			CommonEvent = 44
		}

		public enum HitType
		{
			Certain = 0,
			Physical = 1,
			Magical = 2,
		}

		private int _subjectActorId = 0;
		private int _subjectEnemyIndex = -1;
		private bool _forcing;

		public Action(BattlerBase subject, bool forcing = false)
		{
			_forcing = forcing;
			
			// Set subject
			if (subject is Actor actor)
			{
				_subjectActorId = actor.ActorId;
				_subjectEnemyIndex = -1;
			}
			else
			{
				// TODO: _subjectEnemyIndex = subject.Index;
			}
		}
	}
}