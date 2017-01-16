﻿using Models;
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

        public List<Team> GetTeams()
        {
            return null;
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
    }
}