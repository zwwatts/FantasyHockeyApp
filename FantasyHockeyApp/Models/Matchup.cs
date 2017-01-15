using System.Collections.Generic;

namespace Models
{
    public class Matchup
    {
        public int Week { get; set; }
        public string WeekStart { get; set; }
        public string WeekEnd { get; set; }
        private List<Team> Teams { get; set; }
    }
}
