using Verse;
using RimWorld;

namespace ESCP_Spriggan
{
    class Comp_SprigganRegeneration : ThingComp
	{

		public CompProperties_SprigganRegeneration Props
		{
			get
			{
				return (CompProperties_SprigganRegeneration)this.props;
			}
		}

        public override void PostPostApplyDamage(DamageInfo dinfo, float totalDamageDealt)
        {
            base.PostPostApplyDamage(dinfo, totalDamageDealt);

            Pawn pawn = parent as Pawn;
            if (!pawn.Dead && pawn.Spawned && pawn.health.hediffSet.PainTotal >= Props.minPain && !pawn.health.hediffSet.HasHediff(Props.hediff))
            {
                pawn.health.AddHediff(Props.hediff).Severity = Props.Severity;
            }
        }
    }
}