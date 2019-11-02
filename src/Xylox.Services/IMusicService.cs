using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xylox.Services.Entities;

namespace Xylox.Services
{
    public interface IMusicService
    {
        Task<IEnumerable<XyloxTrack>> GetPlaylistAsync(ulong id);
        Task<XyloxTrack> PlayTrackAsync(string query, ulong id);
        Task<XyloxTrack> PlayTrackAsync(Uri uri, ulong id);
        Task<XyloxTrack> SkipTrackAsync(int trackId, ulong id);
        Task<XyloxTrack> SkipTrackAsync(ulong id);
        Task<string> ConnectAsync(ulong voiceChannel, ulong textChannel);
        Task<string> PauseAsync(ulong id);
        Task<string> ResumeAsync(ulong id);
        Task<string> StopAsync(ulong id);
        Task<string> SetVolumeAsync(int level, ulong id);
    }
}
