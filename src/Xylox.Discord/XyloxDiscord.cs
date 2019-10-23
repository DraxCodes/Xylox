using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using Xylox.Discord.Commands;
using Xylox.Discord.Config;

namespace Xylox.Discord
{
    public class XyloxDiscord
    {
        private readonly DiscordSocketClient _discordClient;
        private readonly CommandHandler _commandHandler;
        private readonly Logger _logger;
        private readonly IXyloxConfig _xyloxConfig;
        private readonly XyConf _xyConf;

        public XyloxDiscord(DiscordSocketClient discordClient, CommandHandler commandHandler, Logger logger, IXyloxConfig xyloxConfig)
        {
            _discordClient = discordClient;
            _commandHandler = commandHandler;
            _logger = logger;
            _xyloxConfig = xyloxConfig;
            _xyConf = _xyloxConfig.GetConfig();
        }


        public async Task Run()
        {
            HookEvents();

            await _discordClient.LoginAsync(TokenType.Bot, _xyConf.Token);
            await _discordClient.StartAsync();
            await _commandHandler.InitializeAsync();

            await Task.Delay(-1);
        }

        private void HookEvents()
        {
            _discordClient.Log += _logger.LogAsync;
        }
    }
}
