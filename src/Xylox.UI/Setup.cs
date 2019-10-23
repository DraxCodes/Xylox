using Ninject;
using Ninject.Modules;
using Xylox.Discord;
using Xylox.Discord.Config;

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
            Bind<XyloxDiscord>().ToSelf().InSingletonScope();
            Bind<IXyloxConfig>().To<XyloxConfig>().InSingletonScope();
        }
    }
}
