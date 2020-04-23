using System;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.Priest
{
    public class Priest : Class
    {
        public Holy Holy { get; set; } = new Holy();
        public Discipline Discipline { get; set; } = new Discipline();
        public Shadow Shadow { get; set; } = new Shadow();

        public Priest()
        {
            Name = "Priest";
            LevelingGuideUrl = new Uri("https://www.icy-veins.com/wow/priest-leveling-guide");
            WeakAuraUrl = new Uri("https://wago.io/weakauras/classes/priest");
        }
    }
}
