using System.Collections.Generic;

namespace Xylox.WorldOfWarcraft.Entities
{
    public class Spec
    {
        public string Description { get; set; } = string.Empty;
        public Stats Stats { get; set; }
        public Guides Guides { get; set; }
        public IEnumerable<WeakAura> WeakAuras { get; set; }
    }
}
