using System.Threading.Tasks;
using Xylox.Services.Entities;

namespace Xylox.Services
{
    public interface IXyloxLogger
    {
        Task LogAsync(XyloxLog arg);
    }
}
