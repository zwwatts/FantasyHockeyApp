using System.Text.RegularExpressions;
using Models;

namespace YahooApi
{
    public class Yahoo
    {
        public Yahoo()
        {

        }

        public League GetLeague(int leagueId)
        {
            var oauthQuery = new OAuthQuery();
            var leagueQueryResults = oauthQuery.QueryWithOAuth($"http://fantasysports.yahooapis.com/fantasy/v2/league/363.l.{leagueId}");

            return new League
                   {
                       LeagueId = leagueId,
                       LeagueKey = Regex.Match(leagueQueryResults, @"<league_key>(.+?)</league_key>").Groups[1].Value,
                       Name = Regex.Match(leagueQueryResults, @"<name>(.+?)</name>").Groups[1].Value
                   };
        }
    }
}
