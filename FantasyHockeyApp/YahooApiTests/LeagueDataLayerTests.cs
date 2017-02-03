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
            var leagueDataLayer = new LeagueDataLayer {LeagueId = 22381};
            leagueDataLayer.LeagueDataUpdated += () => 
            Assert.AreEqual("Wisco FHL", leagueDataLayer.GetLeagueInfo().LeagueName);
        }

        [TestMethod]
        public void GetLeagueInfo_BadIdDoesntBlowUp()
        {
            var leagueDataLayer = new LeagueDataLayer { LeagueId = -1 };
            Assert.IsNull(leagueDataLayer.GetLeagueInfo().LeagueName);
        }

        [TestMethod]
        public void GetTeams_BadIdDoesntBlowUp()
        {
            var leagueDataLayer = new LeagueDataLayer { LeagueId = -1 };
            Assert.IsNull(leagueDataLayer.GetTeams());
        }

        [TestMethod]
        public void GetTeam_BadIdDoesntBlowUp()
        {
            var leagueDataLayer = new LeagueDataLayer { LeagueId = -1 };
            Assert.IsNull(leagueDataLayer.GetTeam(2));
        }

        [TestMethod]
        public void GetStatCategories_BadIdDoesntBlowUp()
        {
            var leagueDataLayer = new LeagueDataLayer { LeagueId = -1 };
            Assert.IsNull(leagueDataLayer.GetStatCategories());
        }

        [TestMethod]
        public void GetWeeklyMatchups_BadIdDoesntBlowUp()
        {
            var leagueDataLayer = new LeagueDataLayer { LeagueId = -1 };
            Assert.IsNull(leagueDataLayer.GetWeeklyMatchups());
        }
    }
}
