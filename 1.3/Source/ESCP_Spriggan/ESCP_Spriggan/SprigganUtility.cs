using Verse;

namespace ESCP_Spriggan
{
    public static class SprigganUtility
    {
        public static PawnKindDef GetSprigganType(Map map)
        {
            foreach(PawnKindDef kind in map.Biome.AllWildAnimals.InRandomOrder())
            {
                if (kind.race.tradeTags != null && kind.race.tradeTags.Contains("ESCP_Spriggan"))
                {
                    return kind;
                }
            }

            return PawnKindDef.Named("ESCP_Spriggan");
        }
    }
}
