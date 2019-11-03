using System.Collections.Generic;
using System.Threading.Tasks;
using Xylox.Services.Entities;

namespace Xylox.Services
{
    public interface IMusicService
    {
        Task InitializeWhenReadyAsync();
        Task<IEnumerable<IXyloxTrack>> GetPlaylistAsync(ulong id);
        Task<IXyloxTrack> PlayTrackAsync(string query, ulong id);
        Task<IXyloxTrack> SkipTrackAsync(int trackId, ulong id);
        Task<IXyloxTrack> SkipTrackAsync(ulong id);
        Task<string> JoinAsync(ulong voiceId, ulong textId);
        Task<string> LeaveAsync(ulong voiceId);
        Task<string> PauseAsync(ulong id);
        Task<string> ResumeAsync(ulong id);
        Task<string> StopAsync(ulong id);
        Task<string> SetVolumeAsync(int level, ulong id);
    }
}
