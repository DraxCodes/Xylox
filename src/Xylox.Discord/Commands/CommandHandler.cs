using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ninject;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xylox.Discord.Config;
using Xylox.Discord.Helpers.Embeds;
using EmbedType = Xylox.Discord.Helpers.Embeds.EmbedType;

namespace Xylox.Discord.Commands
{
    public class CommandHandler
    {
        private readonly CommandService _commandService;
        private readonly DiscordSocketClient _discordClient;
        private readonly IKernel _kernel;
        private readonly IXyloxConfig _xyloxConfig;
        private readonly XyConf _xyConf;
        private readonly EmbedFactory _embedFactory;

        public CommandHandler(CommandService commandService, DiscordSocketClient discordClient, IKernel kernel, IXyloxConfig xyloxConfig, EmbedFactory embedFactory)
        {
            _commandService = commandService;
            _discordClient = discordClient;
            _kernel = kernel;
            _xyloxConfig = xyloxConfig;
            _xyConf = _xyloxConfig.GetConfig();
            _embedFactory = embedFactory;
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
                EmbedBuilder embed;

                if (result.Error.Value == CommandError.BadArgCount)
                {
                    string usage;
                    if (command.Value.Parameters is null)
                    {
                        usage = $"xy.{command.Value.Name}";
                    }
                    else
                    {
                        var sb = new StringBuilder()
                            .Append($"xy.{command.Value.Name} ");
                        foreach (var item in command.Value.Parameters)
                        {
                            sb.Append($"{item.Name} ");
                        }

                        usage = sb.ToString();
                    }

                    embed = _embedFactory.Generate(EmbedType.Error, "Bad Arg Count", $"Usage: {usage}");
                }
                else
                {
                    embed = _embedFactory.Generate(EmbedType.Error, "Error", result.ErrorReason);
                }
                

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
