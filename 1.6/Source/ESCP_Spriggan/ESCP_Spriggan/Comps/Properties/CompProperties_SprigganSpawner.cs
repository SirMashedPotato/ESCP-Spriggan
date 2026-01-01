using RimWorld;
using Verse;
using System;
using System.Collections.Generic;

namespace ESCP_Spriggan
{
    class CompProperties_SprigganSpawner : CompProperties
	{
		public CompProperties_SprigganSpawner()
		{
			this.compClass = typeof(Comp_SprigganSpawner);
		}

		public PawnKindDef pawnDef = null;
		public int timeRequired = 1800000;	//desired days * 60,000
	}
}
