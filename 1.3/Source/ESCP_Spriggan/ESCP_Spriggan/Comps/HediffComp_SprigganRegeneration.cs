using Verse;
using RimWorld;
using System.Linq;

namespace ESCP_Spriggan
{
    class HediffComp_SprigganRegeneration : HediffComp
	{

		public int ticks = 0;

		public HediffCompProperties_SprigganRegeneration Props
		{
			get
			{
				return (HediffCompProperties_SprigganRegeneration)this.props;
			}
		}

		public override void CompPostTick(ref float severityAdjustment)
		{
			base.CompPostTick(ref severityAdjustment);
			Pawn pawn = base.Pawn;
			if (ticks >= Props.ticks)
			{
				if ((pawn.IsBurning() && Props.fireDisables) || pawn.Dead || !pawn.Spawned)
				{
					ticks = 0;
					return;
				}
				else
				{
					for (int i = 0; i != Props.baseNumber; i++)
					{
						Hediff hediff;
						if (!(from hd in pawn.health.hediffSet.hediffs
							  where hd.def.displayWound
							  select hd).TryRandomElement(out hediff))
						{
							return;
						}
						//check if part is missing
						if (pawn.health.hediffSet.PartIsMissing(hediff.Part) && Props.regenParts)
						{
							HealthUtility.Cure(hediff);
						}
						else
						{
							hediff.Severity -= Props.severity;
						}
					}
				}
				ticks = 0;
			}
			else ticks++;
		}
    }
}
