using Ninject;
using System;
using System.Threading.Tasks;
using Xylox.Discord;

namespace Xylox.UI
{
    internal sealed class Program
    {
        private static async Task Main(string[] args)
        {
            var setup = Activator.CreateInstance<Setup>();
            await setup.Kernal.Get<XyloxDiscord>().Run();
        }
    }
}
