using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ninject;
using Ninject.Modules;
using Victoria;
using Xylox.Audio;
using Xylox.Discord;
using Xylox.Discord.Commands;
using Xylox.Discord.Config;
using Xylox.Discord.Helpers.Embeds;
using Xylox.Services;

namespace Xylox.UI
{
    internal sealed class Setup
    {
        public readonly IKernel Kernal;
        public Setup()
        {
            Kernal = new StandardKernel(new XyloxModule());
        }
    }

    internal sealed class XyloxModule : NinjectModule
    {


        public override void Load()
        {
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

            Bind<XyloxDiscord>().ToSelf().InSingletonScope();
            Bind<EmbedFactory>().ToSelf().InTransientScope();
            Bind<CommandErrorHandler>().ToSelf().InTransientScope();
            Bind<IXyloxLogger>().To<Logger>().InSingletonScope();
            Bind<CommandHandler>().ToSelf().InSingletonScope();
            Bind<IXyloxConfig>().To<XyloxConfig>().InSingletonScope();

            Bind<DiscordSocketClient>().ToSelf().InSingletonScope().WithConstructorArgument("config", clientConfig);
            Bind<CommandService>().ToSelf().InSingletonScope().WithConstructorArgument("config", commandConfig);

            Bind<LavaNode>().ToSelf().InSingletonScope();
            Bind<LavaConfig>().ToSelf().InSingletonScope();
            Bind<IMusicService>().To<MusicService>().InSingletonScope();
        }
    }
}
