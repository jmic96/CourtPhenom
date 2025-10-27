using System.Collections.Generic;
using System.Linq;
using BasketballGame.Core.Match;
using BasketballGame.Core.Teams;

namespace BasketballGame.Core.Season
{
    public class PlayoffSummary
    {
        public Team Seed1 { get; init; } = default!;
        public Team Seed2 { get; init; } = default!;
        public Team Seed3 { get; init; } = default!;
        public Team Seed4 { get; init; } = default!;
        public Team GameA_Winner { get; init; } = default!; // 4 vs 3
        public Team GameB_Winner { get; init; } = default!; // vs 2
        public Team Champion { get; init; } = default!;
    }

    public static class Playoffs
    {
        /// 4 vs 3 → winner vs 2 → winner vs 1
        public static PlayoffSummary RunTop4(IList<Team> seededTop4, MatchSimulator sim)
        {
            var s1 = seededTop4[0];
            var s2 = seededTop4[1];
            var s3 = seededTop4[2];
            var s4 = seededTop4[3];

            var ga = sim.Play(s4, s3).Winner;
            var gb = sim.Play(ga, s2).Winner;
            var champ = sim.Play(gb, s1).Winner;

            return new PlayoffSummary
            {
                Seed1 = s1, Seed2 = s2, Seed3 = s3, Seed4 = s4,
                GameA_Winner = ga, GameB_Winner = gb, Champion = champ
            };
        }

        public static List<Team> SeedByRecord(IEnumerable<Team> teams)
            => teams.OrderByDescending(t => t.Record.Wins).ThenBy(t => t.Record.Losses).ToList();
    }
}
