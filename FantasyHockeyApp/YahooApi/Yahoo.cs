using System.Collections.Generic;
using System.Diagnostics;
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
                       Teams = GetTeams(leagueId)
                   };
        }

        public Team GetTeam(int leagueId, int teamId)
        {
            var oauthQuery = new OAuthQuery();
            var teamQueryResults = oauthQuery.QueryWithOAuth($"http://fantasysports.yahooapis.com/fantasy/v2/team/363.l.{leagueId}.t.{teamId}");

            return new Team
            {
                Name = Regex.Match(teamQueryResults, @"<name>(.+?)</name>").Groups[1].Value,
                TeamId = teamId,
                TeamKey = Regex.Match(teamQueryResults, @"<team_key>(.+?)</team_key>").Groups[1].Value,
                Standings = GetStandings(leagueId, teamId)
            };
        }

        public List<Team> GetTeams(int leagueId)
        {
            var teams = new List<Team>();
            var oauthQuery = new OAuthQuery();
            var standingsQueryResults = oauthQuery.QueryWithOAuth($"http://fantasysports.yahooapis.com/fantasy/v2/league/363.l.{leagueId}/standings");
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(standingsQueryResults);
            var standingsJson = JsonConvert.SerializeXmlNode(xmlDoc);
            var jsonResponse = JsonConvert.DeserializeObject<JObject>(standingsJson);
            var teamsJson = jsonResponse["fantasy_content"]["league"]["standings"]["teams"]["team"];
            foreach (var team in teamsJson)
            {
                teams.Add(new Team
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
                              }
                          });
            }

            return teams;
        }

        public Standings GetStandings(int leagueId, int teamId)
        {
            var oauthQuery = new OAuthQuery();
            var standingsQueryResults = oauthQuery.QueryWithOAuth($"http://fantasysports.yahooapis.com/fantasy/v2/league/363.l.{leagueId}/standings");
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(standingsQueryResults);
            var standingsJson = JsonConvert.SerializeXmlNode(xmlDoc);
            var jsonResponse = JsonConvert.DeserializeObject<JObject>(standingsJson);
            Debug.WriteLine(jsonResponse["fantasy_content"]["league"]);
            var teams = jsonResponse["fantasy_content"]["league"]["standings"]["teams"]["team"];
            foreach (var team in teams)
            {
                if (team["team_id"].ToString() == teamId.ToString())
                {
                    return new Standings
                    {
                        Wins = (int)team["team_standings"]["outcome_totals"]["wins"],
                        Losses = (int)team["team_standings"]["outcome_totals"]["losses"],
                        Ties = (int)team["team_standings"]["outcome_totals"]["ties"],
                        Rank = (int)team["team_standings"]["rank"],
                        PointsFor = (double)team["team_standings"]["points_for"],
                        PointsAgainst = (double)team["team_standings"]["points_against"]
                    };
                }
            }

            return null;
        }

    }
}
