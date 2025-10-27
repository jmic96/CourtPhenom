namespace BasketballGame.Core.Players
{
    public enum Position { PG, SG, SF, PF, C }

    public class Player
    {
        public string Name { get; set; } = "Player";
        public string Hometown { get; set; } = "Hometown";
        public Position Position { get; set; } = Position.PG;

        public Stats Stats { get; } = new();
        public Progression Progression { get; } = new();

        public void SpendStatPoint(string stat, int amount = 1)
        {
            if (Progression.StatPoints < amount) return;

            switch (stat.ToLowerInvariant())
            {
                case "shooting":  Stats.Shooting  += amount; break;
                case "dribbling": Stats.Dribbling += amount; break;
                case "finishing": Stats.Finishing += amount; break;
                case "passing":   Stats.Passing   += amount; break;
                case "defense":   Stats.Defense   += amount; break;
            }
            Progression.StatPoints -= amount;
        }
    }
}
