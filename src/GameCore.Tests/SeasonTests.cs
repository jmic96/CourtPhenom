using System.Collections.Generic;
using BasketballGame.Core.League;
using BasketballGame.Core.Match;
using BasketballGame.Core.Players;
using BasketballGame.Core.Season;
using BasketballGame.Core.Teams;
using Xunit;

public class SeasonTests
{
    private Team MakeTeam(string name)
    {
        var t = new Team { Name = name };
        t.Players.Add(new Player { Name = $"{name} P1", Stats = { Shooting = 70, Passing = 65, Finishing = 60, Defense = 60, Dribbling = 60 }});
        t.Players.Add(new Player { Name = $"{name} P2", Stats = { Shooting = 65, Passing = 60, Finishing = 60, Defense = 60, Dribbling = 55 }});
        return t;
    }

    [Fact]
    public void Season_Completes_And_Seeds_Player()
    {
        var leagues = new List<BasketballGame.Core.DTO.LeagueConfig> { new() { Id = 1, GamesPerTeamRegularSeason = 8, AiTeamsInLeague = 3 } };
        var leagueSvc = new LeagueService(leagues);
        var sim = new MatchSimulator(seed: 123);
        var season = new SeasonRunner(leagueSvc, sim);

        var playerTeam = MakeTeam("Player");
        var t2 = MakeTeam("AI2");
        var t3 = MakeTeam("AI3");
        var t4 = MakeTeam("AI4");

        var teams = new List<Team> { playerTeam, t2, t3, t4 };

        var (standings, po, champ, seed) = season.RunSeason(teams, playerTeam, gamesPerTeam: 8);

        Assert.Equal(4, standings.Count);
        Assert.InRange(seed, 1, 4);
        Assert.NotNull(po);
    }
}
