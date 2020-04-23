namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Paladin
{
    public class Paladin : Class
    {
        public Holy Holy { get; set; } = new Holy();
        public Protection Protection { get; set; } = new Protection();
        public Retribution Retribution { get; set; } = new Retribution();
    }
}
