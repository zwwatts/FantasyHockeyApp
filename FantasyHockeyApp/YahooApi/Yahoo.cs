using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YahooApi
{
    public class Yahoo
    {
        private readonly OAuthQuery _oauthQuery = new OAuthQuery();
        private const string YahooFantasyUrl = @"http://fantasysports.yahooapis.com/fantasy/v2";

        public League GetLeague(int leagueId)
        {
            var leagueQueryResults = _oauthQuery.QueryWithOAuth($"{YahooFantasyUrl}/league/363.l.{leagueId}");
            if (leagueQueryResults == null) return null;
            var league = XmlToXmlDocument(leagueQueryResults).SelectSingleNode("//fantasy_content/league");

            return new League
            {
                LeagueId = leagueId,
                LeagueKey = league?.SelectSingleNode("//league_key")?.InnerXml,
                Name = league?.SelectSingleNode("//name")?.InnerXml,
                Teams = GetTeams(leagueId),
                StatCategories = GetStatCategories(leagueId),
                Matchups = GetMatchups(leagueId)
            };
        }

        public Team GetTeam(int leagueId, int teamId)
        {
            var teamQueryResults = _oauthQuery.QueryWithOAuth($"{YahooFantasyUrl}/team/363.l.{leagueId}.t.{teamId}");
            var team = XmlToXmlDocument(teamQueryResults);
            var allPlayers = GetPlayers(leagueId, teamId);

            return new Team
            {
                Name = team.SelectSingleNode("//fantasy_content/team/name")?.InnerXml,
                TeamId = teamId,
                TeamKey = team.SelectSingleNode("//fantasy_content/team/team_key")?.InnerXml,
                Standings = GetStandings(leagueId, teamId),
                Skaters = allPlayers.Where(player => player.PositionType == "P").ToList(),
                Goalies = allPlayers.Where(player => player.PositionType == "G").ToList()
            };
        }

        public List<Team> GetTeams(int leagueId)
        {
            var standingsQueryResults = _oauthQuery.QueryWithOAuth($"{YahooFantasyUrl}/league/363.l.{leagueId}/standings");
            var teams = XmlToXmlDocument(standingsQueryResults).SelectNodes("//fantasy_content/league/standings/teams/team");
            var playersDictionary = teams?.Cast<XmlNode>().ToDictionary(
                team => Convert.ToInt32(team.SelectSingleNode("team_id")?.InnerXml), 
                team => GetPlayers(leagueId, Convert.ToInt32(team.SelectSingleNode("team_id")?.InnerXml)));

            return teams?.Cast<XmlNode>().Select(team => new Team
            {
                Name = team.SelectSingleNode("name")?.InnerXml,
                TeamId = Convert.ToInt32(team.SelectSingleNode("team_id")?.InnerXml),
                TeamKey = team.SelectSingleNode("team_key")?.InnerXml,
                Standings = new Standings
                {
                    Wins = Convert.ToInt32(team.SelectSingleNode("team_standings/outcome_totals/wins")?.InnerXml),
                    Losses = Convert.ToInt32(team.SelectSingleNode("team_standings/outcome_totals/losses")?.InnerXml),
                    Ties = Convert.ToInt32(team.SelectSingleNode("team_standings/outcome_totals/ties")?.InnerXml),
                    Rank = Convert.ToInt32(team.SelectSingleNode("team_standings/rank")?.InnerXml),
                    PointsFor = Convert.ToDouble(team.SelectSingleNode("team_standings/points_for")?.InnerXml),
                    PointsAgainst = Convert.ToDouble(team.SelectSingleNode("team_standings/points_against")?.InnerXml)
                },
                Skaters = playersDictionary[Convert.ToInt32(team.SelectSingleNode("team_id")?.InnerXml)]
                    .Where(player => player.PositionType == "P").ToList(),
                Goalies = playersDictionary[Convert.ToInt32(team.SelectSingleNode("team_id")?.InnerXml)]
                    .Where(player => player.PositionType == "G").ToList(),
                TotalStats = team.SelectNodes("team_stats/stats/stat")?.Cast<XmlNode>().Select(stat => new Stat
                {
                    Quantity = Convert.ToInt32(stat.SelectSingleNode("value")?.InnerXml),
                    StatCategoryId = Convert.ToInt32(stat.SelectSingleNode("stat_id")?.InnerXml)
                }).ToList()
            }).ToList();
        }

        public Standings GetStandings(int leagueId, int teamId)
        {
            var standingsQueryResults = _oauthQuery.QueryWithOAuth($"{YahooFantasyUrl}/league/363.l.{leagueId}/standings");
            var teams = XmlToXmlDocument(standingsQueryResults).SelectNodes("//fantasy_content/league/standings/teams/team");
            return (from team in teams?.Cast<XmlNode>()
                    where team.SelectSingleNode("team_id")?.InnerXml == teamId.ToString()
                    select new Standings
                    {
                        Wins = Convert.ToInt32(team.SelectSingleNode("team_standings/outcome_totals/wins")?.InnerXml),
                        Losses = Convert.ToInt32(team.SelectSingleNode("team_standings/outcome_totals/losses")?.InnerXml),
                        Ties = Convert.ToInt32(team.SelectSingleNode("team_standings/outcome_totals/ties")?.InnerXml),
                        Rank = Convert.ToInt32(team.SelectSingleNode("team_standings/rank")?.InnerXml),
                        PointsFor = Convert.ToDouble(team.SelectSingleNode("team_standings/points_for")?.InnerXml),
                        PointsAgainst = Convert.ToDouble(team.SelectSingleNode("team_standings/points_against")?.InnerXml)
                    }).FirstOrDefault();
        }

        public List<StatCategory> GetStatCategories(int leagueId)
        {
            var settingsQueryResults = _oauthQuery.QueryWithOAuth($"{YahooFantasyUrl}/league/363.l.{leagueId}/settings");
            var settings = XmlToXmlDocument(settingsQueryResults);
            var stats = settings.SelectNodes("//fantasy_content/league/settings/stat_categories/stats/stat");
            var modifiers = settings.SelectNodes("//fantasy_content/league/settings/stat_modifiers/stats/stat");
            var modifierDictionary = modifiers?.Cast<XmlNode>().ToDictionary(
                modifier => Convert.ToInt32(modifier.SelectSingleNode("stat_id")?.InnerXml), 
                modifier => Convert.ToDouble(modifier.SelectSingleNode("value")?.InnerXml));

            return stats?.Cast<XmlNode>().Select(stat => new StatCategory
            {
                Name = stat.SelectSingleNode("name")?.InnerXml,
                DisplayName = stat.SelectSingleNode("display_name")?.InnerXml,
                StatCategoryId = Convert.ToInt32(stat.SelectSingleNode("stat_id")?.InnerXml),
                PositionType = stat.SelectSingleNode("position_type")?.InnerXml,
                ModifierValue = modifierDictionary[Convert.ToInt32(stat.SelectSingleNode("stat_id")?.InnerXml)]
            }).ToList();
        }

        public List<Player> GetPlayers(int leagueId, int teamId)
        {
            var teamRosterQueryResults = _oauthQuery.QueryWithOAuth($"{YahooFantasyUrl}/team/363.l.{leagueId}.t.{teamId}/players/stats");
            var players = XmlToXmlDocument(teamRosterQueryResults).SelectNodes("//fantasy_content/team/players/player");

            return players?.Cast<XmlNode>().Select(player => new Player
            {
                PlayerId = Convert.ToInt32(player.SelectSingleNode("player_id")?.InnerXml),
                PlayerKey = player.SelectSingleNode("player_key")?.InnerXml,
                Position = player.SelectSingleNode("display_position")?.InnerXml,
                PositionType = player.SelectSingleNode("position_type")?.InnerXml,
                EditorialTeamAbbr = player.SelectSingleNode("editorial_team_abbr")?.InnerXml,
                EditorialTeamKey = player.SelectSingleNode("editorial_team_key")?.InnerXml,
                EditorialTeamName = player.SelectSingleNode("editorial_team_full_name")?.InnerXml,
                UniformNumber = Convert.ToInt32(player.SelectSingleNode("uniform_number")?.InnerXml),
                FirstName = player.SelectSingleNode("name/first")?.InnerXml,
                LastName = player.SelectSingleNode("name/last")?.InnerXml,
                Stats = player.SelectNodes("player_stats/stats/stat")?.Cast<XmlNode>().Select(stat => new Stat
                {
                    Quantity = stat.SelectSingleNode("value")?.InnerXml == "-" ? 0 : Convert.ToInt32(stat.SelectSingleNode("value")?.InnerXml),
                    StatCategoryId = Convert.ToInt32(stat.SelectSingleNode("stat_id")?.InnerXml)
                }).ToList()
            }).ToList();
        }

        public List<Matchup> GetMatchups(int leagueId)
        {
            var scoreboardQueryResults = _oauthQuery.QueryWithOAuth($"{YahooFantasyUrl}/league/363.l.{leagueId}/scoreboard");
            var matchups = XmlToXmlDocument(scoreboardQueryResults).SelectNodes("//fantasy_content/league/scoreboard/matchups/matchup");

            return matchups?.Cast<XmlNode>().Select(matchup => new Matchup
            {
                Week = Convert.ToInt32(matchup.SelectSingleNode("week")?.InnerXml),
                WeekStart = matchup.SelectSingleNode("week_start")?.InnerXml,
                WeekEnd = matchup.SelectSingleNode("week_end")?.InnerXml,
                Teams = matchup.SelectNodes("teams/team")?.Cast<XmlNode>().Select(team => new Team
                {
                    Name = team.SelectSingleNode("name")?.InnerXml,
                    TeamId = Convert.ToInt32(team.SelectSingleNode("team_id")?.InnerXml),
                    TeamKey = team.SelectSingleNode("team_key")?.InnerXml
                }).ToList(),
                CurrentScore = matchup.SelectNodes("teams/team")?.Cast<XmlNode>().ToDictionary(
                    team => Convert.ToInt32(team.SelectSingleNode("team_id")?.InnerXml), 
                    team => Convert.ToDouble(team.SelectSingleNode("team_points/total")?.InnerXml))
            }).ToList();
        }

        private XmlDocument XmlToXmlDocument(string xml)
        {
            var xmlDoc = new XmlDocument();
            xml = xml.Replace(" xmlns=\"", " ns=\"");
            xmlDoc.LoadXml(xml);
            return xmlDoc;
        }
    }
}
