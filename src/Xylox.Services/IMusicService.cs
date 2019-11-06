using System.Collections.Generic;
using System.Threading.Tasks;
using Xylox.Services.Entities;

namespace Xylox.Services
{
    public interface IMusicService
    {
        Task InitializeWhenReadyAsync();
        Task<IEnumerable<IXyloxServiceResult>> GetPlaylistAsync(ulong guildId);
        Task<IXyloxServiceResult> PlayTrackAsync(string query, ulong guildId);
        Task<IXyloxServiceResult> SkipTrackAsync(int trackId, ulong guildId);
        Task<IXyloxServiceResult> SkipTrackAsync(ulong guildId);
        Task<IXyloxServiceResult> JoinAsync(ulong guildId, ulong voiceId, ulong textId);
        Task<IXyloxServiceResult> LeaveAsync(ulong voiceId);
        Task<IXyloxServiceResult> PauseAsync(ulong guildId);
        Task<IXyloxServiceResult> ResumeAsync(ulong guildId);
        Task<IXyloxServiceResult> StopAsync(ulong guildId);
        Task<IXyloxServiceResult> SetVolumeAsync(int level, ulong guildId);
        Task<bool> UserIsInSameVoiceChannel(ulong guildId, ulong userVoiceId);
    }
}
