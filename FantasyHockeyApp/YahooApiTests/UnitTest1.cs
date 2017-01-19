using System;
using System.Diagnostics;
using System.Linq;
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
                var roster = yahoo.GetPlayers(league.LeagueId, team.TeamId);
                Debug.WriteLine("------ TEAM START ------");
                Debug.WriteLine($"Name: {team.Name}");
                Debug.WriteLine($"Rank: {team.Standings.Rank}");
                Debug.WriteLine($"W-L-T: {team.Standings.Wins}-{team.Standings.Losses}-{team.Standings.Ties}");
                Debug.WriteLine($"Points For: {team.Standings.PointsFor}");
                Debug.WriteLine($"Points Against: {team.Standings.PointsAgainst}");
                var goalsScored = 0;
                var statId = 0;
                foreach (var stat in league.StatCategories)
                {
                    if (stat.Name == "Goals")
                    {
                        statId = stat.StatCategoryId;
                    }
                }
                foreach (var stat in team.TotalStats)
                {
                    if (stat.StatCategoryId == statId)
                    {
                        goalsScored = stat.Quantity;
                    }
                }
                Debug.WriteLine($"Goals Scored: {goalsScored}");
                Debug.WriteLine("------ TEAM END ------");

            }
        }
    }
}
