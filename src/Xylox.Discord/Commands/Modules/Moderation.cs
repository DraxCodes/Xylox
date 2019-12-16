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
            await user.BanAsync(pruneDays: 7, reason: reason);
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

        [Command("Purge", RunMode = RunMode.Async)]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Purge(
            [Name("Amount")] [Summary("The amount of messages you wish to purge. (Default 20)")] int amount = 20)
        {
            var textChannel = Context.Channel as SocketTextChannel;
            var messages = await FecthAndVerifyMessages(textChannel, amount);
            await textChannel.DeleteMessagesAsync(messages);

            var reply = await ReplyAsync($"{amount} messages deleted.");
            await Task.Delay(TimeSpan.FromSeconds(3));
            await reply.DeleteAsync();
        }

        [Command("PurgeUser")]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task PurgeUserCommand(
            [Name("User")] [Summary("The user you wish to purge messages for.")] SocketGuildUser user,
            [Name("Amount")] [Summary("The amount of messages to purge.")] int amount)
        {
            var textChannel = Context.Channel as SocketTextChannel;
            var userMessages = await FecthAndVerifyMessages(textChannel, amount, user.Id);
            await textChannel.DeleteMessagesAsync(userMessages);

            var reply = await ReplyAsync($"{amount} messages purged for {user.Mention}.");
            await Task.Delay(TimeSpan.FromSeconds(3));
            await reply.DeleteAsync();
        }

        [Command("PurgeBot")]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task PurgeBotCommand()
        {
            var textChannel = Context.Channel as SocketTextChannel;
            var botMessages = await FecthAndVerifyMessages(textChannel, 100, Context.Client.CurrentUser.Id);
            await textChannel.DeleteMessagesAsync(botMessages);

            var reply = await ReplyAsync("Xylox Messages Purged");
            await Task.Delay(TimeSpan.FromSeconds(3));
            await reply.DeleteAsync();
        }

        private async Task<IEnumerable<IMessage>> FecthAndVerifyMessages(SocketTextChannel channel, int amount)
        {
            var oldestAllowedTimestamp = DateTime.Now.AddDays(-14);
            var channelMessages = await channel.GetMessagesAsync(amount).FlattenAsync();
            return channelMessages.Where(m => m.CreatedAt > oldestAllowedTimestamp);
        }

        private async Task<IEnumerable<IMessage>> FecthAndVerifyMessages(SocketTextChannel channel, int amount, ulong userId)
        {
            var channelMessages = await FecthAndVerifyMessages(channel, 100);
            var userMessages = channelMessages.Where(m => m.Author.Id == userId);
            var orderedMessages = userMessages.OrderBy(m => m.CreatedAt);

            return orderedMessages.Take(amount);
        }
    }
}
