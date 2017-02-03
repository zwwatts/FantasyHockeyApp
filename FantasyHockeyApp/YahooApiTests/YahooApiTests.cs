using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YahooApi;

namespace YahooApiTests
{
    [TestClass]
    public class YahooApiTests
    {
        private Yahoo _yahoo;

        [TestInitialize()]
        public void Initialize() => _yahoo = new Yahoo();

        [TestMethod]
        public void TestingLeagueJson()
        {
            var league = _yahoo.GetLeague(22381);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var league = _yahoo.GetLeague(22381);

            foreach (var matchup in league.Matchups)
            {
                foreach (var team in matchup.Teams)
                {
                    Debug.WriteLine($"{team.Name} : {matchup.CurrentScore[team.TeamId]}");
                }
            }
            foreach (var team in league.Teams)
            {
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
                Debug.WriteLine("Skaters: ");
                foreach (var player in team.Skaters)
                {
                    Debug.WriteLine("---");
                    Debug.WriteLine($"First Name: {player.FirstName}");
                    Debug.WriteLine($"Last Name: {player.LastName}");
                    Debug.WriteLine($"Position: {player.Position}");
                    Debug.WriteLine($"Position Type: {player.PositionType}");
                    Debug.WriteLine($"Number: {player.UniformNumber}");
                    Debug.WriteLine($"Team Name: {player.EditorialTeamName}");
                    Debug.WriteLine($"Team Abbr: {player.EditorialTeamAbbr}");
                    Debug.WriteLine("---");
                }
                Debug.WriteLine("Goalies: ");
                foreach (var player in team.Goalies)
                {
                    Debug.WriteLine("---");
                    Debug.WriteLine($"First Name: {player.FirstName}");
                    Debug.WriteLine($"Last Name: {player.LastName}");
                    Debug.WriteLine($"Position: {player.Position}");
                    Debug.WriteLine($"Position Type: {player.PositionType}");
                    Debug.WriteLine($"Number: {player.UniformNumber}");
                    Debug.WriteLine($"Team Name: {player.EditorialTeamName}");
                    Debug.WriteLine($"Team Abbr: {player.EditorialTeamAbbr}");
                    Debug.WriteLine("---");
                }
                Debug.WriteLine("------ TEAM END ------");

            }
        }

        [TestMethod]
        public void Yahoo_GetLeague_LeagueIsCorrect()
        {
            var league = _yahoo.GetLeague(22381);

            // League info
            Assert.AreEqual("Wisco FHL", league.Name);
            Assert.AreEqual(22381, league.LeagueId);
            Assert.AreEqual("363.l.22381", league.LeagueKey);
            Assert.AreEqual(7, league.Matchups.Count);
            Assert.AreEqual(14, league.Teams.Count);


            var teamNoah = league.Teams.First(team => team.TeamId == 1);
            // Team Info
            Assert.AreEqual("Rubber Puckies", teamNoah.Name);
            Assert.AreEqual(1, teamNoah.TeamId);
            Assert.AreEqual("363.l.22381.t.1", teamNoah.TeamKey);
            Assert.IsTrue(teamNoah.Goalies.Count > 0);
            Assert.IsTrue(teamNoah.Skaters.Count > 0);
            // Team Standings
            Assert.IsTrue(teamNoah.Standings.Wins >= 9);
            Assert.IsTrue(teamNoah.Standings.Losses >= 4);
            Assert.IsTrue(teamNoah.Standings.Ties >= 0);
            Assert.IsTrue(teamNoah.Standings.PointsFor >= 1800.0);
            Assert.IsTrue(teamNoah.Standings.PointsAgainst >= 1500.0);
            //Team Roster
            var player = teamNoah.Skaters.First(skater => skater.PlayerId == 7109);
            Assert.AreEqual("Auston", player.FirstName);
            Assert.AreEqual("Matthews", player.LastName);
            Assert.AreEqual(7109, player.PlayerId);
            Assert.AreEqual("P", player.PositionType);
            Assert.AreEqual("C", player.Position);
            Assert.AreEqual("Toronto Maple Leafs", player.EditorialTeamName);
            Assert.AreEqual(34, player.UniformNumber);

            var matchup = league.Matchups.First();
            // Matchup Info
            Assert.AreEqual(2, matchup.Teams.Count);
            Assert.AreEqual(2, matchup.CurrentScore.Count);
            Assert.IsTrue(matchup.Week >= 14);
        }

        [TestMethod]
        public void Yahoo_GetMatchups_MatchupsAreCorrect()
        {
            var matchups = _yahoo.GetMatchups(22381);
            Assert.AreEqual(7, matchups.Count);

            var matchup = matchups.First();
            Assert.AreEqual(2, matchup.Teams.Count);
            Assert.AreEqual(2, matchup.CurrentScore.Count);
        }

        [TestMethod]
        public void Yahoo_GetStandings_StandingsAreCorrect()
        {
            var standings = _yahoo.GetStandings(22381, 1);
            Assert.AreEqual(10, standings.Wins);
        }

        [TestMethod]
        public void Yahoo_GetPlayers_PlayersAreCorrect()
        {
            var players = _yahoo.GetPlayers(21165, 1);
            Debug.WriteLine(players.Count);
            foreach (var player in players)
            {
                Debug.WriteLine($"{player.LastName} : {player.Stats[0].Quantity}");
            }
            Assert.IsTrue(players.Count >= 16);
            
        }

        [TestMethod]
        public void Yahoo_GetTeam_TeamIsCorrect()
        {
            var team = _yahoo.GetTeam(22381, 1);
            Assert.AreEqual("Rubber Puckies", team.Name);
        }
    }
}
