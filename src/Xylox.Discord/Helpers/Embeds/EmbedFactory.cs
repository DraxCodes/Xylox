using Discord;
using System.Collections.Generic;
using System.Linq;

namespace Xylox.Discord.Helpers.Embeds
{
    public class EmbedFactory
    {
        private readonly List<EmbedInfo> embedInformation = new List<EmbedInfo>
        {
            new EmbedInfo(EmbedType.Error, Color.Red),
            new EmbedInfo(EmbedType.Info, Color.Blue),
            new EmbedInfo(EmbedType.Success, Color.Green),
            new EmbedInfo(EmbedType.Warning, Color.LightOrange)
        };

        public EmbedBuilder Generate(EmbedType requestedType, string title, string description)
        {
            var embedInfo = embedInformation.FirstOrDefault(e => e.Type == requestedType);
            var embedResult = new EmbedBuilder()
                .WithTitle(title)
                .WithDescription(description)
                .WithColor(embedInfo.Color);

            return embedResult;
        }
    }


}
