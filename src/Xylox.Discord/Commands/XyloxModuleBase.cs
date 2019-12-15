using Discord;
using Discord.Commands;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xylox.Discord.Commands
{
    public class XyloxModuleBase : ModuleBase<XyloxCommandContext>
    {
        protected Task ReplyEmbedAsync(EmbedBuilder embed)
            => Context.Channel.SendMessageAsync(embed: embed.Build());

        protected Task BulkDeleteAsync(IEnumerable<IMessage> messages)
            => Context.Channel.DeleteMessagesAsync(messages);
    }
}
