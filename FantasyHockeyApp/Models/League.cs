using System.Collections.Generic;

namespace Models
{
    public class League
    {
        public string LeagueKey { get; set; }
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
        public List<Matchup> Matchups { get; set; }
        public List<StatCategory> StatCategories { get; set; }
    }
}
