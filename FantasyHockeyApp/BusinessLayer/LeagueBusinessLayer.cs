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

        public LeagueBusinessLayer()
        {
            _dataLayer = new LeagueDataLayer();
            _dataLayer.LeagueDataUpdated += FireUpdateEvent;
        }

        public LeagueBusinessLayer(int leagueId)
        {
            _dataLayer = new LeagueDataLayer() {LeagueId = leagueId};
            _dataLayer.LeagueDataUpdated += FireUpdateEvent;
        }

        public event Action<int> LeagueDataUpdated;

        public List<Team> GetTeams()
        {
            return _dataLayer.GetTeams();
        }

        public void SetLeagueId(int leagueId)
        {
            _dataLayer.LeagueId = leagueId;
            _dataLayer.RefreshData();
        }

        public Team GetTeam(int teamId)
        {
            return _dataLayer.GetTeam(teamId);
        }

        public List<Player> GetPlayers()
        {
            return null;
        }

        public LeagueInfo GetLeagueInfo()
        {
            return _dataLayer.GetLeagueInfo();
        }

        public List<Standings> GetLeagueStandings()
        {
            return null;
        }

        public List<string> GetSkaterStatColumnHeaders()
        {
            return _dataLayer.GetStatCategories().Where(category => category.PositionType == SkaterCode).Select(category => category.DisplayName).ToList();
        }

        public List<string> GetGaolieStatColumnHeaders()
        {
            return _dataLayer.GetStatCategories().Where(category => category.PositionType == GoalieCode).Select(category => category.DisplayName).ToList();
        }

        public List<Matchup> GetWeeklyMatchups()
        {
            return _dataLayer.GetWeeklyMatchups();
        }

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
