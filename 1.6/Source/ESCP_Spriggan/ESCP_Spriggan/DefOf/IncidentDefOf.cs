using System;
using Verse;
using RimWorld;

namespace ESCP_Spriggan
{
    [DefOf]
    public static class IncidentDefOf
    {
        static IncidentDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(IncidentDefOf));
        }

        public static IncidentDef ESCP_Spriggan_SprigganAttack;

    }
}
