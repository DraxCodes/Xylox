using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using Xylox.Discord.Helpers.Embeds;
using EmbedType = Xylox.Discord.Helpers.Embeds.EmbedType;

namespace Xylox.Discord.Commands.Modules
{
    public class Ping : XyloxModuleBase
    {
        private readonly EmbedFactory _embedFactory;

        public Ping(EmbedFactory embedFactory)
        {
            _embedFactory = embedFactory;
        }

        [Command("Ping")]
        public async Task PingCommand(string message)
        {
            var embed = _embedFactory.Generate(EmbedType.Success, $"Ohia {Context.User.Username}#{Context.User.Discriminator}", $"Pong! {message}");

            await ReplyEmbedAsync(embed);
        }
    }
}
