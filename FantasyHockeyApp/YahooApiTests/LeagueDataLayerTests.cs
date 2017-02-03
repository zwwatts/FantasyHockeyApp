using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YahooApi;

namespace YahooApiTests
{
    [TestClass]
    public class LeagueDataLayerTests
    {
        [TestMethod]
        public void GetLeagueInfo_HappyPath()
        {
            var waiting = true;
            var leagueDataLayer = new LeagueDataLayer {LeagueId = 22381};
            leagueDataLayer.LeagueDataUpdated += () => { waiting = false; };
            while (waiting) { }
            Assert.AreEqual("Wisco FHL", leagueDataLayer.GetLeagueInfo().LeagueName);
        }

        [TestMethod]
        public void GetLeagueInfo_BadIdDoesntBlowUp()
        {
            var waiting = true;
            var leagueDataLayer = new LeagueDataLayer { LeagueId = -1 };
            leagueDataLayer.LeagueDataUpdated += () => { waiting = false; };
            while (waiting) { }
            Assert.IsNull(leagueDataLayer.GetLeagueInfo().LeagueName);
        }

        [TestMethod]
        public void GetTeams_BadIdDoesntBlowUp()
        {
            var waiting = true;
            var leagueDataLayer = new LeagueDataLayer { LeagueId = -1 };
            leagueDataLayer.LeagueDataUpdated += () => { throw new Exception(); };
            leagueDataLayer.LeagueDataUpdated += () => { waiting = false; };
            while (waiting) { }
            Assert.IsNull(leagueDataLayer.GetTeams());
        }

        [TestMethod]
        public void GetTeam_BadIdDoesntBlowUp()
        {
            var waiting = true;
            var leagueDataLayer = new LeagueDataLayer { LeagueId = -1 };
            leagueDataLayer.LeagueDataUpdated += () => { waiting = false; };
            while (waiting) { }
            Assert.IsNull(leagueDataLayer.GetTeam(2));
        }

        [TestMethod]
        public void GetStatCategories_BadIdDoesntBlowUp()
        {
            var waiting = true;
            var leagueDataLayer = new LeagueDataLayer { LeagueId = -1 };
            leagueDataLayer.LeagueDataUpdated += () => { waiting = false; };
            while (waiting) { }
            Assert.IsNull(leagueDataLayer.GetStatCategories());
        }

        [TestMethod]
        public void GetWeeklyMatchups_BadIdDoesntBlowUp()
        {
            var waiting = true;
            var leagueDataLayer = new LeagueDataLayer { LeagueId = -1 };
            leagueDataLayer.LeagueDataUpdated += () => { waiting = false; };
            while (waiting) { }
            Assert.IsNull(leagueDataLayer.GetWeeklyMatchups());
        }
    }
}
