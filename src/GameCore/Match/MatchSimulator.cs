using System;
using BasketballGame.Core.Teams;

namespace BasketballGame.Core.Match
{
    public class MatchResult
    {
        public Team Home { get; init; } = default!;
        public Team Away { get; init; } = default!;
        public Team Winner { get; init; } = default!;
        public int HomeScore { get; init; }
        public int AwayScore { get; init; }
    }

    public class MatchSimulator
    {
        private readonly Random _rng;
        public int BaseXpPerPlayer { get; set; } = 200;
        public int WinBonusPerPlayer { get; set; } = 150;

        public MatchSimulator(int? seed = null)
        {
            _rng = seed.HasValue ? new Random(seed.Value) : new Random();
        }

        public MatchResult Play(Team home, Team away)
        {
            int hOff = home.OffenseRating();
            int aOff = away.OffenseRating();
            int hDef = home.DefenseRating();
            int aDef = away.DefenseRating();

            int homeScore = Ratings.ClampScore((int)Math.Round(50 + (hOff - aDef) * 0.3 + Rand(-10, 10)));
            int awayScore = Ratings.ClampScore((int)Math.Round(50 + (aOff - hDef) * 0.3 + Rand(-10, 10)));

            var winner = homeScore >= awayScore ? home : away;

            AwardXp(home, winner == home);
            AwardXp(away, winner == away);

            return new MatchResult
            {
                Home = home, Away = away, Winner = winner,
                HomeScore = homeScore, AwayScore = awayScore
            };
        }

        private void AwardXp(Team t, bool won)
        {
            foreach (var p in t.Players)
                p.Progression.AddExperience(BaseXpPerPlayer + (won ? WinBonusPerPlayer : 0));
        }

        private int Rand(int min, int max) => _rng.Next(min, max + 1);
    }
}
