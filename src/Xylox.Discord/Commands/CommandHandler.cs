using Discord.Commands;

namespace Xylox.Discord.Commands
{
    public class CommandHandler
    {
        private readonly XyloxDiscord _bot;
        private readonly CommandService _commandService;
        public CommandHandler(XyloxDiscord bot)
        {
            _bot = bot;
            _commandService = _bot.CommandService;
        }
    }
}
