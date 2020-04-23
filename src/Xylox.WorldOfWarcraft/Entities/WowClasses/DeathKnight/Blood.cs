using System;

namespace Xylox.WorldOfWarcraft.Entities.WowClasses.DeathKnight
{
    public class Blood : Spec
    {
        public Blood()
        {
            Description = "The Blood specialization has an engaging playstyle, " +
                "using self-healing through Death Strike Icon Death Strike as a primary source of damage mitigation. " +
                "Blood has a versatile defensive toolkit and is effective in the full range of current content.";

            Guides = new Guides
            {
                IcyViensUrl = new Uri("https://www.icy-veins.com/wow/blood-death-knight-pve-tank-guide"),
                BloodMalletUrl = new Uri("https://bloodmallet.com/index.html#death_knight_blood"),
                WowHeadUrl = new Uri("https://www.wowhead.com/blood-death-knight-guide")
            };
        }
    }
}
