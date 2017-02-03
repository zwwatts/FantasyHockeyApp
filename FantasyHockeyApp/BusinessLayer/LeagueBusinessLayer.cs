using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using YahooApi;

namespace BusinessLayer
{
    public class LeagueBusinessLayer
    {
        private readonly LeagueDataLayer _dataLayer;
        private const string GoalieCode = "G";
        private const string SkaterCode = "P";

        public LeagueBusinessLayer(int leagueId)
        {
            _dataLayer = new LeagueDataLayer() {LeagueId = leagueId};
            _dataLayer.LeagueDataUpdated += FireUpdateEvent;
        }

        public event Action<int> LeagueDataUpdated;

        public List<Team> GetTeams() => _dataLayer?.GetTeams();

        public void SetLeagueId(int leagueId)
        {
            if(leagueId == _dataLayer.LeagueId) return;
            _dataLayer.LeagueId = leagueId;
            _dataLayer?.ResetInterval();
        }

        public Team GetTeam(int teamId) => _dataLayer?.GetTeam(teamId);

        public LeagueInfo GetLeagueInfo() => _dataLayer?.GetLeagueInfo();

        public List<string> GetSkaterStatColumnHeaders() => _dataLayer?.GetStatCategories()?.Where(category => category?.PositionType == SkaterCode).Select(category => category.DisplayName).ToList();

        public List<string> GetGoalieStatColumnHeaders() => _dataLayer?.GetStatCategories()?.Where(category => category?.PositionType == GoalieCode).Select(category => category.DisplayName).ToList();

        public List<Matchup> GetWeeklyMatchups() => _dataLayer?.GetWeeklyMatchups();

        private void FireUpdateEvent()
        {
            var handlers = LeagueDataUpdated;
            if (handlers == null) return;
            foreach (var handler in handlers.GetInvocationList())
            {
                try
                {
                    var action = (Action<int>)handler;
                    action(_dataLayer.LeagueId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
    }
}
