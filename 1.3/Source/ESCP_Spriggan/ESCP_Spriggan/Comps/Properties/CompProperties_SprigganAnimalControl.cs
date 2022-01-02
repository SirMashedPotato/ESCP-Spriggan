using Verse;

namespace ESCP_Spriggan
{
    class CompProperties_SprigganAnimalControl : CompProperties
	{
		public CompProperties_SprigganAnimalControl()
		{
			this.compClass = typeof(Comp_SprigganAnimalControl);
		}
		public float maxRange = 10f;
		public int maxNumberControlled = 1;
		public float chance = 1f;
		public FleckDef fleckDef;
		public SoundDef soundDef;
	}
}