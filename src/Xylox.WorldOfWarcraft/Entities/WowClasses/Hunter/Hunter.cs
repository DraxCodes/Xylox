using System;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Hunter
{
    public class Hunter : Class
    {
        public BeastMastery BeastMastery { get; set; } = new BeastMastery();
        public Survival Survival { get; set; } = new Survival();
        public Marksmanship Marksmanship { get; set; } = new Marksmanship();

        public Hunter()
        {
            Name = "Hunter";
            LevelingGuideUrl = new Uri("https://www.icy-veins.com/wow/hunter-leveling-guide");
            WeakAuraUrl = new Uri("https://wago.io/weakauras/classes/hunter");
        }
    }
}
