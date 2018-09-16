using Discord.WebSocket;
using MatchUpBot.Config;
using MatchUpBot.Services;
using System;
using System.Threading.Tasks;

namespace MatchUpBot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                MainAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                LoggingService.LogError("An unexpected error has occured.", ex);
            }
        }

        private static async Task MainAsync()
        {
            using (var client = new DiscordSocketClient())
            {
                var config = await ConfigProvider.GetConfigAsync().ConfigureAwait(false);
                if (config == null)
                {
                    LoggingService.LogError("Could not start bot. "
                        + $"'{ConfigProvider.FilePath()}' does not exist.");
                    return;
                }

                client.Log += LoggingService.Log;
                client.MessageReceived += MessageHandler.MessageRecieved;

                await client.LoginAsync(Discord.TokenType.Bot, config.Token).ConfigureAwait(false);
                await client.StartAsync().ConfigureAwait(false);
                await Task.Delay(-1);
            }
        }

    }
}
