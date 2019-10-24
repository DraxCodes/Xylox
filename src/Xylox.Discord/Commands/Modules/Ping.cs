using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace Xylox.Discord.Commands.Modules
{
    public class Ping : XyloxModuleBase
    {
        [Command("Ping")]
        public async Task PingCommand()
        {
            Context.Embed
                .WithAuthor($"Ohia {Context.User.ToString()}")
                .WithDescription("Pong!")
                .WithColor(Color.DarkMagenta);

            await ReplyEmbedAsync(Context.Embed);
        }
    }
}
