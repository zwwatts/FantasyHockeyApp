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
            var waiting = true;
            var business = new LeagueBusinessLayer(-1);
            business.LeagueDataUpdated += (i) =>
                                          {
                                              waiting = false;
                                          };
            business.SetLeagueId(-2);
            while (waiting){}
            Assert.IsNull(business.GetLeagueInfo().LeagueName);
        }

        [TestMethod]
        public void GetTeams_BadIdDoesntBlowUp()
        {
            var waiting = true;
            var business = new LeagueBusinessLayer(-1);
            business.LeagueDataUpdated += (i) =>
            {
                waiting = false;
            };
            while (waiting) { }
            Assert.IsNull(business.GetTeams());
        }

        [TestMethod]
        public void GetTeam_BadIdDoesntBlowUp()
        {
            var waiting = true;
            var business = new LeagueBusinessLayer(-1);
            business.LeagueDataUpdated += (i) =>
            {
                waiting = false;
            };
            while (waiting) { }
            Assert.IsNull(business.GetTeam(2));
        }

        [TestMethod]
        public void GetSkaterCategories_BadIdDoesntBlowUp()
        {
            var waiting = true;
            var business = new LeagueBusinessLayer(-1);
            business.LeagueDataUpdated += (i) =>
            {
                waiting = false;
            };
            while (waiting) { }
            Assert.IsNull(business.GetSkaterStatColumnHeaders());
        }

        [TestMethod]
        public void GetGoalieCategories_BadIdDoesntBlowUp()
        {
            var waiting = true;
            var business = new LeagueBusinessLayer(-1);
            business.LeagueDataUpdated += (i) => { throw new Exception(); };
            business.LeagueDataUpdated += (i) =>
            {
                waiting = false;
            };
            while (waiting) { }
            Assert.IsNull(business.GetSkaterStatColumnHeaders());
        }

        [TestMethod]
        public void GetCategories_AreFiltered()
        {
            var business = new LeagueBusinessLayer(22381);
            var waiting = true;
            business.LeagueDataUpdated += (i) =>
            {
                waiting = false;
            };
            while (waiting) { }
            Assert.AreNotEqual(business.GetGoalieStatColumnHeaders(), business.GetSkaterStatColumnHeaders());
        }


        [TestMethod]
        public void GetWeeklyMatchups_BadIdDoesntBlowUp()
        {
            var waiting = true;
            var business = new LeagueBusinessLayer(-1);
            business.LeagueDataUpdated += (i) =>
            {
                waiting = false;
            };
            while (waiting) { }
            Assert.IsNull(business.GetWeeklyMatchups());
        }
    }
}
