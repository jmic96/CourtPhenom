namespace BasketballGame.Core.DTO
{
    public class CareerSnapshot
    {
        // League / Season summary
        public int CurrentLeague { get; set; } = 1;
        public int LastSeasonWins { get; set; }
        public int LastSeasonLosses { get; set; }
        public int LastSeasonSeed { get; set; }
        public bool LastSeasonChampions { get; set; }

        // Player
        public string PlayerName { get; set; } = "Player";
        public string Hometown { get; set; } = "Hometown";
        public string Position { get; set; } = "PG";
        public int Level { get; set; } = 5;
        public int CurrentXP { get; set; }
        public int StatPoints { get; set; } = 0;
        public int YearsPro { get; set; } = 0;

        public int Shooting { get; set; } = 50;
        public int Dribbling { get; set; } = 50;
        public int Finishing { get; set; } = 50;
        public int Passing { get; set; } = 50;
        public int Defense { get; set; } = 50;
    }
}
