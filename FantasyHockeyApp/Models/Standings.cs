namespace Models
{
    public class Standings
    {
        public int Rank { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public double PointsFor { get; set; }
        public double PointsAgainst { get; set; }
    }
}
