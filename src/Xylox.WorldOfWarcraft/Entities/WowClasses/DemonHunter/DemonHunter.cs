using System;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.DemonHunter
{
    public class DemonHunter : Class
    {
        public Vengeance Vengeance { get; set; } = new Vengeance();
        public Havoc Havoc { get; set; } = new Havoc();

        public DemonHunter()
        {
            Name = "Demon Hunter";
            LevelingGuideUrl = new Uri("https://www.icy-veins.com/wow/demon-hunter-leveling-guide");
            WeakAuraUrl = new Uri("https://wago.io/weakauras/classes/demon-hunter");
        }
    }
}
