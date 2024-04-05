using System;
using Verse;
using RimWorld;
using Verse.AI.Group;
using System.Collections.Generic;

namespace ESCP_Spriggan
{
    class DeathActionWorker_BurntSpriggan : DeathActionWorker
    {

        public override RulePackDef DeathRules
        {
            get
            {
                return RulePackDefOf.Transition_DiedExplosive;
            }
        }

        public override bool DangerousInMelee
        {
            get
            {
                return true;
            }
        }

        public override void PawnDied(Corpse corpse, Lord prevLord)
        {
            GenExplosion.DoExplosion(
                            center: corpse.Position,
                            map: corpse.Map,
                            radius: 1.9f,
                            damType: DamageDefOf.Flame,
                            damAmount: 6,
                            instigator: corpse.InnerPawn,
                            ignoredThings: new List<Thing> { corpse },
                            damageFalloff: true
                            );
        }
    }
}
