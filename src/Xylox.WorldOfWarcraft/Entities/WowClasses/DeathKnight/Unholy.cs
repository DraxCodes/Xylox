using System;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.DeathKnight
{
    public class Unholy : Spec
    {
        public Unholy()
        {
            Description = "The Unholy specialisation currently provides moderate single target damage," +
                " as well as excellent cleave damage against 4+ targets." +
                " It is better in this regard when compared to many other specialisations.";

            Guides = new Guides
            {
                IcyViensUrl = new Uri("https://www.icy-veins.com/wow/unholy-death-knight-pve-dps-guide"),
                BloodMalletUrl = new Uri("https://bloodmallet.com/index.html#death_knight_unholy"),
                WowHeadUrl = new Uri("https://www.wowhead.com/unholy-death-knight-guide")
            };

        }
    }
}
