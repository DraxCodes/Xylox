namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Rogue
{
    public class Rogue : Class
    {
        public Assassination Assassination { get; set; } = new Assassination();
        public Subtlety Subtlety { get; set; } = new Subtlety();
        public Outlaw Outlaw { get; set; } = new Outlaw();
    }
}
