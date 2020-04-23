namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Priest
{
    public class Priest : Class
    {
        public Holy Holy { get; set; } = new Holy();
        public Discipline Discipline { get; set; } = new Discipline();
        public Shadow Shadow { get; set; } = new Shadow();
    }
}
