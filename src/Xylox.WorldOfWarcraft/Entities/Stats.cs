using System.Collections.Generic;

namespace Xylox.WorldOfWarcraft.Entities
{
    public class Stats
    {
        public Stat CriticalStrike { get; set; } = new Stat();
        public Stat Haste { get; set; } = new Stat();
        public Stat Mastery { get; set; } = new Stat();
        public Stat Versitility { get; set; } = new Stat();
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
