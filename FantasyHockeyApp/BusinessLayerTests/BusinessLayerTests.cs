using System;
using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLayerTests
{
    [TestClass]
    public class BusinessLayerTests
    {
        [TestMethod]
        public void GetLeagueInfo_HappyPath()
        {
            var business = new LeagueBusinessLayer(22381);
            business.LeagueDataUpdated += (i) =>
            Assert.AreEqual("Wisco FHL", business.GetLeagueInfo().LeagueName);
        }

        [TestMethod]
        public void GetLeagueInfo_BadIdDoesntBlowUp()
        {
            var business = new LeagueBusinessLayer(-1);
            business.LeagueDataUpdated += (i) =>
            Assert.IsNull(business.GetLeagueInfo().LeagueName);
        }

        [TestMethod]
        public void GetTeams_BadIdDoesntBlowUp()
        {
            var business = new LeagueBusinessLayer(-1);
            business.LeagueDataUpdated += (i) =>
            Assert.IsNull(business.GetTeams());
        }

        [TestMethod]
        public void GetTeam_BadIdDoesntBlowUp()
        {
            var business = new LeagueBusinessLayer(-1);
            business.LeagueDataUpdated += (i) =>
            Assert.IsNull(business.GetTeam(2));
        }

        [TestMethod]
        public void GetSkaterCategories_BadIdDoesntBlowUp()
        {
            var business = new LeagueBusinessLayer(-1);
            business.LeagueDataUpdated += (i) =>
            Assert.IsNull(business.GetSkaterStatColumnHeaders());
        }

        [TestMethod]
        public void GetGoalieCategories_BadIdDoesntBlowUp()
        {
            var business = new LeagueBusinessLayer(-1);
            business.LeagueDataUpdated += (i) =>
            Assert.IsNull(business.GetSkaterStatColumnHeaders());
        }

        [TestMethod]
        public void GetCategories_AreFiltered()
        {
            var business = new LeagueBusinessLayer(22381);
            business.LeagueDataUpdated += (i) =>
            Assert.AreNotEqual(business.GetGoalieStatColumnHeaders(), business.GetSkaterStatColumnHeaders());
        }


        [TestMethod]
        public void GetWeeklyMatchups_BadIdDoesntBlowUp()
        {
            var business = new LeagueBusinessLayer(-1);
            business.LeagueDataUpdated += (i) =>
            Assert.IsNull(business.GetWeeklyMatchups());
        }
    }
}
