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
            var messageParts = message.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (messageParts.Length != 3 && messageParts.Length != 4)
            {
                return "I didn't understand that requst. "
                    + "Please ask in the format !matchup|!mu [champion] [opponent] (optional)[role]";
            }
            if (messageParts.Length == 4 && RoleMatcher.TryGetMatchUpRole(messageParts[3], out string validRole))
            {
                return CreateUrl(messageParts[1], messageParts[2], validRole);
            }
            else if (messageParts.Length == 4)
            {
                var supportedRoles = Enum.GetNames(typeof(Enumerations.MatchUpRole));
                var commaSeparatedRoles = string.Join(", ", supportedRoles);
                return $"I could not find the role '{messageParts[3]}'. "
                    + $"Available roles are: {commaSeparatedRoles}.\n"
                    + "Here is the most common role for this matchup instead.\n"
                    + CreateUrl(messageParts[1], messageParts[2]);
            }
            return CreateUrl(messageParts[1], messageParts[2]);
        }

        private static string CreateUrl(string champ, string opponent) =>
            MATCHUP_URL_TEMPATE + $"{champ}/{opponent}";

        private static string CreateUrl(string champ, string opponent, string role) =>
            MATCHUP_URL_TEMPATE + $"{champ}/{opponent}/{role}";
    }
}