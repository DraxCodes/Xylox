using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Xylox.Discord.Commands
{
    public sealed class XyloxCommandContext : SocketCommandContext
    {
        public new SocketGuildUser User { get; }
        public new ITextChannel Channel { get; }
        public EmbedBuilder Embed { get; }

        public XyloxCommandContext(DiscordSocketClient client, SocketUserMessage msg) : base(client, msg)
        {
            User = msg.Author as SocketGuildUser;
            Channel = msg.Channel as ITextChannel;
            Embed = new EmbedBuilder();
        }
    }
}
