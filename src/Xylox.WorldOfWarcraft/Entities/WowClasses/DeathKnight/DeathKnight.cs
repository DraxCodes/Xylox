namespace Xylox.WorldOfWarcraft.Entities.WowClasses.DeathKnight
{
    public class DeathKnight : Class
    {
        public Blood Blood { get; set; } = new Blood();
        public Frost Frost { get; set; } = new Frost();
        public Unholy Unholy { get; set; } = new Unholy();
    }
}
