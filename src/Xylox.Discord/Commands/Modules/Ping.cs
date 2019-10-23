using Discord.Commands;
using System.Threading.Tasks;

namespace Xylox.Discord.Commands.Modules
{
    public class Ping : ModuleBase<SocketCommandContext>
    {
        [Command("Ping")]
        public async Task PingCommand()
        {
            await ReplyAsync("Pong!");
        }
    }
}
