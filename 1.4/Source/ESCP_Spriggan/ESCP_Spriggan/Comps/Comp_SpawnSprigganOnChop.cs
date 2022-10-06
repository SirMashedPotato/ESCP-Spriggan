using RimWorld;
using Verse;
using System;
using System.Collections.Generic;

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

        public bool takingAgeDamage = false;

        public override void PostPostApplyDamage(DamageInfo dinfo, float totalDamageDealt)
        {
            takingAgeDamage = dinfo.Def == DamageDefOf.Rotting || dinfo.Def == DamageDefOf.Deterioration || (dinfo.Def == DamageDefOf.Flame && !ModSettings_Utility.ESCP_Spriggan_FireAttackChance());
            base.PostPostApplyDamage(dinfo, totalDamageDealt);
        }

        public override void PostPreApplyDamage(DamageInfo dinfo, out bool absorbed)
        {
            takingAgeDamage = dinfo.Def == DamageDefOf.Rotting || dinfo.Def == DamageDefOf.Deterioration || (dinfo.Def == DamageDefOf.Flame && !ModSettings_Utility.ESCP_Spriggan_FireAttackChance());
            base.PostPreApplyDamage(dinfo, out absorbed);
        }

        public override void PostDestroy(DestroyMode mode, Map previousMap)
        {
            if (!takingAgeDamage && GenDate.DaysPassedSinceSettle > 1)
            {
                if (ModSettings_Utility.ESCP_Spriggan_ToxicAttackChance() && previousMap.gameConditionManager.ConditionIsActive(GameConditionDefOf.ToxicFallout))
                {
                    return;
                }
                //check smol attack
                if (ModSettings_Utility.ESCP_Spriggan_EnableChopAttack())
                {
                    Plant p = parent as Plant;
                    if(!ModSettings_Utility.ESCP_Spriggan_SownAttackChance() && p.sown)
                    {
                        return;
                    }
                    if (Props.overrideList != null)
                    {
                        foreach (Overrides ov in Props.overrideList)
                        {
                            if (parent.def.ToString() == ov.treeDefName)
                            {
                                if (Rand.Chance(ov.overrideChance ? ov.overriddenChance : ModSettings_Utility.ESCP_Spriggan_EnableChopChance()))
                                {
                                    SpawnAngrySpriggan(previousMap, parent, PawnKindDef.Named(ov.kindDefName));
                                    base.PostDestroy(mode, previousMap);
                                    return;
                                }
                                break;
                            }
                        }
                    }
                    if (Rand.Chance(ModSettings_Utility.ESCP_Spriggan_EnableChopChance()))
                    {
                        SpawnAngrySpriggan(previousMap, parent);
                        base.PostDestroy(mode, previousMap);
                        return;
                    }
                }

                if (ModSettings_Utility.ESCP_Spriggan_EnableAttackChance() && (!ModSettings_Utility.ESCP_Spriggan_RaidsCooldown() || MapComponent_SprigganAttackTracker.CooldownReady()))
                {
                    MapComponent_SprigganAttackTracker.IncreaseChance();
                    if (Rand.Chance(MapComponent_SprigganAttackTracker.GetChance()))
                    {
                        TriggerAttack(previousMap);
                        if (ModSettings_Utility.ESCP_Spriggan_ResetAttackChance())
                        {
                            MapComponent_SprigganAttackTracker.ResetChance();
                        }
                        MapComponent_SprigganAttackTracker.ResetRaidCooldown();
                    }
                }
               
            }

            base.PostDestroy(mode, previousMap);
        }


        //for big boy attack
        public static void TriggerAttack(Map map)
        {
            //Log.Message("Attack triggered on map: " + map);
            IncidentDef def = IncidentDefOf.ESCP_Spriggan_SprigganAttack;
            IncidentParms parms = StorytellerUtility.DefaultParmsNow(def.category, map);
            parms.forced = true;
            def.Worker.TryExecute(parms);
        }

        //for smol attack
        public static void SpawnAngrySpriggan(Map map, Thing parent)
        {
            SpawnAngrySpriggan(map, parent, SprigganUtility.GetSprigganType(map));
        }

        public static void SpawnAngrySpriggan(Map map, Thing parent, PawnKindDef kindDef)
        {
            if(kindDef != null)
            {
                int avg = (int)kindDef.wildGroupSize.Average;   //basically just gets the wild group size, spawns that number in. This does mean you pretty much always want wild group size to be 1
                List<Pawn> pawns = new List<Pawn> { }; 
                for (int i = 0; i < avg; i++)
                {
                    Pawn newP = PawnGenerator.GeneratePawn(kindDef, null);
                    GenSpawn.Spawn(newP, parent.Position, map);
                    newP.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent);
                    pawns.Add(newP);
                }
                if (!pawns.NullOrEmpty())
                {
                    Find.LetterStack.ReceiveLetter("ESCP_Spriggan_SprigganChopAttack_Label".Translate(), "ESCP_Spriggan_SprigganChopAttack_Description".Translate(), LetterDefOf.ThreatBig, pawns);

                }
            }
        }
    }
}
