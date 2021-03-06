﻿using System.Diagnostics;
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
        public void Yahoo_GetLeagueWithInvalidStats_ReturnsNull() => Assert.IsNull(_yahoo.GetLeague(22386));

        [TestMethod]
        public void Yahoo_GetLeagueWithoutAccess_ReturnsNull() => Assert.IsNull(_yahoo.GetLeague(22392));

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
        public void Yahoo_GetTeam_TeamIsCorrect()
        {
            var team = _yahoo.GetTeam(22381, 1);
            Assert.AreEqual("Rubber Puckies", team.Name);
        }

        [TestMethod]
        public void Yahoo_GetTeams_TeamsAreCorrect()
        {
            
        }

        [TestMethod]
        public void Yahoo_GetStandings_StandingsAreCorrect()
        {
            var standings = _yahoo.GetStandings(22381, 1);
            Assert.IsTrue(10 <= standings.Wins);
        }

        [TestMethod]
        public void Yahoo_GetStatCategories_CategoriesAreCorrect()
        {
            var statCategories = _yahoo.GetStatCategories(22381);
            Assert.AreEqual(14, statCategories.Count);
            Assert.IsTrue(statCategories.First(category => category.DisplayName == "G").StatCategoryId == 1);
        }

        [TestMethod]
        public void Yahoo_GetPlayers_PlayersAreCorrect()
        {
            var players = _yahoo.GetPlayers(22381, 1);
            Assert.IsTrue(players.Count >= 16);
            var matthews = players.First(player => player.PlayerId == 7109);
            Assert.AreEqual("Auston", matthews.FirstName);
            Assert.AreEqual("Matthews", matthews.LastName);
            Assert.AreEqual(7109, matthews.PlayerId);
            Assert.AreEqual("P", matthews.PositionType);
            Assert.AreEqual("C", matthews.Position);
            Assert.AreEqual("Toronto Maple Leafs", matthews.EditorialTeamName);
            Assert.AreEqual(34, matthews.UniformNumber);
            Assert.IsTrue(matthews.Stats.First(stat => stat.StatCategoryId == 1).Quantity >= 23);
        }

        [TestMethod]
        public void Yahoo_GetPlayersWithInvalidStats_StatsAreZero()
        {
            var players = _yahoo.GetPlayers(21165, 5);
            var matthews = players.First(player => player.PlayerId == 2680);
            Assert.AreEqual("Datsyuk", matthews.LastName);
            Assert.IsTrue(matthews.Stats.First(stat => stat.StatCategoryId == 1).Quantity >= 0);
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
    }
}
