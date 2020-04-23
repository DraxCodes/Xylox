using System.Security.Cryptography;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Warlock
{
    public class Warlock : Class
    {
        public Affliction Affliction { get; set; } = new Affliction();
        public Demonology Demonology { get; set; } = new Demonology();
        public Destruction Destruction { get; set; } = new Destruction();
    }
}
