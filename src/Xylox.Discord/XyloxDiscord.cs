using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using Xylox.Discord.Commands;
using Xylox.Discord.Config;
using Xylox.Services;
using Xylox.Services.Entities;

namespace Xylox.Discord
{
    public class XyloxDiscord
    {
        public readonly DiscordSocketClient _discordClient;
        private readonly CommandHandler _commandHandler;
        private readonly IXyloxLogger _logger;
        private readonly IXyloxConfig _xyloxConfig;
        private readonly XyConf _xyConf;
        private readonly IMusicService _musicService;

        public XyloxDiscord(DiscordSocketClient discordClient, CommandHandler commandHandler,
            IXyloxLogger logger, IXyloxConfig xyloxConfig, IMusicService musicService)
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
            _discordClient.Log += LogAsync;
        }

        private async Task LogAsync(LogMessage arg)
        {
            var log = ConvertToXyloxLog(arg);
            await _logger.LogAsync(log);
        }

        private async Task OnReadyAsync()
        {
            await _discordClient.SetStatusAsync(UserStatus.Idle);
            await _discordClient.SetGameAsync(name: _xyConf.Status, type: ActivityType.Listening);

            await InitializeAudio();
        }

        private Task InitializeAudio()
            => _xyConf.AudioIsEnabled ? _musicService.InitializeWhenReadyAsync() : Task.CompletedTask;

        private XyloxLog ConvertToXyloxLog(LogMessage discordLog)
            => new XyloxLog
            {
                Source = discordLog.Source,
                Message = discordLog.Message
            };
    }
}
