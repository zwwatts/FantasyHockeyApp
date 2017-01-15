using System.Collections.Generic;

namespace Models
{
    public class Team
    {
        public string TeamKey { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public Standings Standings { get; set; }
        public List<Player> Skaters { get; set; }
        public List<Player> Goalies { get; set; }
        public List<Stat> TotalStats { get; set; }
        public List<Stat> WeeklyStats { get; set; }
    }
}
