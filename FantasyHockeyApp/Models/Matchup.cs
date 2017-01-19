using System.Collections.Generic;

namespace Models
{
    public class Matchup
    {
        public int Week { get; set; }
        public string WeekStart { get; set; }
        public string WeekEnd { get; set; }
        public List<Team> Teams { get; set; }
        /// <summary>
        /// The dictionary contains each teams' current score. Key = TeamId, Value = Score
        /// </summary>
        public Dictionary<int, double> CurrentScore { get; set; }
    }
}
