using System;
using System.Collections.Generic;
using Verse;
using Verse.AI;
using RimWorld;
using System.Linq;
using UnityEngine;
using Verse.Sound;

namespace ESCP_Spriggan
{
    class Comp_SprigganAnimalControl : ThingComp
    {

        public CompProperties_SprigganAnimalControl Props
        {
            get
            {
                return (CompProperties_SprigganAnimalControl)this.props;
            }
        }

        private int timesActivated = 0;

        public override void PostPostApplyDamage(DamageInfo dinfo, float totalDamageDealt)
        {
            base.PostPostApplyDamage(dinfo, totalDamageDealt);

            if (parent.Spawned && ModSettings_Utility.ESCP_Spriggan_EnableAnimalControl() && timesActivated < Props.maxNumberControlled && Rand.Chance(Props.chance))
            {
                Pawn p = parent as Pawn;
                if (!p.Dead && p.Faction == null && dinfo.Instigator != null && dinfo.Instigator.def != null && dinfo.Instigator.def.race != null && dinfo.Instigator.def.race.Humanlike)
                {
                    Predicate<Thing> predicate = (Thing t) => t.def.category == ThingCategory.Pawn && IsValid(t);
                    Thing animal = GenClosest.ClosestThingReachable(parent.Position, parent.Map, ThingRequest.ForGroup(ThingRequestGroup.Pawn), PathEndMode.OnCell,
                        TraverseParms.For(parent as Pawn, Danger.Unspecified, TraverseMode.ByPawn, false), Props.maxRange, predicate);
                    if (animal != null)
                    {
                        Pawn target = animal as Pawn;
                        target.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Manhunter);
                        if (Props.fleckDef != null)
                        {
                            FleckMaker.AttachedOverlay(parent, this.Props.fleckDef, Vector3.zero, 1f, -1f);
                            FleckMaker.AttachedOverlay(target, this.Props.fleckDef, Vector3.zero, 1f, -1f);
                        }
                        if (Props.soundDef != null)
                        {
                            Props.soundDef.PlayOneShot(new TargetInfo(parent.Position, parent.Map, false));
                        }
                        Messages.Message("ESCP_Spriggan_SpriganAnimalControlled".Translate(target.def.label), target, MessageTypeDefOf.NegativeEvent, true);
                        timesActivated++;
                    }
                }
            }
        }

        private bool IsValid(Thing t)
        {
            Pawn p = t as Pawn;
            return p.AnimalOrWildMan() && p.Faction == null && p.mindState.mentalStateHandler.CurStateDef != MentalStateDefOf.Manhunter && p.mindState.mentalStateHandler.CurStateDef != MentalStateDefOf.ManhunterPermanent 
                && (p.kindDef.race.tradeTags == null ||  !p.kindDef.race.tradeTags.Contains("ESCP_Spriggan"));
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref timesActivated, "SprigganAnimalsControlled", 0);
        }
    }
}