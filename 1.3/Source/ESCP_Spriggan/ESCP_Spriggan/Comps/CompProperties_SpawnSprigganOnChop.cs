using RimWorld;
using Verse;
using System;

namespace ESCP_Spriggan
{
    class CompProperties_SpawnSprigganOnChop : CompProperties
    {
		public CompProperties_SpawnSprigganOnChop()
		{
			this.compClass = typeof(Comp_SpawnSprigganOnChop);
		}
		public bool overrideChance = false;
		public float overriddenChance = 1f;
	}
}
