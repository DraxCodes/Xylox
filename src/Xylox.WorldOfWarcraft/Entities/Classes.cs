using Xylox.WorldOfWarcraft.Entities.WowClasses.DeathKnight;
using Xylox.WorldOfWarcraft.Entities.WowClasses.DemonHunter;
using Xylox.WorldOfWarcraft.Entities.WowClasses.Druid;
using Xylox.WorldOfWarcraft.Entities.WowClasses.Hunter;
using Xylox.WorldOfWarcraft.Entities.WowClasses.Mage;
using Xylox.WorldOfWarcraft.Entities.WowClasses.Monk;
using Xylox.WorldOfWarcraft.Entities.WowClasses.Paladin;
using Xylox.WorldOfWarcraft.Entities.WowClasses.Priest;
using Xylox.WorldOfWarcraft.Entities.WowClasses.Rogue;
using Xylox.WorldOfWarcraft.Entities.WowClasses.Shaman;
using Xylox.WorldOfWarcraft.Entities.WowClasses.Warlock;
using Xylox.WorldOfWarcraft.Entities.WowClasses.Warrior;

namespace Xylox.WorldOfWarcraft.Entities
{
    public class Classes
    {
        public DeathKnight DeathKnight { get; set; } = new DeathKnight();
        public DemonHunter DemonHunter { get; set; } = new DemonHunter();
        public Druid Druid { get; set; } = new Druid();
        public Hunter Hunter { get; set; } = new Hunter();
        public Mage Mage { get; set; } = new Mage();
        public Monk Monk { get; set; } = new Monk();
        public Paladin Paladin { get; set; } = new Paladin();
        public Priest Priest { get; set; } = new Priest();
        public Rogue Rogue { get; set; } = new Rogue();
        public Shaman Shaman { get; set; } = new Shaman();
        public Warlock Warlock { get; set; } = new Warlock();
        public Warrior Warrior { get; set; } = new Warrior();
    }
}
