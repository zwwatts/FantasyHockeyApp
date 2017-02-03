using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Models;

namespace YahooApi
{
    public class LeagueDataLayer
    {
        private readonly Yahoo _yahooApiClient = new Yahoo();
        public  int LeagueId { get; set; }
        private League _league;
        private readonly Timer _timer;
        public int RefreshInterval { get; } = 1;

        public LeagueDataLayer()
        {
            // from http://stackoverflow.com/questions/13019433/calling-method-on-every-x-minutes
            _timer = new Timer((e) =>
                                    {
                                        RefreshData();
                                    }, null, 0, (int) TimeSpan.FromMinutes(RefreshInterval).TotalMilliseconds);
        }

        public event Action LeagueDataUpdated;

        public void ResetInterval() => _timer.Change(0, (int)TimeSpan.FromMinutes(RefreshInterval).TotalMilliseconds);

        private void RefreshData()
        {
            if (LeagueId <= 0) return;
            Task.Run(() => Console.WriteLine("Refreshing Data"));
            _league = _yahooApiClient.GetLeague(LeagueId);
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
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        public LeagueInfo GetLeagueInfo() => new LeagueInfo
                                             {
                                                 LeagueName = _league?.Name
                                             };

        public List<Team> GetTeams() => _league?.Teams;

        public Team GetTeam(int teamId) => _league?.Teams.FirstOrDefault(team => team.TeamId == teamId);

        public List<StatCategory> GetStatCategories() => _league?.StatCategories;

        public List<Matchup> GetWeeklyMatchups() => _league?.Matchups;
    }
}
