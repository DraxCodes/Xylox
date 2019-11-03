using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using Xylox.Discord.Commands;
using Xylox.Discord.Config;
using Xylox.Services;

namespace Xylox.Discord
{
    public class XyloxDiscord
    {
        public readonly DiscordSocketClient _discordClient;
        private readonly CommandHandler _commandHandler;
        private readonly Logger _logger;
        private readonly IXyloxConfig _xyloxConfig;
        private readonly XyConf _xyConf;
        private readonly IMusicService _musicService;

        public XyloxDiscord(DiscordSocketClient discordClient, CommandHandler commandHandler,
            Logger logger, IXyloxConfig xyloxConfig, IMusicService musicService)
        {
            _discordClient = discordClient;
            _commandHandler = commandHandler;
            _logger = logger;
            _xyloxConfig = xyloxConfig;
            _musicService = musicService;

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
            _discordClient.Ready += OnReadyAsync;
            _discordClient.Log += _logger.LogAsync;
        }

        private async Task OnReadyAsync()
        {
            await _discordClient.SetStatusAsync(UserStatus.Idle);
            await _discordClient.SetGameAsync(name: _xyConf.Status, type: ActivityType.Listening);
            await _musicService.InitializeWhenReadyAsync();
        }
    }
}
