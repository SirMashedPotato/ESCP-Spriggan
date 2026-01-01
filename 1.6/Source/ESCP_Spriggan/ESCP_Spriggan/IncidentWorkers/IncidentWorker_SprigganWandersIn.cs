using System.Collections.Generic;
using Verse;
using RimWorld;
using System.Linq;


namespace ESCP_Spriggan
{
    class IncidentWorker_SprigganWandersIn : IncidentWorker
	{
		protected override bool CanFireNowSub(IncidentParms parms)
		{
			Map map = (Map)parms.target;
			IntVec3 intVec;
			return this.TryFindEntryCell(map, out intVec);
		}

		protected override bool TryExecuteWorker(IncidentParms parms)
		{
			Map map = (Map)parms.target;
			IntVec3 intVec;
			if (!this.TryFindEntryCell(map, out intVec))
			{
				return false;
			}
			PawnKindDef spriggan = GetSprigganKind().RandomElement();
			int num = 1;
			IntVec3 invalid = IntVec3.Invalid;
			if (!RCellFinder.TryFindRandomCellOutsideColonyNearTheCenterOfTheMap(intVec, map, 10f, out invalid))
			{
				invalid = IntVec3.Invalid;
			}
			Pawn pawn = null;
			for (int i = 0; i < num; i++)
			{
				IntVec3 loc = CellFinder.RandomClosewalkCellNear(intVec, map, 10, null);
				pawn = PawnGenerator.GeneratePawn(spriggan, null);
				GenSpawn.Spawn(pawn, loc, map, Rot4.Random, WipeMode.Vanish, false);
				if (invalid.IsValid)
				{
					pawn.mindState.forcedGotoPosition = CellFinder.RandomClosewalkCellNear(invalid, map, 10, null);
				}
			}
			Find.LetterStack.ReceiveLetter("ESCP_AnimalWandersIn_Label".Translate(spriggan.label).CapitalizeFirst(), "ESCP_AnimalWandersIn_Description".Translate(spriggan.label), LetterDefOf.PositiveEvent, pawn, null, null);
			return true;
		}

		private bool TryFindEntryCell(Map map, out IntVec3 cell)
		{
			return RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f, false, null);
		}

		//get a random spriggan
		private List<PawnKindDef> GetSprigganKind()
		{
			return DefDatabase<PawnKindDef>.AllDefsListForReading.Where(x => x.race.tradeTags != null && x.race.tradeTags.Contains("ESCP_Spriggan")).ToList();
		}
	}
}
