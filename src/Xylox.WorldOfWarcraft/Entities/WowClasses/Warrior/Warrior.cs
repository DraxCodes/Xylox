using System;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Warrior
{
    public class Warrior : Class
    {
        public Arms Arms { get; set; } = new Arms();
        public Fury Fury { get; set; } = new Fury();
        public Protection Protection { get; set; } = new Protection();

        public Warrior()
        {
            Name = "Warrior";
            LevelingGuideUrl = new Uri("https://www.icy-veins.com/wow/warrior-leveling-guide");
            WeakAuraUrl = new Uri("https://wago.io/weakauras/classes/warrior");
        }
    }
}
