using System;
using System.Linq;

namespace MatchUpBot.Services
{
    public static class MatchUpService
    {
        private const string MATCHUP_URL_TEMPATE = "http://matchup.gg/matchup/";
        public static bool IsMatchUpMessage(string message) =>
            message.ToLower().StartsWith("!mu ")
            || message.ToLower().StartsWith("!matchup ");

        public static string BuildMatchUp(string message)
        {
            if (!IsMatchUpMessage(message))
            {
                return "Invalid input. All requests must start with !matchup or !mu";
            }
            var messageParts = message.ToLower().Split(" ");
            if (messageParts.Length != 3 && messageParts.Length != 4)
            {
                return "I didn't understand that requst. "
                    + "Please ask in the format !matchup|!mu [champion] [opponent] [role]";
            }
            return MATCHUP_URL_TEMPATE + string.Join('/', messageParts.Skip(1));
        }
    }
}