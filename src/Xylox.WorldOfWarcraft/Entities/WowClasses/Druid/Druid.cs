using System;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Druid
{
    public class Druid : Class
    {
        public Balance Balance { get; set; } = new Balance();
        public Feral Feral { get; set; } = new Feral();
        public Guardian Guardian { get; set; } = new Guardian();
        public Restoration Restoration { get; set; } = new Restoration();

        public Druid()
        {
            Name = "Druid";
            LevelingGuideUrl = new Uri("https://www.icy-veins.com/wow/druid-leveling-guide");
            WeakAuraUrl = new Uri("https://wago.io/weakauras/classes/druid");
        }
    }
}
