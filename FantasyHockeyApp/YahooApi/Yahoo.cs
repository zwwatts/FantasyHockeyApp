using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YahooApi
{
    public class Yahoo
    {
        private readonly OAuthQuery _oauthQuery = new OAuthQuery();
        private const string YahooFantasyUrl = @"http://fantasysports.yahooapis.com/fantasy/v2";

        public Yahoo()
        {

        }

        public League GetLeague(int leagueId)
        {
            var leagueQueryResults = _oauthQuery.QueryWithOAuth($"{YahooFantasyUrl}/league/363.l.{leagueId}");

            return new League
            {
                LeagueId = leagueId,
                LeagueKey = Regex.Match(leagueQueryResults, @"<league_key>(.+?)</league_key>").Groups[1].Value,
                Name = Regex.Match(leagueQueryResults, @"<name>(.+?)</name>").Groups[1].Value,
                Teams = GetTeams(leagueId),
                StatCategories = GetStatCategories(leagueId),
                Matchups = GetMatchups(leagueId)
            };
        }

        public Team GetTeam(int leagueId, int teamId)
        {
            var teamQueryResults = _oauthQuery.QueryWithOAuth($"{YahooFantasyUrl}/team/363.l.{leagueId}.t.{teamId}");
            var allPlayers = GetPlayers(leagueId, teamId);

            return new Team
            {
                Name = Regex.Match(teamQueryResults, @"<name>(.+?)</name>").Groups[1].Value,
                TeamId = teamId,
                TeamKey = Regex.Match(teamQueryResults, @"<team_key>(.+?)</team_key>").Groups[1].Value,
                Standings = GetStandings(leagueId, teamId),
                Skaters = allPlayers.Where(player => player.PositionType == "P").ToList(),
                Goalies = allPlayers.Where(player => player.PositionType == "G").ToList()
            };
        }

        public List<Team> GetTeams(int leagueId)
        {
            var standingsQueryResults = _oauthQuery.QueryWithOAuth($"{YahooFantasyUrl}/league/363.l.{leagueId}/standings");
            var jsonResponse = XmlToJObject(standingsQueryResults);
            var teamsJson = jsonResponse["fantasy_content"]["league"]["standings"]["teams"]["team"];
            var playersDictionary = teamsJson.ToDictionary(team => (int)team["team_id"], team => GetPlayers(leagueId, (int)team["team_id"]));
            return teamsJson.Select(team => new Team
            {
                Name = team["name"].ToString(),
                TeamId = (int)team["team_id"],
                TeamKey = team["team_key"].ToString(),
                Standings = new Standings
                {
                    Wins = (int)team["team_standings"]["outcome_totals"]["wins"],
                    Losses = (int)team["team_standings"]["outcome_totals"]["losses"],
                    Ties = (int)team["team_standings"]["outcome_totals"]["ties"],
                    Rank = (int)team["team_standings"]["rank"],
                    PointsFor = (double)team["team_standings"]["points_for"],
                    PointsAgainst = (double)team["team_standings"]["points_against"]
                },
                Skaters = playersDictionary[(int)team["team_id"]].Where(player => player.PositionType == "P").ToList(),
                Goalies = playersDictionary[(int)team["team_id"]].Where(player => player.PositionType == "G").ToList(),
                TotalStats = team["team_stats"]["stats"]["stat"].Select(stat => new Stat
                {
                    Quantity = (int)stat["value"],
                    StatCategoryId = (int)stat["stat_id"]
                }).ToList()
            }).ToList();
        }

        public Standings GetStandings(int leagueId, int teamId)
        {
            var standingsQueryResults = _oauthQuery.QueryWithOAuth($"{YahooFantasyUrl}/league/363.l.{leagueId}/standings");
            var jsonResponse = XmlToJObject(standingsQueryResults);
            var teams = jsonResponse["fantasy_content"]["league"]["standings"]["teams"]["team"];
            return (from team in teams
                    where team["team_id"].ToString() == teamId.ToString()
                    select new Standings
                    {
                        Wins = (int)team["team_standings"]["outcome_totals"]["wins"],
                        Losses = (int)team["team_standings"]["outcome_totals"]["losses"],
                        Ties = (int)team["team_standings"]["outcome_totals"]["ties"],
                        Rank = (int)team["team_standings"]["rank"],
                        PointsFor = (double)team["team_standings"]["points_for"],
                        PointsAgainst = (double)team["team_standings"]["points_against"]
                    }).FirstOrDefault();
        }

        public List<StatCategory> GetStatCategories(int leagueId)
        {
            var settingsQueryResults = _oauthQuery.QueryWithOAuth($"{YahooFantasyUrl}/league/363.l.{leagueId}/settings");

            var jsonResponse = XmlToJObject(settingsQueryResults);
            var stats = jsonResponse["fantasy_content"]["league"]["settings"]["stat_categories"]["stats"]["stat"];
            var modifiers = jsonResponse["fantasy_content"]["league"]["settings"]["stat_modifiers"]["stats"]["stat"];
            var modifierDictionary = modifiers.ToDictionary(modifier => (int)modifier["stat_id"], modifier => (double)modifier["value"]);

            return stats.Select(stat => new StatCategory
            {
                Name = stat["name"].ToString(),
                DisplayName = stat["display_name"].ToString(),
                StatCategoryId = (int)stat["stat_id"],
                PositionType = stat["position_type"].ToString(),
                ModifierValue = modifierDictionary[(int)stat["stat_id"]]
            }).ToList();
        }

        public List<Player> GetPlayers(int leagueId, int teamId)
        {
            var teamRosterQueryResults = _oauthQuery.QueryWithOAuth($"{YahooFantasyUrl}/team/363.l.{leagueId}.t.{teamId}/roster");
            var jsonResponse = XmlToJObject(teamRosterQueryResults);
            var players = jsonResponse["fantasy_content"]["team"]["roster"]["players"]["player"];
            return players.Select(player => new Player
            {
                PlayerId = (int)player["player_id"],
                PlayerKey = (string)player["player_key"],
                Position = (string)player["display_position"],
                PositionType = (string)player["position_type"],
                EditorialTeamAbbr = (string)player["editorial_team_abbr"],
                EditorialTeamKey = (string)player["editorial_team_key"],
                EditorialTeamName = (string)player["editorial_team_full_name"],
                UniformNumber = (int)player["uniform_number"],
                FirstName = (string)player["name"]["first"],
                LastName = (string)player["name"]["last"],
            }).ToList();
        }

        public List<Matchup> GetMatchups(int leagueId)
        {
            var scoreboardQueryResults = _oauthQuery.QueryWithOAuth($"{YahooFantasyUrl}/league/363.l.{leagueId}/scoreboard");
            var jsonResponse = XmlToJObject(scoreboardQueryResults);
            var matchups = jsonResponse["fantasy_content"]["league"]["scoreboard"]["matchups"]["matchup"];

            return matchups.Select(matchup => new Matchup
            {
                Week = (int)matchup["week"],
                WeekStart = (string)matchup["week_start"],
                WeekEnd = (string)matchup["week_end"],
                Teams = matchup["teams"]["team"].Select(team => new Team
                {
                    Name = (string)team["name"],
                    TeamId = (int)team["team_id"],
                    TeamKey = (string)team["team_key"]
                }).ToList(),
                CurrentScore = matchup["teams"]["team"].ToDictionary(team => (int)team["team_id"], team => (double)team["team_points"]["total"])
            }).ToList();
        }

        private JObject XmlToJObject(string xmlResponse)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlResponse);
            var json = JsonConvert.SerializeXmlNode(xmlDoc);
            return JsonConvert.DeserializeObject<JObject>(json);
        }

    }
}
