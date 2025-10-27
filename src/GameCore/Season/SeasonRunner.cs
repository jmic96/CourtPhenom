using System;
using System.Collections.Generic;
using System.Linq;
using BasketballGame.Core.DTO;
using BasketballGame.Core.League;
using BasketballGame.Core.Match;
using BasketballGame.Core.Teams;

namespace BasketballGame.Core.Season
{
    public class SeasonRunner
    {
        public LeagueService League { get; }
        public MatchSimulator Simulator { get; }

        public SeasonRunner(LeagueService league, MatchSimulator simulator)
        {
            League = league;
            Simulator = simulator;
        }

        public (List<Team> standings, PlayoffSummary? playoffs, bool playerChamp, int playerSeed)
            RunSeason(List<Team> teams, Team playerTeam, int gamesPerTeam)
        {
            ResetRecords(teams);

            // round-robin-ish: pair randomly until everyone hits the cap
            var rng = new Random();
            while (teams.Any(t => t.Record.Games < gamesPerTeam))
            {
                var a = teams[rng.Next(teams.Count)];
                var b = teams[rng.Next(teams.Count)];
                if (a == b) continue;
                if (a.Record.Games >= gamesPerTeam || b.Record.Games >= gamesPerTeam) continue;

                var result = Simulator.Play(a, b);
                var winner = result.Winner;
                var loser = winner == a ? b : a;

                winner.Record.Wins++;
                loser.Record.Losses++;
            }

            var standings = Playoffs.SeedByRecord(teams);
            int seed = standings.FindIndex(t => t == playerTeam) + 1;

            // Top 4 playoffs
            PlayoffSummary? po = null;
            bool champ = false;

            if (standings.Count >= 4)
            {
                var top4 = standings.Take(4).ToList();
                po = Playoffs.RunTop4(top4, Simulator);
                champ = po.Champion == playerTeam;
            }

            return (standings, po, champ, seed);
        }

        private void ResetRecords(IEnumerable<Team> teams)
        {
            foreach (var t in teams)
            {
                t.Record.Wins = 0;
                t.Record.Losses = 0;
            }
        }

        public void ApplyPromotionRules(Team playerTeam, int playerSeed, bool playerChamp)
        {
            if (playerChamp) League.Promote();
            else if (playerSeed > 4) League.Demote();
            // else: stay
        }
    }
}
