using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Victoria;
using Victoria.Enums;
using Victoria.EventArgs;
using Xylox.Services;
using Xylox.Services.Entities;

namespace Xylox.Audio
{
    public class MusicService : IMusicService
    {
        private readonly LavaNode _lavaNode;
        private readonly DiscordSocketClient _discordClient;
        private readonly IXyloxLogger _logger;

        public MusicService(LavaNode lavaNode, DiscordSocketClient discordClient, IXyloxLogger logger)
        {
            _lavaNode = lavaNode;
            _discordClient = discordClient;
            _logger = logger;

            _lavaNode.OnTrackEnded += TrackEndedAsync;
            _lavaNode.OnLog += LogAsync;
        }

        public async Task InitializeWhenReadyAsync()
        {
            await _lavaNode.ConnectAsync();
        }

        public async Task<string> JoinAsync(ulong voiceId, ulong textId)
        {
            var voiceChannel = GetDiscordChannel<IVoiceChannel>(voiceId);
            var textChannel = GetDiscordChannel<ITextChannel>(textId);

            await _lavaNode.JoinAsync(voiceChannel, textChannel);

            return $"Joined {voiceChannel.Name}, bound to {textChannel.Name}";
        }

        public async Task<string> LeaveAsync(ulong voiceId)
        {
            var voiceChannel = GetDiscordChannel<IVoiceChannel>(voiceId);
            await _lavaNode.LeaveAsync(voiceChannel);

            return $"Now Left {voiceChannel.Name}";
        }

        public Task <IEnumerable<IXyloxTrack>> GetPlaylistAsync(ulong id)
        {
            var guild = GetGuild(id);
            var tracks = new List<IXyloxTrack>();
            

            if (_lavaNode.TryGetPlayer(guild, out var player))
            {
                foreach (var track in player.Queue.Items)
                {
                    var xyTrack = ConvertTrackToXyloxTrack(track, true);
                    tracks.Add(xyTrack);
                }
            }

            return Task.FromResult((IEnumerable<IXyloxTrack>)tracks);
        }

        public async Task<string> PauseAsync(ulong id)
        {
            var guild = GetGuild(id);

            if (_lavaNode.TryGetPlayer(guild, out var player))
            {
                if (player.PlayerState is PlayerState.Paused)
                {
                    return "Unable to pause, player is already paused. Did you mean to resume?";
                }
                else
                {
                    await player.PauseAsync();
                    return "Player now paused";
                }
            }

            return "Error when trying to pause, please contact my creator.";
        }

        public async Task<IXyloxTrack> PlayTrackAsync(string query, ulong id)
        {
            var search = await _lavaNode.SearchYouTubeAsync(query);
            var track = search.Tracks.FirstOrDefault();
            var guild = GetGuild(id);

            if (_lavaNode.TryGetPlayer(guild, out var player))
            {
                if (player.PlayerState is PlayerState.Playing)
                {
                    player.Queue.Enqueue(track);
                    return ConvertTrackToXyloxTrack(track, true);
                }
                else
                {
                    await player.PlayAsync(track);
                    return ConvertTrackToXyloxTrack(track, false);
                }
            }

            return new BlankXyloxTrack();
        }

        public async Task<string> ResumeAsync(ulong id)
        {
            var guild = GetGuild(id);

            if (_lavaNode.TryGetPlayer(guild, out var player))
            {
                if (player.PlayerState is PlayerState.Paused)
                {
                    await player.ResumeAsync();
                    return "Player has now resumed.";
                }
                else
                {
                    return "Unable to resume, player is already playing. Did you mean to pause?";
                }
            }

            return "Error when trying to resume, please contact my creator.";
        }

        public async Task<string> SetVolumeAsync(int level, ulong id)
        {
            var guild = GetGuild(id);

            if (_lavaNode.TryGetPlayer(guild, out var player))
            {
                if (IsValidVolume(level))
                {
                    await player.UpdateVolumeAsync((ushort)level);
                    return $"Player volume set to {level}%";
                }
                else
                {
                    return $"Something went wrong. Please ensure level is between 1 - 100.";
                }
            }

            return "Error trying to set volume, please contact my creator.";
        }

        public Task<IXyloxTrack> SkipTrackAsync(int trackId, ulong id)
        {
            throw new NotImplementedException();
        }

        public async Task<IXyloxTrack> SkipTrackAsync(ulong id)
        {
            var guild = GetGuild(id);

            if (_lavaNode.TryGetPlayer(guild, out var player))
            {
                if (player.Queue.Count < 1)
                {
                    return new BlankXyloxTrack();
                }
                else
                {
                    await player.SkipAsync();
                    var track = ConvertTrackToXyloxTrack(player.Track, false);
                    return track;
                }
            }

            return new BlankXyloxTrack();
        }

        public async Task<string> StopAsync(ulong id)
        {
            var guild = GetGuild(id);

            if (_lavaNode.TryGetPlayer(guild, out var player))
            {
                if (player.PlayerState is PlayerState.Playing)
                {
                    await player.StopAsync();
                    return "Player has now stopped playing.";
                }
                else
                {
                    return "Player didn't seem to be playing anything.";
                }
            }
            else
            {
                return "Error stopping player, please contact my creator.";
            }
        }

        private async Task TrackEndedAsync(TrackEndedEventArgs trackEndArgs)
        {
            if (!trackEndArgs.Reason.ShouldPlayNext())
                return;

            if (!trackEndArgs.Player.Queue.TryDequeue(out var track))
                await trackEndArgs.Player.TextChannel.SendMessageAsync("Playback Finised");

            var embed = new EmbedBuilder()
                .WithColor(Color.Green)
                .WithTitle("Music Service")
                .WithDescription(
                    $"Title: {track.Title}\n" +
                    $"Author: {track.Author}\n" +
                    $"Duration: {track.Duration.ToString("h'h 'm'm 's's'")}\n\n" +
                    $"Url: [Youtube]({track.Url})")
                .WithThumbnailUrl($"https://img.youtube.com/vi/{track.Id}/maxresdefault.jpg");

            await trackEndArgs.Player.PlayAsync(track);
            await trackEndArgs.Player.TextChannel.SendMessageAsync(embed: embed.Build());
        }

        private async Task LogAsync(LogMessage arg)
        {
            var log = ConvertToXyloxLog(arg);
            await _logger.LogAsync(log);
        }

        private T GetDiscordChannel<T>(ulong id)
        {
            var channel = _discordClient.GetChannel(id);

            if (channel is T returnChannel)
                return returnChannel;
            else
                throw new InvalidCastException($"Music Service: Could not cast channel to {typeof(T)}");
        }

        private IGuild GetGuild(ulong id)
        {
            if (!(_discordClient.GetGuild(id) is IGuild guild))
                throw new InvalidCastException("Music Service: Unable to cast guild to IGuild");

            return guild;
        }

        private bool IsValidVolume(int level)
        {
            if (level < 1 || level > 100)
                return false;
            else
                return true;
        }

        private XyloxTrack ConvertTrackToXyloxTrack(LavaTrack track, bool isQueued)
            => new XyloxTrack
            {
                Id = track.Id,
                Title = track.Title,
                Author = track.Author,
                Duration = track.Duration,
                Url = track.Url,
                IsQueued = isQueued
            };

        private XyloxLog ConvertToXyloxLog(LogMessage discordLog)
            => new XyloxLog
            {
                Source = discordLog.Source,
                Message = discordLog.Message
            };
    }
}
