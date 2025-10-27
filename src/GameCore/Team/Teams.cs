using System.Collections.Generic;
using BasketballGame.Core.Players;

namespace BasketballGame.Core.Teams
{
    public class Team
    {
        public string Name { get; set; } = "Team";
        public List<Player> Players { get; } = new();
        public Record Record { get; } = new();

        public int OffenseRating()
        {
            int sum = 0;
            foreach (var p in Players)
                sum += p.Stats.Shooting + p.Stats.Passing + p.Stats.Finishing;
            return Players.Count == 0 ? 0 : sum / Players.Count;
        }

        public int DefenseRating()
        {
            int sum = 0;
            foreach (var p in Players)
                sum += p.Stats.Defense + p.Stats.Dribbling; // handling helps reduce TOs
            return Players.Count == 0 ? 0 : sum / Players.Count;
        }
    }
}
