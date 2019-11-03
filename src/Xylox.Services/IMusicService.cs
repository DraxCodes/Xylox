using System.Collections.Generic;
using System.Threading.Tasks;
using Xylox.Services.Entities;

namespace Xylox.Services
{
    public interface IMusicService
    {
        Task InitializeWhenReadyAsync();
        Task<IEnumerable<IXyloxTrack>> GetPlaylistAsync(ulong guildId);
        Task<IXyloxTrack> PlayTrackAsync(string query, ulong guildId);
        Task<IXyloxTrack> SkipTrackAsync(int trackId, ulong guildId);
        Task<IXyloxTrack> SkipTrackAsync(ulong guildId);
        Task<string> JoinAsync(ulong voiceId, ulong textId);
        Task<string> LeaveAsync(ulong voiceId);
        Task<string> PauseAsync(ulong guildId);
        Task<string> ResumeAsync(ulong guildId);
        Task<string> StopAsync(ulong guildId);
        Task<string> SetVolumeAsync(int level, ulong guildId);
    }
}
