using System;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Paladin
{
    public class Paladin : Class
    {
        public Holy Holy { get; set; } = new Holy();
        public Protection Protection { get; set; } = new Protection();
        public Retribution Retribution { get; set; } = new Retribution();

        public Paladin()
        {
            Name = "Paladin";
            LevelingGuideUrl = new Uri("https://www.icy-veins.com/wow/paladin-leveling-guide");
            WeakAuraUrl = new Uri("https://wago.io/weakauras/classes/paladin");
        }
    }
}
