namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Warrior
{
    public class Warrior : Class
    {
        public Arms Arms { get; set; } = new Arms();
        public Fury Fury { get; set; } = new Fury();
        public Protection Protection { get; set; } = new Protection();
    }
}
