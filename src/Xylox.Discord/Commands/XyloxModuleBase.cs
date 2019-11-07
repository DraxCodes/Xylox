using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace Xylox.Discord.Commands
{
    public class XyloxModuleBase : ModuleBase<XyloxCommandContext>
    {
        protected async Task ReplyEmbedAsync(EmbedBuilder embed)
            => await Context.Channel.SendMessageAsync(embed: embed.Build());
    }
}
