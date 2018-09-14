using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchUpBot.Services.MatchUp
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
            if (messageParts.Length == 4 && !ValidRole(messageParts[3]))
            {
                return "I could not find that role. Here is the most common role instead.\n" 
                    + CreateUrl(messageParts.SkipLast(1));
            }
            return CreateUrl(messageParts);
        }

        private static bool ValidRole(string role) => Enum.IsDefined(typeof(Enumerations.Role), role);

        private static string CreateUrl(IEnumerable<string> messageParts) =>
            MATCHUP_URL_TEMPATE + string.Join('/', messageParts.Skip(1));
    }
}