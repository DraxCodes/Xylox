namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Mage
{
    public class Mage : Class
    {
        public Frost Frost { get; set; } = new Frost();
        public Fire Fire { get; set; } = new Fire();
        public Arcane Arcane { get; set; } = new Arcane();
    }
}
