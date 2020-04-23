using System;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Mage
{
    public class Mage : Class
    {
        public Frost Frost { get; set; } = new Frost();
        public Fire Fire { get; set; } = new Fire();
        public Arcane Arcane { get; set; } = new Arcane();

        public Mage()
        {
            Name = "Mage";
            LevelingGuideUrl = new Uri("https://www.icy-veins.com/wow/mage-leveling-guide");
            WeakAuraUrl = new Uri("https://wago.io/weakauras/classes/mage");
        }
    }
}
