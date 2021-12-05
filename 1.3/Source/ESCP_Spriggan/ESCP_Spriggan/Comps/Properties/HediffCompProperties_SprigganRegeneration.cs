using System;
using Verse;
using RimWorld;

namespace ESCP_Spriggan
{
	class HediffCompProperties_SprigganRegeneration : HediffCompProperties
	{
		public HediffCompProperties_SprigganRegeneration()
		{
			this.compClass = typeof(HediffComp_SprigganRegeneration);
		}
		public int ticks = 100;
		public float baseNumber = 3f;
		public float severity = 0.5f;
		public bool regenParts = false;

		public bool fireDisables = false;
	}
}
