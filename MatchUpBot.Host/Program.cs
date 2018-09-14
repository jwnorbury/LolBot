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
            while (true)
            {
                try
                {
                    MainAsync().GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    LoggingService.LogError("An unexpected error has occured.", ex);
                }
                LoggingService.Log("Restarting...");
            }
        }

        private static async Task MainAsync()
        {
            using (var client = new DiscordSocketClient())
            {
                var token = ConfigProvider.Current.Token;

                client.Log += LoggingService.Log;
                client.MessageReceived += MessageHandler.MessageRecieved;

                await client.LoginAsync(Discord.TokenType.Bot, token).ConfigureAwait(false);
                await client.StartAsync().ConfigureAwait(false);

                await Task.Delay(-1);
            }
        }

    }
}
