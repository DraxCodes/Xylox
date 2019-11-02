using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xylox.Services;
using Xylox.Services.Entities;

namespace Xylox.Audio
{
    public class MusicService : IMusicService
    {
        public Task<string> ConnectAsync(ulong voiceChannel, ulong textChannel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<XyloxTrack>> GetPlaylistAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<string> PauseAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<XyloxTrack> PlayTrackAsync(string query, ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<XyloxTrack> PlayTrackAsync(Uri uri, ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<string> ResumeAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<string> SetVolumeAsync(int level, ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<XyloxTrack> SkipTrackAsync(int trackId, ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<XyloxTrack> SkipTrackAsync(ulong id)
        {
            throw new NotImplementedException();
        }

        public Task<string> StopAsync(ulong id)
        {
            throw new NotImplementedException();
        }
    }
}
