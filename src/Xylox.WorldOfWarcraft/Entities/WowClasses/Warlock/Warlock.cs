using System;
using System.Security.Cryptography;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Warlock
{
    public class Warlock : Class
    {
        public Affliction Affliction { get; set; } = new Affliction();
        public Demonology Demonology { get; set; } = new Demonology();
        public Destruction Destruction { get; set; } = new Destruction();

        public Warlock()
        {
            Name = "Warlock";
            LevelingGuideUrl = new Uri("https://www.icy-veins.com/wow/warlock-leveling-guide");
            WeakAuraUrl = new Uri("https://wago.io/weakauras/classes/warlock");
        }
    }
}
