using RimWorld;
using Verse;
using System;
using System.Collections.Generic;

namespace ESCP_Spriggan
{
    class CompProperties_SpawnSprigganOnChop : CompProperties
    {
		public CompProperties_SpawnSprigganOnChop()
		{
			this.compClass = typeof(Comp_SpawnSprigganOnChop);
		}

		public List<Overrides> overrideList;	/* currently only works for spawning angry spriggan */
	}

	public class Overrides
    {
		public string treeDefName = "";
		public string kindDefName = "";
		public bool overrideChance = false;
		public float overriddenChance = 1f;
    }
}
