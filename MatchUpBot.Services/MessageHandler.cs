using Discord.WebSocket;
using MatchUpBot.Services.MatchUp;
using MatchUpBot.Services.Builds;
using System.Threading.Tasks;

namespace MatchUpBot.Services
{
    public static class MessageHandler
    {
        public static async Task MessageRecieved(SocketMessage message)
        {
            var content = message.Content;
            if (MatchUpService.IsMatchUpMessage(content))
            {
                var response = MatchUpService.BuildMatchUp(content);
                await message.Channel.SendMessageAsync(response).ConfigureAwait(false);
            }
            else if (BuildService.IsBuildMessage(content))
            {
                var response = BuildService.BuildSuggestedBuild(content);
                await message.Channel.SendMessageAsync(response).ConfigureAwait(false);
            }
        }
    }
}
