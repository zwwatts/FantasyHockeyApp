using System;
using System.Collections.Generic;
using System.Linq;
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

            RefreshData();
            // from http://stackoverflow.com/questions/13019433/calling-method-on-every-x-minutes
            var timer = new System.Threading.Timer((e) =>
                                                   {
                                                       RefreshData();
                                                   }, null, 0, (int) TimeSpan.FromMinutes(RefreshInterval).TotalMilliseconds);
        }

        public event Action LeagueDataUpdated;

        public void RefreshData()
        {
            _league = _yahooApiClient.GetLeague(_leagueId);
            FireUpdateEvent();
        }

        private void FireUpdateEvent()
        {
            var handlers = LeagueDataUpdated;
            if (handlers == null) return;
            foreach (var handler in handlers.GetInvocationList())
            {
                try
                {
                    var action = (Action) handler;
                    action();
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }

        public LeagueInfo GetLeagueInfo()
        {
            return new LeagueInfo
                {
                    LeagueName = _league.Name
                };
        }

        public List<Team> GetTeams()
        {
            return _league.Teams;
        }

        public Team GetTeam(int teamId) => _league.Teams.First(team => team.TeamId == teamId);

        public List<Matchup> GetWeeklyMatchups() => _league.Matchups;
    }
}
