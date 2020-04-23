namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Shaman
{
    public class Shaman : Class
    {
        public Elemental Elemental { get; set; } = new Elemental();
        public Enhancement Enhancement { get; set; } = new Enhancement();
        public Restoration Restoration { get; set; } = new Restoration();
    }
}
