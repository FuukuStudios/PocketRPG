namespace PocketCore.Objects;

public partial class Game
{
	public class Battler : BattlerBase
	{
		public enum EffectType
		{
			Appear,
			Disappear,
			Whiten,
			Blink,
			Collapse,
			BossCollapse,
			InstantCollapse
		}
		
		public enum MotionType
		{
			Walk,
			Wait,
			Chant,
			Guard,
			Damage,
			Evade,
			Thrust,
			Swing,
			Missile,
			Skill,
			Spell,
			Item,
			Escape,
			Victory,
			Dying,
			Abnormal,
			Sleep,
			Dead
		}

		public enum ActionState
		{
			Undecided,
			Inputting,
			Waiting,
			Acting
		}
	}
}