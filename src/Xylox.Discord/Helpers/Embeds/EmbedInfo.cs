using Discord;

namespace Xylox.Discord.Helpers.Embeds
{
    public class EmbedInfo
    {
        public EmbedType Type { get; set; }
        public Color Color { get; set; }

        public EmbedInfo() { }

        public EmbedInfo(EmbedType type, Color color)
        {
            Type = type;
            Color = color;
        }
    }
}
