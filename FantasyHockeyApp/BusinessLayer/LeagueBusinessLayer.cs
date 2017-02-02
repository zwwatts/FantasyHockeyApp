using System;
using Models;
using System.Collections.Generic;
using YahooApi;

namespace BusinessLayer
{
    public class LeagueBusinessLayer
    {
        private readonly LeagueDataLayer _dataLayer;
        public LeagueBusinessLayer(int leagueId)
        {
            _dataLayer = new LeagueDataLayer(leagueId);
        }

        public event Action LeagueDataUpdated;

        public List<Team> GetTeams()
        {
            return _dataLayer.GetTeams();
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

        public List<Matchup> GetWeeklyMatchups()
        {
            return _dataLayer.GetWeeklyMatchups();
        }
    }
}
