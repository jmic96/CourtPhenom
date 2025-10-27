using System.Collections.Generic;
using BasketballGame.Core.DTO;

namespace BasketballGame.Core.League
{
    public class LeagueService
    {
        public int CurrentLeague { get; private set; } = 1;
        public LeagueConfig CurrentConfig { get; private set; } = new LeagueConfig();

        private readonly List<LeagueConfig> _leagues;

        public LeagueService(List<LeagueConfig> leagues)
        {
            _leagues = leagues ?? new List<LeagueConfig> { new LeagueConfig { Id = 1, Name = "League 1" } };
            SetLeague(1);
        }

        public void SetLeague(int id)
        {
            CurrentLeague = id;
            CurrentConfig = _leagues.Find(l => l.Id == id) ?? _leagues[0];
        }

        public void Promote()
        {
            if (CurrentLeague < 10) SetLeague(CurrentLeague + 1);
        }

        public void Demote()
        {
            if (CurrentLeague > 1) SetLeague(CurrentLeague - 1);
        }
    }
}
