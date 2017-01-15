using System.Collections.Generic;

namespace Models
{
    public class Team
    {
        public string TeamKey { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public Standings Standings { get; set; }
        public List<Player> Roster { get; set; }
        public List<Stat> TotalStats { get; set; }
        public List<Stat> WeeklyStats { get; set; }
    }
}
