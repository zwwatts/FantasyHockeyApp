using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YahooApi;

namespace YahooApiTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var yahoo = new Yahoo();
            var league = yahoo.GetLeague(22381);
            foreach (var team in league.Teams)
            {
                Debug.WriteLine("------ TEAM START ------");
                Debug.WriteLine($"Name: {team.Name}");
                Debug.WriteLine($"Rank: {team.Standings.Rank}");
                Debug.WriteLine($"W-L-T: {team.Standings.Wins}-{team.Standings.Losses}-{team.Standings.Ties}");
                Debug.WriteLine($"Points For: {team.Standings.PointsFor}");
                Debug.WriteLine($"Points Against: {team.Standings.PointsAgainst}");
                Debug.WriteLine("------ TEAM END ------");

            }
        }
    }
}
