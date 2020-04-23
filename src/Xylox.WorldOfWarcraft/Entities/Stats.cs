using System.Collections.Generic;

namespace Xylox.WorldOfWarcraft.Entities
{
    public class Stats
    {
        public Stat CriticalStrike { get; set; }
        public Stat Haste { get; set; }
        public Stat Mastery { get; set; }
        public Stat Versitility { get; set; }
        public IEnumerable<Stat> All { get; }

        public Stats()
        {
            All = new List<Stat>
            {
                CriticalStrike,
                Haste,
                Mastery,
                Versitility
            };
        }
    }
}
