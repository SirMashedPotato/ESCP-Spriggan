using Verse;

namespace ESCP_Spriggan
{
    public static class ModSettings_Utility
    {
        /* tree chop attack */
        public static bool ESCP_Spriggan_EnableChopAttack()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_EnableChopAttack;
        }

        public static float ESCP_Spriggan_EnableChopChance()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_EnableChopChance;
        }


        /* manhunter pack attack */

        public static bool ESCP_Spriggan_EnableAttackChance()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_EnableAttackChance;
        }

        public static bool ESCP_Spriggan_SownAttackChance()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_SownAttackChance;
        }

        public static bool ESCP_Spriggan_FireAttackChance()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_FireAttackChance;
        }

        public static bool ESCP_Spriggan_ToxicAttackChance()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_ToxicAttackChance;
        }

        public static bool ESCP_Spriggan_ResetAttackChance()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_ResetAttackChance;
        }

        public static bool ESCP_Spriggan_RaidsCooldown()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_RaidsCooldown;
        }

        public static float ESCP_Spriggan_InitialAttackChance()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_InitialAttackChance;
        }

        public static float ESCP_Spriggan_IncreasedAttackChance()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_IncreasedAttackChance;
        }

        public static float ESCP_Spriggan_DecreasedAttackChance()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_DecreasedAttackChance;
        }

        public static bool ESCP_Spriggan_EnableDefaultType()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_EnableDefaultType;
        }

        public static bool ESCP_Spriggan_EnableAnimalControl()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_EnableAnimalControl;
        }

        public static bool ESCP_Spriggan_EnableRegen()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_EnableRegen;
        }

        //Debug

        public static bool ESCP_Spriggan_DebugAttackChance()
        {
            return LoadedModManager.GetMod<ESCP_Spriggan_Mod>().GetSettings<ESCP_Spriggan_ModSettings>().ESCP_Spriggan_DebugAttackChance && Prefs.DevMode;
        }
    }
}
