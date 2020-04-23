using System.Collections.Generic;

namespace Xylox.WorldOfWarcraft.Entities
{
    public class Spec
    {
        public string Description { get; set; } = string.Empty;
        public Stats Stats { get; set; } = new Stats();
        public Guides Guides { get; set; } = new Guides();
        public IEnumerable<WeakAura> WeakAuras { get; set; } = new List<WeakAura>();
    }
}
