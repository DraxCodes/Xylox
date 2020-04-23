using System;

namespace Xylox.WorldOfWarcraft.Entities
{
    public class Class
    {
        public string Name { get; set; } = string.Empty;
        public Uri LevelingGuideUrl { get; set; } = new Uri("https://placeholder.com/");
        public Uri WeakAuraUrl { get; set; } = new Uri("https://placeholder.com/");
    }
}
