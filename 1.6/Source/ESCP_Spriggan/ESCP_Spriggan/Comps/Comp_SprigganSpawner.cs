using System.Collections.Generic;
using System.Linq;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace ESCP_Spriggan
{
    class Comp_SprigganSpawner : ThingComp
	{
		public CompProperties_SprigganSpawner Props
		{
			get
			{
				return (CompProperties_SprigganSpawner)this.props;
			}
		}

        public override void CompTick()
        {
            base.CompTick();
            if(parent.Spawned && !parent.Destroyed && IsMature())
            {
                if (ticksUntilSpriggan >= Props.timeRequired)
                {
                    ticksUntilSpriggan = 0;
                    SpawnSpriggan();
                }
                ticksUntilSpriggan++;
            }
        }

        public void SpawnSpriggan()
        {
            Pawn spriggan = PawnGenerator.GeneratePawn(Props.pawnDef, Faction.OfPlayer);
            PawnUtility.TrySpawnHatchedOrBornPawn(spriggan, parent);
            Messages.Message("ESCP_Spriggan_SpriganCreated".Translate(spriggan.def.label, parent.def.label), spriggan, MessageTypeDefOf.PositiveEvent, true);
        }

        public bool IsMature()
        {
            Plant p = parent as Plant;
            return p.LifeStage == PlantLifeStage.Mature;
        }

        public override void PostPostMake()
        {
            base.PostPostMake();
            ticksUntilSpriggan = 0;
        }

        public override string CompInspectStringExtra()
        {
            return IsMature() ? "ESCP_Spriggan_SpriganCreationProgress".Translate(((float)ticksUntilSpriggan / (float)Props.timeRequired).ToStringPercent(), Props.pawnDef.label) 
                : "ESCP_Spriggan_SpriganCreation_Immature".Translate(Props.pawnDef.label, parent.def.label);
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref ticksUntilSpriggan, "ticksUntilSpriggan", 0);
        }

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            if (Prefs.DevMode)
            {
                yield return new Command_Action
                {
                    defaultLabel = "Debug: Set progress to 0",
                    action = delegate ()
                    {
                        ticksUntilSpriggan = 0;
                    }
                };
                yield return new Command_Action
                {
                    defaultLabel = "Debug: Set progress to max",
                    action = delegate ()
                    {
                        ticksUntilSpriggan = Props.timeRequired;
                    }
                };
            }
            yield break;
        }

        private int ticksUntilSpriggan;
    }
}
