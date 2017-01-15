using System.Collections.Generic;

namespace Models
{
    public class Player
    {
        string PlayerKey { get; set; }
        int PlayerId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string EditorialTeamKey { get; set; }
        string EditorialTeamName { get; set; }
        string EditorialTeamAbbr { get; set; }
        int UniformNumber { get; set; }
        public List<Stat> Stats { get; set; }
        Position Position { get; set; }
    }
}
