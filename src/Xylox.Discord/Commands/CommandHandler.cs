using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ninject;
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
        private readonly CommandErrorHandler _commandErrorHandler;

        public CommandHandler(CommandService commandService, DiscordSocketClient discordClient, 
            IKernel kernel, IXyloxConfig xyloxConfig, 
            CommandErrorHandler commandErrorHandler)
        {
            _commandService = commandService;
            _discordClient = discordClient;
            _kernel = kernel;
            _xyloxConfig = xyloxConfig;
            _commandErrorHandler = commandErrorHandler;
            _xyConf = _xyloxConfig.GetConfig();
        }

        public async Task InitializeAsync()
        {
            await _commandService.AddModulesAsync(Assembly.GetExecutingAssembly(), _kernel);
            HookEvents();
        }

        private void HookEvents()
        {
            _discordClient.MessageReceived += HandleMessageAsync;
            _commandService.CommandExecuted += CommandExecutedAsync;
        }

        private async Task HandleMessageAsync(SocketMessage socketMessage)
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

        private async Task CommandExecutedAsync(Optional<CommandInfo> command, ICommandContext context, IResult result)
        {
            if (!command.IsSpecified)
                return;

            if (!result.IsSuccess)
            {
                Embed embed;

                switch (result.Error.Value)
                {
                    case CommandError.UnknownCommand:
                        return;
                    case CommandError.ParseFailed:
                        embed = _commandErrorHandler.HandleCommandParseFailed(command.Value);
                        break;
                    case CommandError.BadArgCount:
                        embed = _commandErrorHandler.HandleCommandBadArgCount(command.Value);
                        break;
                    case CommandError.UnmetPrecondition:
                        embed = await _commandErrorHandler.HandleCommandUnmetPrecondition(context, command.Value);
                        break;
                    case CommandError.Exception:
                        embed = _commandErrorHandler.HandleCommandThrownException(command.Value);
                        break;
                    case CommandError.Unsuccessful:
                        embed = _commandErrorHandler.HandlerCommandUnseccesfulInvoke(command.Value);
                        break;
                    default:
                        embed = _commandErrorHandler.HandlerCommandUnknownError(command.Value);
                        break;
                }

                await context.Channel.SendMessageAsync(embed: embed);
            }
        }
    }
}
