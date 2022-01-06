using Verse;
using System.Collections.Generic;
using System.Linq;

namespace ESCP_Spriggan
{
    public static class SprigganUtility
    {
        public static PawnKindDef GetSprigganType(Map map)
        {
            List<PawnKindDef> kinds = map.Biome.AllWildAnimals.Where(x => x.race.tradeTags != null && x.race.tradeTags.Contains("ESCP_Spriggan")).ToList();
            if (!kinds.NullOrEmpty())
            {
                kinds.SortBy(x => map.Biome.CommonalityOfAnimal(x));
                return kinds.RandomElementByWeightWithFallback(x => map.Biome.CommonalityOfAnimal(x)*100, kinds.ElementAt(0));
            }
            if (ModSettings_Utility.ESCP_Spriggan_EnableDefaultType())
            {
                return Rand.Chance(0.05f) ? (Rand.Chance(0.15f) ? PawnKindDef.Named("ESCP_Spriggan_EarthMother") : PawnKindDef.Named("ESCP_Spriggan_Matron")) : PawnKindDef.Named("ESCP_Spriggan");
            }
            return null;
        }
    }
}
