using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xylox.Discord.Helpers.Embeds;
using EmbedType = Xylox.Discord.Helpers.Embeds.EmbedType;

namespace Xylox.Discord.Commands
{
    public class CommandErrorHandler
    {
        private readonly EmbedFactory _embedFactory;

        public CommandErrorHandler(EmbedFactory embedFactory)
        {
            _embedFactory = embedFactory;
        }

        public Embed HandleCommandBadArgCount(CommandInfo commandInfo)
        {
            var usage = GenerateCommandUsageInfo(commandInfo);

            var embed = _embedFactory.Generate(
                requestedType: EmbedType.Error, 
                title: "⚠ Bad Arg Count", 
                description: usage);

            embed.Footer = new EmbedFooterBuilder { Text = "Required: <>, Optional: []" };

            return embed.Build();
        }

        public Embed HandleCommandParseFailed(CommandInfo commandInfo)
        {
            var usage = GenerateCommandUsageInfo(commandInfo);

            var embed = _embedFactory.Generate(
                requestedType: EmbedType.Error,
                title: "⚠ Command Parse Failed",
                description: usage);

            return embed.Build();
        }

        public async Task<Embed> HandleCommandUnmetPrecondition(ICommandContext context, CommandInfo commandInfo)
        {
            var preconditonMessage = await commandInfo.CheckPreconditionsAsync(context); /*await GeneratePreconditionList(context, commandInfo);*/

            var embed = _embedFactory.Generate(
                requestedType: EmbedType.Error,
                title: "⚠ Unmet Preconditons",
                description: preconditonMessage.ErrorReason);

            return embed.Build();
        }

        public Embed HandleCommandThrownException(CommandInfo commandInfo)
        {
            var embed = _embedFactory.Generate(
                requestedType: EmbedType.Error,
                title: "⚠ Command Exception",
                description: $"Command [{commandInfo.Name}] threw an excpetion. Please contact <Draxis#0359>");

            return embed.Build();
        }

        public Embed HandlerCommandUnseccesfulInvoke(CommandInfo commandInfo)
        {
            var embed = _embedFactory.Generate(
                requestedType: EmbedType.Error,
                title: "⚠ Command Error",
                description: $"Invocation of command [{commandInfo.Name}] was unable to complete. \nPlease contact <Draxis#0359>");

            return embed.Build();
        }

        public Embed HandlerCommandUnknownError(CommandInfo commandInfo)
        {
            var embed = _embedFactory.Generate(
                requestedType: EmbedType.Error,
                title: "⚠ Command Error",
                description: $"Invocation of command [{commandInfo.Name}] threw an unhandled error. \nPlease contact <Draxis#0359>");

            return embed.Build();
        }

        private string GenerateCommandUsageInfo(CommandInfo commandInfo)
        {
            string usage;

            if (commandInfo.Parameters is null)
            {
                usage = $"Usage: xy.{commandInfo.Name}";
            }
            else
            {
                var sb = new StringBuilder()
                    .Append($"**Command Information**\n" +
                    $"Usage: xy.{commandInfo.Name} ");

                var parameterSummaries = GenerateParameterSummaries(commandInfo.Parameters);

                foreach (var param in commandInfo.Parameters)
                {
                    if (param.IsOptional)
                    {
                        sb.Append($" [{param.Name}] ");
                    }
                    else
                    {
                        sb.Append($" **<{param.Name}>** ");
                    }
                }

                sb.Append(parameterSummaries);
                usage = sb.ToString();
            }

            return usage;
        }

        private string GenerateParameterSummaries(IReadOnlyList<ParameterInfo> parameterInfos)
        {
            var sb = new StringBuilder();
            sb.Append("\n\n**Parameter Summaries**\n");

            foreach (var parameter in parameterInfos)
            {
                sb.Append($"{parameter.Name}: *{parameter.Summary}*\n");
            }

            return sb.ToString();
        }

        private async Task<string> GeneratePreconditionList(ICommandContext context, CommandInfo commandInfo)
        {
            var preconditions = commandInfo.Preconditions;
            var sb = new StringBuilder();

            var test = await commandInfo.CheckPreconditionsAsync(context);

            foreach (var precondtion in preconditions)
            {
                sb.Append($"{precondtion.Group}\n");
            }

            return sb.ToString();
        }
    }
}
