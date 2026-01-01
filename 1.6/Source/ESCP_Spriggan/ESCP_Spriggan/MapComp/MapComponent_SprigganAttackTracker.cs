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
            if (ESCP_Spriggan_ModSettings.EnableAttackChance)
            {
                if (currentTicks++ >= TARGET_TICKS)
                {
                    if (currentAttackChance > 0f)
                    {
                        DecreaseChance();
                    }
                    currentTicks = 0;
                }
            }
            if(ESCP_Spriggan_ModSettings.RaidsCooldown && raidCooldownTicks < TARGET_TICKS)
            {
                raidCooldownTicks++;
            }
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref currentAttackChance, "ESCP_Spriggan_AttackChance", ESCP_Spriggan_ModSettings.InitialAttackChance);
            Scribe_Values.Look(ref raidCooldownTicks, "ESCP_Spriggan_RaidCooldownTicks", TARGET_TICKS);
            base.ExposeData();
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
            return raidCooldownTicks >= TARGET_TICKS;
        }

        public static void ResetRaidCooldown()
        {
            raidCooldownTicks = 0;
        }

        private int currentTicks;
        private const int TARGET_TICKS = 60000;   //a day
        private static int raidCooldownTicks = TARGET_TICKS;
        private static float currentAttackChance = ESCP_Spriggan_ModSettings.InitialAttackChance;
    }
}