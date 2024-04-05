using System;
using Verse;

namespace ESCP_Spriggan
{
    class MapComponent_SprigganAttackTracker : MapComponent
    {
        public MapComponent_SprigganAttackTracker(Map map) : base(map)
        {

        }

        public override void MapComponentTick()
        {
            base.MapComponentTick();
            if (ESCP_Spriggan_ModSettings.EnableAttackChance)
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
            if(ESCP_Spriggan_ModSettings.RaidsCooldown && raidCooldownTicks < targetTicks)
            {
                raidCooldownTicks++;
            }
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref currentAttackChance, "ESCP_Spriggan_AttackChance", ESCP_Spriggan_ModSettings.InitialAttackChance);
            Scribe_Values.Look(ref raidCooldownTicks, "ESCP_Spriggan_RaidCooldownTicks", targetTicks);
            base.ExposeData();
        }

        public override void MapComponentUpdate()
        {
            base.MapComponentUpdate();
        }

        public static void DecreaseChance()
        {
            currentAttackChance = Math.Max(currentAttackChance - ESCP_Spriggan_ModSettings.DecreasedAttackChance, ESCP_Spriggan_ModSettings.InitialAttackChance);
            if (ESCP_Spriggan_ModSettings.DebugAttackChance)
            {
                Log.Message("Chance of a spriggan attack reduced by: " + ESCP_Spriggan_ModSettings.DecreasedAttackChance + ", to: " + currentAttackChance);
            }
        }

        public static void IncreaseChance()
        {
            currentAttackChance = Math.Min(currentAttackChance + ESCP_Spriggan_ModSettings.EIncreasedAttackChance, 1f);
            if (ESCP_Spriggan_ModSettings.DebugAttackChance)
            {
                Log.Message("Chance of a spriggan attack increased by: " + ESCP_Spriggan_ModSettings.EIncreasedAttackChance + ", to: " + currentAttackChance);
            }
        }

        public static void ResetChance()
        {
            currentAttackChance = ESCP_Spriggan_ModSettings.InitialAttackChance;
            if (ESCP_Spriggan_ModSettings.DebugAttackChance)
            {
                Log.Message("Chance of a spriggan attack has been reset to: " + currentAttackChance);
            }
        }

        public static float GetChance()
        {
            return currentAttackChance;
        }

        public static bool CooldownReady()
        { 
            return raidCooldownTicks >= targetTicks;
        }

        public static void ResetRaidCooldown()
        {
            raidCooldownTicks = 0;
        }

        private int currentTicks = 0;
        private static readonly int targetTicks = 60000;   //a day
        private static int raidCooldownTicks = targetTicks;
        public static float currentAttackChance = ESCP_Spriggan_ModSettings.InitialAttackChance;
    }
}