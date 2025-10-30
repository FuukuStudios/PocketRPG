namespace PocketCore.Objects;

public partial class Game
{
	public class BattlerBase
	{
		public enum Traits
		{
			ElementRate = 11,
			DebuffRate = 12,
			StateRate = 13,
			StateResist = 14,
			Param = 21,
			XParam = 22,
			SParam = 23,
			AttackElement = 31,
			AttackState = 32,
			AttackSpeed = 33,
			AttackTimes = 34,
			AttackSkill = 35,
			StypeAdd = 41,
			StypeSeal = 42,
			SkillAdd = 43,
			SkillSeal = 44,
			EquipWtype = 51,
			EquipAtype = 52,
			EquipLock = 53,
			EquipSeal = 54,
			SlotType = 55,
			ActionPlus = 61,
			SpecialFlag = 62,
			CollapseType = 63,
			PartyAbility = 64
		}

		public enum FlagIds
		{
			AutoBattle = 0,
			Guard = 1,
			Substitute = 2,
			PreserveTp = 3
		}

		public enum Params
		{
			// Maximum Hit Points
			Mhp = 0,

			// Maximum Magic Points
			Mmp = 1,

			// ATtacK power
			Atk = 2,

			// DEFense power
			Def = 3,

			// Magic ATtack power
			Mat = 4,

			// Magic DeFense power
			Mdf = 5,

			// AGIlity
			Agi = 6,

			// LUcK
			Luk = 7
		}

		public enum ExtraParams
		{
			// HIT rate
			Hit = 0,

			// EVAsion rate
			Eva = 1,

			// CRItical rate
			Cri = 2,

			// Critical EVasion rate
			Cev = 3,

			// Magic EVasion rate
			Mev = 4,

			// Magic ReFlection rate
			Mrf = 5,

			// CouNTer attack rate
			Cnt = 6,

			// Hp ReGeneration rate
			Hrg = 7,

			// Mp ReGeneration rate
			Mrg = 8,

			// Tp ReGeneration rate
			Trg = 9
		}

		public enum SpecialParams
		{
			// TarGet Rate
			Tgr = 0,

			// GuaRD effect rate
			Grd = 1,

			// RECovery effect rate
			Rec = 2,

			// PHArmacology
			Pha = 3,

			// Mp Cost Rate
			Mcr = 4,

			// Tp Charge Rate
			Tcr = 5,

			// Physical Damage Rate
			Pdr = 6,

			// Magic Damage Rate
			Mdr = 7,

			// Floor Damage Rate
			Fdr = 8,

			// EXperience Rate
			Exr = 9
		}

		public enum CollapseType
		{
			Default = 0,
			Boss = 1,
			Instant = 2
		}
	}
}