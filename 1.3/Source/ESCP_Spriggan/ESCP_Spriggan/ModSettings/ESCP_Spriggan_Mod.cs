using UnityEngine;
using Verse;
using System;

namespace ESCP_Spriggan
{
    class ESCP_Spriggan_Mod : Mod
    {

        ESCP_Spriggan_ModSettings settings;
        public ESCP_Spriggan_Mod(ModContentPack contentPack) : base(contentPack)
        {
            this.settings = GetSettings<ESCP_Spriggan_ModSettings>();
        }

        public override string SettingsCategory() => "ESCP_Spriggan_ModName".Translate();

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);

            /* settings */
            listing_Standard.CheckboxLabeled("ESCP_Spriggan_EnableChopAttack".Translate(), ref settings.ESCP_Spriggan_EnableChopAttack);
            listing_Standard.Gap();

            listing_Standard.Label("ESCP_Spriggan_EnableChopChance".Translate() + " (" + settings.ESCP_Spriggan_EnableChopChance * 100 + "%)");
            settings.ESCP_Spriggan_EnableChopChance = (float)Mathf.Round(listing_Standard.Slider(settings.ESCP_Spriggan_EnableChopChance, 0.01f, 1f) * 100) / 100;
            listing_Standard.Gap();

            //listing_Standard.GapLine();
            //listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_Spriggan_EnableAttackChance".Translate(), ref settings.ESCP_Spriggan_EnableAttackChance);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_Spriggan_SownAttackChance".Translate(), ref settings.ESCP_Spriggan_SownAttackChance);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_Spriggan_ResetAttackChance".Translate(), ref settings.ESCP_Spriggan_ResetAttackChance);
            listing_Standard.Gap();

            listing_Standard.Label("ESCP_Spriggan_InitialAttackChance".Translate() + " (" + settings.ESCP_Spriggan_InitialAttackChance * 100 + "%)");
            settings.ESCP_Spriggan_InitialAttackChance = (float)Mathf.Round(listing_Standard.Slider(settings.ESCP_Spriggan_InitialAttackChance, 0.01f, 1f) * 100) / 100;
            listing_Standard.Gap();

            listing_Standard.Label("ESCP_Spriggan_IncreasedAttackChance".Translate() + " (" + settings.ESCP_Spriggan_IncreasedAttackChance * 100 + "%)");
            settings.ESCP_Spriggan_IncreasedAttackChance = (float)Mathf.Round(listing_Standard.Slider(settings.ESCP_Spriggan_IncreasedAttackChance, 0f, 1f) * 100) / 100;
            listing_Standard.Gap();

            listing_Standard.Label("ESCP_Spriggan_DecreasedAttackChance".Translate() + " (" + settings.ESCP_Spriggan_DecreasedAttackChance * 100 + "%)");
            settings.ESCP_Spriggan_DecreasedAttackChance = (float)Mathf.Round(listing_Standard.Slider(settings.ESCP_Spriggan_DecreasedAttackChance, 0f, 1f) * 100) / 100;
            listing_Standard.Gap();

            //listing_Standard.GapLine();
            //listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_Spriggan_EnableAnimalControl".Translate(), ref settings.ESCP_Spriggan_EnableAnimalControl);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_Spriggan_EnableRegen".Translate(), ref settings.ESCP_Spriggan_EnableRegen);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("ESCP_Spriggan_EnableDefaultType".Translate(), ref settings.ESCP_Spriggan_EnableDefaultType);
            listing_Standard.Gap();

            if (Prefs.DevMode)
            {
                listing_Standard.CheckboxLabeled("ESCP_Spriggan_DebugAttackChance".Translate(), ref settings.ESCP_Spriggan_DebugAttackChance);
                listing_Standard.Gap();
            }

            listing_Standard.GapLine();
            listing_Standard.Gap();

            Rect rectDefault = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectDefault, "ESCP_Reset".Translate());
            if (Widgets.ButtonText(rectDefault, "ESCP_Reset".Translate(), true, true, true))
            {
                ESCP_Spriggan_ModSettings.ResetSettings(settings);
            }

            listing_Standard.End();
            base.DoSettingsWindowContents(inRect);
        }
    }
}
