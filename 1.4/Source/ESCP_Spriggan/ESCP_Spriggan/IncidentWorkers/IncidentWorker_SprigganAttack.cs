using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;
using System.Reflection.Emit;
using System.Linq;

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
			PawnKindDef pawnKindDef;
			IntVec3 intVec;
			return ManhunterPackIncidentUtility.TryFindManhunterAnimalKind(parms.points, map.Tile, out pawnKindDef) && RCellFinder.TryFindRandomPawnEntryCell(out intVec, map, CellFinder.EdgeRoadChance_Animal, false, null);
		}

		protected override bool TryExecuteWorker(IncidentParms parms)
		{
			Map map = (Map)parms.target;
			PawnKindDef pawnKind = SprigganUtility.GetSprigganType(map);
			if (pawnKind == null || ManhunterPackIncidentUtility.GetAnimalsCount(pawnKind, parms.points) == 0)
			{
				return false;
			}
			IntVec3 spawnCenter = parms.spawnCenter;
			if (!spawnCenter.IsValid && !RCellFinder.TryFindRandomPawnEntryCell(out spawnCenter, map, CellFinder.EdgeRoadChance_Animal, false, null))
			{
				return false;
			}
			List<Pawn> list = ManhunterPackIncidentUtility.GenerateAnimals(pawnKind, map.Tile, parms.points * PointsFactor);
			Rot4 rot = Rot4.FromAngleFlat((map.Center - spawnCenter).AngleFlat);
			for (int i = 0; i < list.Count; i++)
			{
				Pawn pawn = list[i];
				IntVec3 loc = CellFinder.RandomClosewalkCellNear(spawnCenter, map, 10, null);
				QuestUtility.AddQuestTag(GenSpawn.Spawn(pawn, loc, map, rot, WipeMode.Vanish, false), parms.questTag);
				pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent, null, false, false, null, false);
				pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + Rand.Range(AnimalsStayDurationMin, AnimalsStayDurationMax);
			}
			Find.LetterStack.ReceiveLetter("ESCP_Spriggan_SprigganAttack_Label".Translate(), "ESCP_Spriggan_SprigganAttack_Description".Translate(), LetterDefOf.ThreatBig, list[0], null, null);
			Find.TickManager.slower.SignalForceNormalSpeedShort();
			LessonAutoActivator.TeachOpportunity(ConceptDefOf.ForbiddingDoors, OpportunityType.Critical);
			LessonAutoActivator.TeachOpportunity(ConceptDefOf.AllowedAreas, OpportunityType.Important);
			return true;
		}

		private const float PointsFactor = 3f;

		private const int AnimalsStayDurationMin = 300000;

		private const int AnimalsStayDurationMax = 600000;
	}
}
