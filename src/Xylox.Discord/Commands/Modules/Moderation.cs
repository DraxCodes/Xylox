using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xylox.Discord.Commands.Modules
{
    public class Moderation : XyloxModuleBase
    {
        [Command("Kick")]
        [RequireBotPermission(GuildPermission.KickMembers)]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task KickCommand(
            [Name("User")] [Summary("The user you wish to kick.")] SocketGuildUser user,
            [Name("User")] [Summary("The reason you are kicking the user.")]string reason)
        {
            await user.KickAsync(reason);
            await ReplyAsync($"{user.Mention} has been kicked for: {reason}.");
        }
    }
}
