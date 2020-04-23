using System;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.DeathKnight
{
    public class DeathKnight : Class
    {
        public Blood Blood { get; set; } = new Blood();
        public Frost Frost { get; set; } = new Frost();
        public Unholy Unholy { get; set; } = new Unholy();

        public DeathKnight()
        {
            Name = "Death Knight";
            LevelingGuideUrl = new Uri("https://www.icy-veins.com/wow/death-knight-leveling-guide");
            WeakAuraUrl = new Uri("https://wago.io/weakauras/classes/death-knight");
        }
    }
}
