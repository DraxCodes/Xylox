using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using Xylox.Discord.Config;

namespace Xylox.Discord
{
    public class XyloxDiscord
    {
        public readonly DiscordSocketClient DiscordClient;
        public readonly CommandService CommandService;
        private readonly IXyloxConfig _xyloxConfig;
        private readonly XyConf _xyConf;

        public XyloxDiscord(IXyloxConfig xyloxConfig)
        {
            _xyloxConfig = xyloxConfig;
            _xyConf = _xyloxConfig.GetConfig();

            var clientConfig = new DiscordSocketConfig
            {
                AlwaysDownloadUsers = true,
                LogLevel = LogSeverity.Verbose,
                ExclusiveBulkDelete = true,
                MessageCacheSize = 50
            };

            var commandConfig = new CommandServiceConfig 
            {
                CaseSensitiveCommands = false
            };
            
            DiscordClient = new DiscordSocketClient(clientConfig);
            CommandService = new CommandService(commandConfig);
        }


        public async Task Run()
        {
            HookEvents();

            await DiscordClient.LoginAsync(TokenType.Bot, _xyConf.Token);
            await DiscordClient.StartAsync();

            await Task.Delay(-1);
        }

        private void HookEvents()
        {
            DiscordClient.Log += LogAsync;
        }

        private Task LogAsync(LogMessage log)
        {
            System.Console.WriteLine(log.Message);
            return Task.CompletedTask;
        }
    }
}
