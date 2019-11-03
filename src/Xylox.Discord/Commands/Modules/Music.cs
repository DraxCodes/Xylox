using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xylox.Discord.Helpers.Embeds;
using Xylox.Services;
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

        private async Task<bool> UserIsInVoiceChannelAsync(SocketVoiceChannel channel)
        {
            if (channel is null)
            {
                var embed = _embedFactory.Generate(EmbedType.Error, _serviceName, "Please join a voice channel before you request the bot join.");
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
