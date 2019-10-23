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
            var embed = new EmbedBuilder()
                .WithAuthor($"Ohia {Context.User.Username}#{Context.User.Discriminator}")
                .WithDescription("Pong!")
                .WithColor(Color.DarkMagenta);

            await ReplyEmbedAsync(embed);
        }
    }
}
