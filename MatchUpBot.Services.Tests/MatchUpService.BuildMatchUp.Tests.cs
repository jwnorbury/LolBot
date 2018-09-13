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
    }
}
