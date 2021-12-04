using RimWorld;
using Verse;
using System;

namespace ESCP_Spriggan
{
    class Comp_SpawnSprigganOnChop : ThingComp
    {
		public CompProperties_SpawnSprigganOnChop Props
		{
			get
			{
				return (CompProperties_SpawnSprigganOnChop)this.props;
			}
		}

        public override void PostDestroy(DestroyMode mode, Map previousMap)
        {
            //check the big boy attack first
            if (ModSettings_Utility.ESCP_Spriggan_EnableAttackChance())
            {
                WorldComponent_SprigganAttackTracker.IncreaseChance();
                if (Rand.Chance(WorldComponent_SprigganAttackTracker.GetChance()))
                {
                    TriggerAttack(previousMap);
                    if (ModSettings_Utility.ESCP_Spriggan_ResetAttackChance())
                    {
                        WorldComponent_SprigganAttackTracker.ResetChance();
                    }
                    base.PostDestroy(mode, previousMap);
                    return;
                }
            }

            //if not then proceed to check smol attack
            if (ModSettings_Utility.ESCP_Spriggan_EnableChopAttack())
            {
                if (Rand.Chance(ModSettings_Utility.ESCP_Spriggan_EnableChopChance()))
                {
                    SpawnAngrySpriggan(previousMap, parent);
                }
            }
            base.PostDestroy(mode, previousMap);
        }


        //for big boy attack
        public static void TriggerAttack(Map map)
        {
            Log.Message("Attack triggered on map: " + map);
            IncidentDef def = IncidentDefOf.ESCP_Spriggan_SprigganAttack;
            IncidentParms parms = StorytellerUtility.DefaultParmsNow(def.category, map);
            parms.forced = true;
            def.Worker.TryExecute(parms);
        }

        //for smol attack
        public static void SpawnAngrySpriggan(Map map, Thing parent)
        {
            Pawn newP = PawnGenerator.GeneratePawn(SprigganUtility.GetSprigganType(map), null);
            GenSpawn.Spawn(newP, parent.Position, map);
            newP.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent);
            Find.LetterStack.ReceiveLetter("ESCP_Spriggan_SprigganChopAttack_Label".Translate(), "ESCP_Spriggan_SprigganChopAttack_Description".Translate(), LetterDefOf.ThreatBig, newP);
        }
    }
}
