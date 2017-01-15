using System;
using Models;

namespace YahooApi
{
    public class LeagueDataLayer
    {
        private readonly Yahoo _yahooApiClient = new Yahoo();
        private readonly int _leagueId;
        private League _league;
        public int RefreshInterval { get; } = 15;

        public LeagueDataLayer(int leagueId)
        {
            _leagueId = leagueId;

            // from http://stackoverflow.com/questions/13019433/calling-method-on-every-x-minutes
            var timer = new System.Threading.Timer((e) =>
            {
                RefreshData();
            }, null, 0, (int)TimeSpan.FromMinutes(RefreshInterval).TotalMilliseconds);
        }

        public void RefreshData()
        {
            _league = _yahooApiClient.GetLeague(_leagueId);
        }

        public LeagueInfo GetLeagueInfo()
        {
            return new LeagueInfo
                {
                    LeagueName = _league.Name
                };
        }


    }
}
