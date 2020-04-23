﻿using System;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Shaman
{
    public class Shaman : Class
    {
        public Elemental Elemental { get; set; } = new Elemental();
        public Enhancement Enhancement { get; set; } = new Enhancement();
        public Restoration Restoration { get; set; } = new Restoration();

        public Shaman()
        {
            Name = "Shaman";
            LevelingGuideUrl = new Uri("https://www.icy-veins.com/wow/shaman-leveling-guide");
            WeakAuraUrl = new Uri("https://wago.io/weakauras/classes/shaman");
        }
    }
}
