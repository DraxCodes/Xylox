namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Druid
{
    public class Druid : Class
    {
        public Balance Balance { get; set; } = new Balance();
        public Feral Feral { get; set; } = new Feral();
        public Guardian Guardian { get; set; } = new Guardian();
        public Restoration Restoration { get; set; } = new Restoration();
    }
}
