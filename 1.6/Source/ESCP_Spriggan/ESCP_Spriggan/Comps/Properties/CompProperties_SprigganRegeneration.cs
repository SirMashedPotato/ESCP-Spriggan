using Verse;

namespace ESCP_Spriggan
{
    class CompProperties_SprigganRegeneration : CompProperties
	{
		public CompProperties_SprigganRegeneration()
		{
			this.compClass = typeof(Comp_SprigganRegeneration);
		}
		public float minPain = 0.8f;
		public float Severity = 1f;
		public HediffDef hediff = null;
	}
}