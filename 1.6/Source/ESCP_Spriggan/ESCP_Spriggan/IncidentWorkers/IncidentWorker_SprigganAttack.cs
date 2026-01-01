using System.Collections.Generic;
using Verse;
using RimWorld;

namespace ESCP_Spriggan
{
	public class IncidentWorker_SprigganAttack : IncidentWorker
	{
		protected override bool CanFireNowSub(IncidentParms parms)
		{
			if (!base.CanFireNowSub(parms))
			{
				return false;
			}
			Map map = (Map)parms.target;
            return AggressiveAnimalIncidentUtility.TryFindAggressiveAnimalKind(parms.points, map.Tile, out PawnKindDef pawnKindDef) && RCellFinder.TryFindRandomPawnEntryCell(out IntVec3 intVec, map, CellFinder.EdgeRoadChance_Animal, false, null);
        }

		protected override bool TryExecuteWorker(IncidentParms parms)
		{
			Map map = (Map)parms.target;
			PawnKindDef pawnKind = SprigganUtility.GetSprigganType(map);
			if (pawnKind == null || AggressiveAnimalIncidentUtility.GetAnimalsCount(pawnKind, parms.points) == 0)
			{
				return false;
			}
			IntVec3 spawnCenter = parms.spawnCenter;
			if (!spawnCenter.IsValid && !RCellFinder.TryFindRandomPawnEntryCell(out spawnCenter, map, CellFinder.EdgeRoadChance_Animal, false, null))
			{
				return false;
			}
			List<Pawn> list = AggressiveAnimalIncidentUtility.GenerateAnimals(pawnKind, map.Tile, parms.points * ESCP_Spriggan_ModSettings.RaidSizeFactor);
			Rot4 rot = Rot4.FromAngleFlat((map.Center - spawnCenter).AngleFlat);
			for (int i = 0; i < list.Count; i++)
			{
				Pawn pawn = list[i];
				IntVec3 loc = CellFinder.RandomClosewalkCellNear(spawnCenter, map, 10, null);
				QuestUtility.AddQuestTag(GenSpawn.Spawn(pawn, loc, map, rot, WipeMode.Vanish, false), parms.questTag);
				pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent);
				pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + Rand.Range(AnimalsStayDurationMin, AnimalsStayDurationMax);
			}
			Find.LetterStack.ReceiveLetter("ESCP_Spriggan_SprigganAttack_Label".Translate(), "ESCP_Spriggan_SprigganAttack_Description".Translate(), LetterDefOf.ThreatBig, list[0], null, null);
			Find.TickManager.slower.SignalForceNormalSpeedShort();
			LessonAutoActivator.TeachOpportunity(ConceptDefOf.ForbiddingDoors, OpportunityType.Critical);
			LessonAutoActivator.TeachOpportunity(ConceptDefOf.AllowedAreas, OpportunityType.Important);
			return true;
		}

		private const int AnimalsStayDurationMin = 300000;

		private const int AnimalsStayDurationMax = 600000;
	}
}
