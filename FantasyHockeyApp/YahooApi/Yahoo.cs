namespace YahooApi
{
    public class Yahoo
    {
        public Yahoo()
        {

        }

        public string GetLeague(int leagueId)
        {
            var oauthQuery = new OAuthQuery();
            return oauthQuery.QueryWithOAuth($"http://fantasysports.yahooapis.com/fantasy/v2/league/363.l.{leagueId}");
        }
    }
}
