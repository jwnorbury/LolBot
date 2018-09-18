using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchUpBot.Services.Builds
{
    public class BuildService
    {
        private static string BUILD_CHAMP_URL_TEMPLATE = "http://euw.op.gg/champion/{0}";
        private static string BUILD_CHAMP_ROLE_URL_TEMPLATE = "http://euw.op.gg/champion/{0}/statistics/{1}";

        public static bool IsBuildMessage(string message) =>
            message.StartsWith("!build ");
        
        public static string BuildSuggestedBuild(string message) 
        {
            if (!IsBuildMessage(message))
            {
                return "Invalid input. All requests must start with !build.";
            }
            var messageParts = message.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (messageParts.Length != 2 && messageParts.Length != 3) 
            {
                return "I didn't understand that requst. "
                    + "Please ask in the format !build [champion] (optional)[role]";
            }
            if (messageParts.Length == 3 && RoleMatcher.TryGetBuildRole(messageParts[2], out string validRole)) 
            {
                return CreateUrl(messageParts[1], validRole);
            }
            else if (messageParts.Length == 3)
            {
                var supportedRoles = Enum.GetNames(typeof(Enumerations.BuildRole));
                var commaSeparatedRoles = string.Join(", ", supportedRoles);
                return $"I could not find the role '{messageParts[2]}'. "
                    + $"Available roles are: {commaSeparatedRoles}.\n"
                    + "Here is the most common role for this matchup instead.\n"
                    + CreateUrl(messageParts[1]);
            }
            return CreateUrl(messageParts[1]);
        }

        private static bool ValidRole(string role) =>
            Enum.TryParse(role, true, out Enumerations.BuildRole _);

        private static string CreateUrl(string champion) =>
            string.Format(BUILD_CHAMP_URL_TEMPLATE, champion);

        private static string CreateUrl(string champion, string role) =>
            string.Format(BUILD_CHAMP_ROLE_URL_TEMPLATE, champion, role);
    }
}
