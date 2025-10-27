namespace BasketballGame.Core.Teams
{
    public class Record
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Games => Wins + Losses;
    }
}
