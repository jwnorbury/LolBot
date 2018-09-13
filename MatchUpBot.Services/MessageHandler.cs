using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
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
        }
    }
}
