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
        public async Task PingCommand(
            [Name("Message")] [Summary("The message to echo back.")] string message)
        {
            var embed = _embedFactory.Generate(
                requestedType: EmbedType.Success, 
                title: $"Ohia {Context.User.ToString()}", 
                description: $"Pong! {message}");

            await ReplyEmbedAsync(embed);
        }
    }
}
