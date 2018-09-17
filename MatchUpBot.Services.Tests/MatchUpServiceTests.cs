using System;
using MatchUpBot.Services.MatchUp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchUpBot.Services.Tests
{
    [TestClass]
    public class MatchUpServiceTests
    {
        [TestMethod]
        public void BuildMatchUp_ChampOpponentLane_MatchupUrl()
        {
            var request = "!mu sivir jhin adc";
            var response = MatchUpService.BuildMatchUp(request);
            var expectedResponse = "http://matchup.gg/matchup/sivir/jhin/adc";
            Assert.AreEqual(expectedResponse, response);
        }

        [TestMethod]
        public void BuildMatchUp_ChampOpponent_MatchupUrl()
        {
            var request = "!matchup ashe ezreal";
            var response = MatchUpService.BuildMatchUp(request);
            var expectedResponse = "http://matchup.gg/matchup/ashe/ezreal";
            Assert.AreEqual(expectedResponse, response);
        }

        [TestMethod]
        public void BuildMatchUp_Champ_ErrorMessage()
        {
            var request = "!mu sona";
            var response = MatchUpService.BuildMatchUp(request);
            var expectedResponse = "I didn't understand that requst. "
                    + "Please ask in the format !matchup|!mu " 
                    + "[champion] [opponent] (optional)[role]";
            Assert.AreEqual(expectedResponse, response);
        }

        [TestMethod]
        public void BuildMatchUp_ChampInvalidRole_ErrorMessage()
        {
            var champ = "jax";
            var opponent = "urgot";
            var role = "tap";
            var request = $"!mu {champ} {opponent} {role}";

            var supportedRoles = Enum.GetNames(typeof(Enumerations.MatchUpRole));
            var commaSeparatedRoles = string.Join(", ", supportedRoles);
            var url = $"http://matchup.gg/matchup/{champ}/{opponent}";
            var expectedResponse = $"I could not find the role '{role}'. "
                    + $"Available roles are: {commaSeparatedRoles}.\n"
                    + "Here is the most common role for this matchup instead.\n"
                    + url;

            var response = MatchUpService.BuildMatchUp(request);

            Assert.AreEqual(expectedResponse, response);
        }

        [TestMethod]
        public void BuildMatchUp_InvalidCommand_ErrorMessage()
        {
            var response = MatchUpService.BuildMatchUp("INVALID");
            var expectedResponse = "Invalid input. All requests " 
                + "must start with !matchup or !mu";
            Assert.AreEqual(response, expectedResponse);
        }
    }
}
