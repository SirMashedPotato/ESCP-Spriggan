using System;
using Verse;
using RimWorld;
using RimWorld.Planet;

namespace ESCP_Spriggan
{
    class WorldComponent_SprigganAttackTracker : WorldComponent
    {
        public WorldComponent_SprigganAttackTracker(World world) : base(world)
        {

        }

        public override void WorldComponentTick()
        {
            base.WorldComponentTick();
            if (ModSettings_Utility.ESCP_Spriggan_EnableAttackChance())
            {
                if (currentTicks++ >= targetTicks)
                {
                    if (currentAttackChance > 0f)
                    {
                        DecreaseChance();
                    }
                    currentTicks = 0;
                }
            }
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref currentAttackChance, "ESCP_Spriggan_AttackChance", ModSettings_Utility.ESCP_Spriggan_InitialAttackChance());
            base.ExposeData();
        }

        public override void WorldComponentUpdate()
        {
            base.WorldComponentUpdate();
        }

        public static void DecreaseChance()
        {
            currentAttackChance = Math.Max(currentAttackChance - ModSettings_Utility.ESCP_Spriggan_DecreasedAttackChance(), ModSettings_Utility.ESCP_Spriggan_InitialAttackChance());
            if (ModSettings_Utility.ESCP_Spriggan_DebugAttackChance())
            {
                Log.Message("Chance of a spriggan attack reduced by: " + ModSettings_Utility.ESCP_Spriggan_DecreasedAttackChance() + ", to: " + currentAttackChance);
            }
        }

        public static void IncreaseChance()
        {
            currentAttackChance = Math.Min(currentAttackChance + ModSettings_Utility.ESCP_Spriggan_IncreasedAttackChance(), 1f);
            if (ModSettings_Utility.ESCP_Spriggan_DebugAttackChance())
            {
                Log.Message("Chance of a spriggan attack increased by: " + ModSettings_Utility.ESCP_Spriggan_IncreasedAttackChance() + ", to: " + currentAttackChance);
            }
        }

        public static void ResetChance()
        {
            currentAttackChance = ModSettings_Utility.ESCP_Spriggan_InitialAttackChance();
            if (ModSettings_Utility.ESCP_Spriggan_DebugAttackChance())
            {
                Log.Message("Chance of a spriggan attack has been reset to: " + currentAttackChance);
            }
        }

        public static float GetChance()
        {
            return currentAttackChance;
        }


        private int currentTicks = 0;
        private readonly int targetTicks = 60000;   //should be a day
        public static float currentAttackChance = ModSettings_Utility.ESCP_Spriggan_InitialAttackChance();
    }
}