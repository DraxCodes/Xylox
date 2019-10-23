using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ninject;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Xylox.Discord.Config;

namespace Xylox.Discord.Commands
{
    public class CommandHandler
    {
        private readonly CommandService _commandService;
        private readonly DiscordSocketClient _discordClient;
        private readonly IKernel _kernel;
        private readonly IXyloxConfig _xyloxConfig;
        private readonly XyConf _xyConf;

        public CommandHandler(CommandService commandService, DiscordSocketClient discordClient, IKernel kernel, IXyloxConfig xyloxConfig)
        {
            _commandService = commandService;
            _discordClient = discordClient;
            _kernel = kernel;
            _xyloxConfig = xyloxConfig;
            _xyConf = _xyloxConfig.GetConfig();
        }

        {
            _bot = bot;
            _commandService = _bot.CommandService;
        }
    }
}
