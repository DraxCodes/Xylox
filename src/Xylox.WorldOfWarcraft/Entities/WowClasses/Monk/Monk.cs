using System;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Monk
{
    public class Monk : Class
    {
        public Brewmaster Brewmaster { get; set; } = new Brewmaster();
        public Mistweaver Mistweaver { get; set; } = new Mistweaver();
        public Windwalker Windwalker { get; set; } = new Windwalker();

        public Monk()
        {
            Name = "Monk";
            LevelingGuideUrl = new Uri("https://www.icy-veins.com/wow/monk-leveling-guide");
            WeakAuraUrl = new Uri("https://wago.io/weakauras/classes/monk");
        }
    }
}
