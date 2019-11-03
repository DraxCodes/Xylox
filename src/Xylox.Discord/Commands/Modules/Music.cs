using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xylox.Discord.Helpers.Embeds;
using Xylox.Services;
using Xylox.Services.Entities;
using EmbedType = Xylox.Discord.Helpers.Embeds.EmbedType;

namespace Xylox.Discord.Commands.Modules
{
    public class Music : XyloxModuleBase
    {
        private readonly IMusicService _musicService;
        private readonly EmbedFactory _embedFactory;
        private readonly string _serviceName = "Music Service";

        public Music(IMusicService musicService, EmbedFactory embedFactory)
        {
            _musicService = musicService;
            _embedFactory = embedFactory;
        }

        [Command("Join")]
        public async Task Join()
        {
            var voiceChannel = Context.User.VoiceChannel;

            if (!await UserIsInVoiceChannelAsync(voiceChannel)) { return; }

            var result = await _musicService.JoinAsync(voiceChannel.Id, Context.Message.Channel.Id);
            var embed = _embedFactory.Generate(EmbedType.Info, _serviceName, result);
            await ReplyEmbedAsync(embed);
        }

        [Command("Leave")]
        public async Task Leave()
        {
            var voiceChannel = Context.User.VoiceChannel;

            if (!await UserIsInVoiceChannelAsync(voiceChannel)) { return; }

            var result = await _musicService.LeaveAsync(voiceChannel.Id);
            var embed = _embedFactory.Generate(EmbedType.Info, _serviceName, result);
            await ReplyEmbedAsync(embed);
        }

        [Command("Play")]
        public async Task Play(
            [Remainder][Name("Query")][Summary("")]string query)
        {
            var voiceChannel = Context.User.VoiceChannel;

            if (!await UserIsInVoiceChannelAsync(voiceChannel)) { return; }
            if (!await _musicService.UserIsInSameVoiceChannel(Context.Guild.Id, voiceChannel.Id)) { return; }

            var trackResult = await _musicService.PlayTrackAsync(query, Context.Guild.Id);

            if (trackResult is XyloxTrack track)
            {
                var embed = new EmbedBuilder()
                    .WithColor(Color.Green)
                    .WithDescription(
                    $"Title: {track.Title}\n" +
                    $"Author: {track.Author}\n" +
                    $"Duration: {track.Duration.ToString("h'h 'm'm 's's'")}\n\n" +
                    $"Url: [Youtube]({track.Url})")
                    .WithThumbnailUrl($"https://img.youtube.com/vi/{track.Id}/maxresdefault.jpg");

                if (track.IsQueued)
                {
                    embed.Title = $"{_serviceName}, Track Queued";
                }
                else
                {
                    embed.Title = $"{_serviceName}, Now Playing";
                }

                await ReplyEmbedAsync(embed);
            }
            else
            {
                var embed = _embedFactory.Generate(EmbedType.Warning, _serviceName, $"Error trying to play {query}");
                await ReplyEmbedAsync(embed);
            }
        }

        [Command("Stop")]
        public async Task Stop()
        {
            var voiceChannel = Context.User.VoiceChannel;

            if (!await UserIsInVoiceChannelAsync(voiceChannel)) { return; }
            if (!await _musicService.UserIsInSameVoiceChannel(Context.Guild.Id, voiceChannel.Id)) { return; }

            var result = await _musicService.StopAsync(Context.Guild.Id);
            var embed = _embedFactory.Generate(EmbedType.Info, _serviceName, result);

            await ReplyEmbedAsync(embed);
        }

        [Command("Pause")]
        public async Task Pause()
        {
            var voiceChannel = Context.User.VoiceChannel;

            if (!await UserIsInVoiceChannelAsync(voiceChannel)) { return; }
            if (!await _musicService.UserIsInSameVoiceChannel(Context.Guild.Id, voiceChannel.Id)) { return; }

            var result = await _musicService.PauseAsync(Context.Guild.Id);
            var embed = _embedFactory.Generate(EmbedType.Info, _serviceName, result);

            await ReplyEmbedAsync(embed);
        }

        [Command("Resume")]
        public async Task Resume()
        {
            var voiceChannel = Context.User.VoiceChannel;

            if (!await UserIsInVoiceChannelAsync(voiceChannel)) { return; }
            if (!await _musicService.UserIsInSameVoiceChannel(Context.Guild.Id, voiceChannel.Id)) { return; }

            var result = await _musicService.ResumeAsync(Context.Guild.Id);
            var embed = _embedFactory.Generate(EmbedType.Info, _serviceName, result);

            await ReplyEmbedAsync(embed);
        }

        private async Task<bool> UserIsInVoiceChannelAsync(SocketVoiceChannel channel)
        {
            if (channel is null)
            {
                var embed = _embedFactory.Generate(EmbedType.Error, _serviceName, "Please join a voice channel before you request music service commands.");
                await ReplyEmbedAsync(embed);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
