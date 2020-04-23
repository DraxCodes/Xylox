namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Hunter
{
    public class Hunter : Class
    {
        public BeastMastery BeastMastery { get; set; } = new BeastMastery();
        public Survival Survival { get; set; } = new Survival();
        public Marksmanship Marksmanship { get; set; } = new Marksmanship();
    }
}
