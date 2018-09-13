using Discord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatchUpBot.Services
{
    public class LoggingService
    {
        public static Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }

        public static void LogError(string error)
        {
        }

        public static void LogError(string error, Exception ex)
        {
        }
    }
}
