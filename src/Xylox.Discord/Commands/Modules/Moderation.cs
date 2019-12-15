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
            [Name("Reason")] [Summary("The reason you are kicking the user.")]string reason)
        {
            await user.KickAsync(reason);
            await ReplyAsync($"{user.Mention} has been kicked for: {reason}.\n" +
                $"User kicked by {Context.User.Mention}.");
        }

        [Command("Ban")]
        [RequireBotPermission(GuildPermission.BanMembers)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task BanCommand(
            [Name("User")] [Summary("The user you wish to ban.")] SocketGuildUser user,
            [Name("Reason")] [Summary("The reason you are banning the user.")]string reason)
        {
            await user.BanAsync(reason: reason);
            await ReplyAsync($"{user.Mention} has been banned for: {reason}.\n" +
                $"User Banned by {Context.User.Mention}.");
        }
    }
}
