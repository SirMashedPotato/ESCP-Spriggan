﻿using Verse;

namespace ESCP_Spriggan
{
    class ESCP_Spriggan_ModSettings : ModSettings
    {
        //settings
        public bool ESCP_Spriggan_EnableChopAttack = ESCP_Spriggan_EnableChopAttack_def;
        public float ESCP_Spriggan_EnableChopChance = ESCP_Spriggan_EnableChopChance_def;

        public bool ESCP_Spriggan_EnableAttackChance = ESCP_Spriggan_EnableAttackChance_def;
        public bool ESCP_Spriggan_SownAttackChance = ESCP_Spriggan_SownAttackChance_def;
        public bool ESCP_Spriggan_ToxicAttackChance = ESCP_Spriggan_ToxicAttackChance_def;
        public bool ESCP_Spriggan_FireAttackChance = ESCP_Spriggan_FireAttackChance_def;
        public bool ESCP_Spriggan_ResetAttackChance = ESCP_Spriggan_ResetAttackChance_def;
        public float ESCP_Spriggan_InitialAttackChance = ESCP_Spriggan_InitialAttackChance_def;
        public float ESCP_Spriggan_IncreasedAttackChance = ESCP_Spriggan_IncreasedAttackChance_def;
        public float ESCP_Spriggan_DecreasedAttackChance = ESCP_Spriggan_DecreasedAttackChance_def;
        public bool ESCP_Spriggan_RaidsCooldown = ESCP_Spriggan_RaidsCooldown_def;

        public bool ESCP_Spriggan_EnableDefaultType = ESCP_Spriggan_EnableDefaultType_def;
        public bool ESCP_Spriggan_EnableAnimalControl = ESCP_Spriggan_EnableAnimalControl_def;
        public bool ESCP_Spriggan_EnableRegen = ESCP_Spriggan_EnableRegen_def;

        public bool ESCP_Spriggan_DebugAttackChance = ESCP_Spriggan_DebugAttackChance_def;

        //defaults
        private static readonly bool ESCP_Spriggan_EnableChopAttack_def = true;
        private static readonly float ESCP_Spriggan_EnableChopChance_def = 0.005f;

        private static readonly bool ESCP_Spriggan_EnableAttackChance_def = true;
        private static readonly bool ESCP_Spriggan_SownAttackChance_def = true;
        private static readonly bool ESCP_Spriggan_FireAttackChance_def = false;
        private static readonly bool ESCP_Spriggan_ToxicAttackChance_def = true;
        private static readonly bool ESCP_Spriggan_ResetAttackChance_def = true;
        private static readonly float ESCP_Spriggan_InitialAttackChance_def = 0.005f;
        private static readonly float ESCP_Spriggan_IncreasedAttackChance_def = 0.0f; //used to be 0.005f
        private static readonly float ESCP_Spriggan_DecreasedAttackChance_def = 0.1f;
        private static readonly bool ESCP_Spriggan_RaidsCooldown_def = true;

        private static readonly bool ESCP_Spriggan_EnableDefaultType_def = true;
        private static readonly bool ESCP_Spriggan_EnableAnimalControl_def = true;
        private static readonly bool ESCP_Spriggan_EnableRegen_def = true;

        private static readonly bool ESCP_Spriggan_DebugAttackChance_def = false;


        public override void ExposeData()
        {
            Scribe_Values.Look(ref ESCP_Spriggan_EnableChopAttack, "ESCP_Spriggan_EnableChopAttack", ESCP_Spriggan_EnableChopAttack_def);
            Scribe_Values.Look(ref ESCP_Spriggan_EnableChopChance, "ESCP_Spriggan_EnableChopChance", ESCP_Spriggan_EnableChopChance_def);

            Scribe_Values.Look(ref ESCP_Spriggan_EnableAttackChance, "ESCP_Spriggan_EnableAttackChance", ESCP_Spriggan_EnableAttackChance_def);
            Scribe_Values.Look(ref ESCP_Spriggan_SownAttackChance, "ESCP_Spriggan_SownAttackChance", ESCP_Spriggan_SownAttackChance_def);
            Scribe_Values.Look(ref ESCP_Spriggan_FireAttackChance, "ESCP_Spriggan_FireAttackChance", ESCP_Spriggan_FireAttackChance_def);
            Scribe_Values.Look(ref ESCP_Spriggan_ToxicAttackChance, "ESCP_Spriggan_ToxicAttackChance", ESCP_Spriggan_ToxicAttackChance_def);
            Scribe_Values.Look(ref ESCP_Spriggan_ResetAttackChance, "ESCP_Spriggan_ResetAttackChance", ESCP_Spriggan_ResetAttackChance_def);
            Scribe_Values.Look(ref ESCP_Spriggan_InitialAttackChance, "ESCP_Spriggan_InitialAttackChance", ESCP_Spriggan_InitialAttackChance_def);
            Scribe_Values.Look(ref ESCP_Spriggan_IncreasedAttackChance, "ESCP_Spriggan_IncreasedAttackChance", ESCP_Spriggan_IncreasedAttackChance_def);
            Scribe_Values.Look(ref ESCP_Spriggan_DecreasedAttackChance, "ESCP_Spriggan_DecreasedAttackChance", ESCP_Spriggan_DecreasedAttackChance_def);
            Scribe_Values.Look(ref ESCP_Spriggan_RaidsCooldown, "ESCP_Spriggan_RaidsCooldown", ESCP_Spriggan_RaidsCooldown_def);

            Scribe_Values.Look(ref ESCP_Spriggan_EnableDefaultType, "ESCP_Spriggan_EnableDefaultType", ESCP_Spriggan_EnableDefaultType_def);
            Scribe_Values.Look(ref ESCP_Spriggan_EnableAnimalControl, "ESCP_Spriggan_EnableAnimalControl", ESCP_Spriggan_EnableAnimalControl_def);
            Scribe_Values.Look(ref ESCP_Spriggan_EnableRegen, "ESCP_Spriggan_EnableRegen", ESCP_Spriggan_EnableRegen_def);

            Scribe_Values.Look(ref ESCP_Spriggan_DebugAttackChance, "ESCP_Spriggan_DebugAttackChance", ESCP_Spriggan_DebugAttackChance_def);
        }

        public static void ResetSettings(ESCP_Spriggan_ModSettings settings)
        {
            settings.ESCP_Spriggan_EnableChopAttack = ESCP_Spriggan_EnableChopAttack_def;
            settings.ESCP_Spriggan_EnableChopChance = ESCP_Spriggan_EnableChopChance_def;

            settings.ESCP_Spriggan_EnableAttackChance = ESCP_Spriggan_EnableAttackChance_def;
            settings.ESCP_Spriggan_SownAttackChance = ESCP_Spriggan_SownAttackChance_def;
            settings.ESCP_Spriggan_FireAttackChance = ESCP_Spriggan_FireAttackChance_def;
            settings.ESCP_Spriggan_ToxicAttackChance = ESCP_Spriggan_ToxicAttackChance_def;
            settings.ESCP_Spriggan_ResetAttackChance = ESCP_Spriggan_ResetAttackChance_def;
            settings.ESCP_Spriggan_InitialAttackChance = ESCP_Spriggan_InitialAttackChance_def;
            settings.ESCP_Spriggan_IncreasedAttackChance = ESCP_Spriggan_IncreasedAttackChance_def;
            settings.ESCP_Spriggan_DecreasedAttackChance = ESCP_Spriggan_DecreasedAttackChance_def;
            settings.ESCP_Spriggan_DebugAttackChance = ESCP_Spriggan_DebugAttackChance_def;
            settings.ESCP_Spriggan_EnableDefaultType = ESCP_Spriggan_EnableDefaultType_def;
            settings.ESCP_Spriggan_EnableAnimalControl = ESCP_Spriggan_EnableAnimalControl_def;
            settings.ESCP_Spriggan_EnableRegen = ESCP_Spriggan_EnableRegen_def;
            settings.ESCP_Spriggan_RaidsCooldown = ESCP_Spriggan_RaidsCooldown_def;
        }
    }
}
