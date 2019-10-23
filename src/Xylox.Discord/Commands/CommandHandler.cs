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

        public async Task InitializeAsync()
        {
            await _commandService.AddModulesAsync(Assembly.GetExecutingAssembly(), _kernel);
            HookEvents();
        }

        private void HookEvents()
        {
            _discordClient.MessageReceived += HandlerMessageAsync;
            _commandService.CommandExecuted += CommandExecutedAsync;
        }

        private async Task CommandExecutedAsync(Optional<CommandInfo> command, ICommandContext context, IResult result)
        {
            if (!command.IsSpecified)
                return;

            if (!result.IsSuccess)
            {
                var embed = new EmbedBuilder()
                    .WithTitle("ERROR")
                    .WithDescription(result.ErrorReason)
                     .WithColor(Color.DarkRed);

                await context.Channel.SendMessageAsync(embed: embed.Build());
            }
        }

        private async Task HandlerMessageAsync(SocketMessage socketMessage)
        {
            if (!(socketMessage is SocketUserMessage message)) return;
            var argPos = 0;

            if (!(message.HasStringPrefix(_xyConf.Prefix, ref argPos)) ||
                message.Author.IsBot)
                return;

            var context = new XyloxCommandContext(_discordClient, message);

            await _commandService.ExecuteAsync(
                    context: context,
                    argPos: argPos,
                    services: _kernel);
        }
    }
}
