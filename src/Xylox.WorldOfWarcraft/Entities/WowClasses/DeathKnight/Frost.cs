using System;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.DeathKnight
{
    public class Frost : Spec
    {
        public Frost()
        {
            Description = "The Frost specialisation provides reasonable single " +
                "target and AoE DPS and it seems to be on par with Unholy in terms of performance. " +
                "Its playstyle is straightforward and its rotation is easy to learn.";

            Guides = new Guides
            {
                IcyViensUrl = new Uri("https://www.icy-veins.com/wow/frost-death-knight-pve-dps-guide"),
                BloodMalletUrl = new Uri("https://bloodmallet.com/index.html#death_knight_frost"),
                WowHeadUrl = new Uri("https://www.wowhead.com/frost-death-knight-guide")
            };
        }
    }
}
