using System.Collections.Generic;

namespace Models
{
    public class Player
    {
        public string PlayerKey { get; set; }
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EditorialTeamKey { get; set; }
        public string EditorialTeamName { get; set; }
        public string EditorialTeamAbbr { get; set; }
        public int UniformNumber { get; set; }
        public List<Stat> Stats { get; set; }
        public string Position { get; set; }
        public string PositionType { get; set; }
    }
}
