namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Monk
{
    public class Monk : Class
    {
        public Brewmaster Brewmaster { get; set; } = new Brewmaster();
        public Mistweaver Mistweaver { get; set; } = new Mistweaver();
        public Windwalker Windwalker { get; set; } = new Windwalker();
    }
}
