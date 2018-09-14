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

        public static void Log(string message)
        {
            Console.WriteLine(message);
        }

        public static void LogError(string error)
        {
            Console.WriteLine(error);
        }

        public static void LogError(string error, Exception ex)
        {
            Console.WriteLine(error);
            Console.WriteLine(ex);
        }
    }
}
