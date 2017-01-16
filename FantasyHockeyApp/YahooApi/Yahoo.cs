using System.Text.RegularExpressions;
using System.Xml;
using Models;
using Newtonsoft.Json;

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
                       Name = Regex.Match(leagueQueryResults, @"<name>(.+?)</name>").Groups[1].Value
                   };
        }
    }
}
