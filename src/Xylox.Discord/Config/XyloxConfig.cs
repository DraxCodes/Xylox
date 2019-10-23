using Newtonsoft.Json;
using System.IO;

namespace Xylox.Discord.Config
{
    public class XyloxConfig : IXyloxConfig
    {
        public XyConf GetConfig()
        {
            var json = File.ReadAllText("config.json");
            return JsonConvert.DeserializeObject<XyConf>(json);
        }
    }
}
