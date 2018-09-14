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
                var supportedRoles = Enum.GetNames(typeof(Enumerations.Role));
                var commaSeparatedRoles = string.Join(", ", supportedRoles);
                return $"I could not find the role '{messageParts[3]}'. "
                    + $"Available roles are: {commaSeparatedRoles}.\n"
                    + "Here is the most common role for this matchup instead.\n"
                    + CreateUrl(messageParts.SkipLast(1));
            }
            return CreateUrl(messageParts);
        }

        private static bool ValidRole(string role) =>
            Enum.TryParse(role, true, out Enumerations.Role _);

        private static string CreateUrl(IEnumerable<string> messageParts) =>
            MATCHUP_URL_TEMPATE + string.Join('/', messageParts.Skip(1));
    }
}