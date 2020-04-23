using System;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Rogue
{
    public class Rogue : Class
    {
        public Assassination Assassination { get; set; } = new Assassination();
        public Subtlety Subtlety { get; set; } = new Subtlety();
        public Outlaw Outlaw { get; set; } = new Outlaw();

        public Rogue()
        {
            Name = "Rogue";
            LevelingGuideUrl = new Uri("https://www.icy-veins.com/wow/rogue-leveling-guide");
            WeakAuraUrl = new Uri("https://wago.io/weakauras/classes/rogue");
        }
    }
}
