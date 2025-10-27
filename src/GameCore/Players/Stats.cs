namespace BasketballGame.Core.Players
{
    public class Stats
    {
        public int Shooting { get; set; }
        public int Dribbling { get; set; }
        public int Finishing { get; set; }
        public int Passing  { get; set; }
        public int Defense  { get; set; }

        public int Average => (Shooting + Dribbling + Finishing + Passing + Defense) / 5;
    }
}
