using MatchUpBot.Services.Builds;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchUpBot.Services.Tests
{
    [TestClass]
    public class BuildServiceTests
    {
        [TestMethod]
        public void Build_ChampLane_BuildUrl()
        {
            var request = "!build jax top";
            var expectedResponse = "http://euw.op.gg/champion/jax/statistics/top";
            var response = BuildService.BuildSuggestedBuild(request);
            Assert.AreEqual(expectedResponse, response);
        }

        [TestMethod]
        public void Build_Champ_BuildUrl()
        {
            var request = "!build sivir";
            var expectedResponse = "http://euw.op.gg/champion/sivir";
            var response = BuildService.BuildSuggestedBuild(request);
            Assert.AreEqual(expectedResponse, response);
        }

        [TestMethod]
        public void Build_InvalidCommand_ErrorMessage()
        {
            var response = BuildService.BuildSuggestedBuild("INVALID");
            var expectedResponse = 
                "Invalid input. All requests must start with !build.";
            Assert.AreEqual(expectedResponse, response);
        }

        [TestMethod]
        public void Build_InvalidArgument_ErrorMessage()
        {
            var expectedResponse = "I didn't understand that requst. "
                + "Please ask in the format !build [champion] (optional)[role]";
            var response = BuildService.BuildSuggestedBuild("!build ");
            Assert.AreEqual(expectedResponse, response);
        }
    }
}
