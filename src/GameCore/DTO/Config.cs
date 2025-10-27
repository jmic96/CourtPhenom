using System.Collections.Generic;

namespace BasketballGame.Core.DTO
{
    public class LeagueConfig
    {
        public int Id { get; set; }
        public string Name { get; set; } = "League";
        public int GamesPerTeamRegularSeason { get; set; } = 24;
        public int AiTeamsInLeague { get; set; } = 7; // +1 player team
    }

    public class TuningConfig
    {
        public int XpPerTrain { get; set; } = 850;
        public int BaseXpPerPlayer { get; set; } = 200;
        public int WinBonusPerPlayer { get; set; } = 150;
    }

    public class GameConfig
    {
        public List<LeagueConfig> Leagues { get; set; } = new();
        public TuningConfig Tuning { get; set; } = new();
    }
}
