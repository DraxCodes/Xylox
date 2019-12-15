using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
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
            await user.BanAsync(pruneDays: 7 ,reason: reason);
            await ReplyAsync($"{user.Mention} has been banned for: {reason}.\n" +
                $"User Banned by {Context.User.Mention}.");
        }

        [Command("SoftBan")]
        [RequireBotPermission(GuildPermission.BanMembers)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task SoftBanCommand(
            [Name("User")] [Summary("The user you wish to soft ban.")] SocketGuildUser user)
        {
            await user.BanAsync(pruneDays: 7);
            await ReplyAsync($"{user.Mention} has been soft banned. 7 Days of messages pruned.");
            await Context.Guild.RemoveBanAsync(user);
        }

        [Command("Purge")]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Purge(
            [Name("User")] [Summary("The user you wish to purge.")] SocketGuildUser user,
            [Name("Amount")] [Summary("The amount of messages you wish to purge. (Default 20)")] int amount = 20)
        {
            if (Context.Channel is SocketTextChannel textChannel)
            {
                var messages = await FetchAndVerfiyMessages(textChannel, amount);
            }
            else
            {
                
            }
        }

        private async Task<IEnumerable<IMessage>> FetchAndVerfiyMessages(SocketTextChannel channel, int amount)
        {
            var oldestAllowedTimestamp = DateTime.Now.AddDays(-14);
            var channelMessages = await channel.GetMessagesAsync(amount).FlattenAsync();
            return channelMessages.Where(m => m.CreatedAt > oldestAllowedTimestamp);
        }
    }
}
