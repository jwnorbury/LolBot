using System;

namespace MatchUpBot.Services
{
    public static class RoleMatcher
    {
        public static bool TryGetMatchUpRole(string role, out string validRole)
        {
            if (Enum.TryParse(role, true, out Enumerations.MatchUpRole _)) 
            {
                validRole = role;
                return true;
            }
            if (Enum.TryParse(role, true, out Enumerations.BuildRole buildRole))
            {
                if (buildRole == Enumerations.BuildRole.Bot) 
                {
                    validRole = Enumerations.MatchUpRole.Adc.ToString().ToLower();
                    return true;
                }
            }
            validRole = null;
            return false;
        }

        public static bool TryGetBuildRole(string role, out string validRole)
        {
            if (Enum.TryParse(role, true, out Enumerations.BuildRole _))
            {
                validRole = role;
                return true;
            }
            if (Enum.TryParse(role, true, out Enumerations.MatchUpRole matchUpRole))
            {
                if (matchUpRole == Enumerations.MatchUpRole.Adc)
                {
                    validRole = Enumerations.BuildRole.Bot.ToString().ToLower();
                    return true;
                }
            }
            validRole = null;
            return false;
        }
    }
}