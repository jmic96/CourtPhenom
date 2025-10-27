using System.Collections.Generic;
using BasketballGame.Core.Match;
using BasketballGame.Core.Players;
using BasketballGame.Core.Season;
using BasketballGame.Core.Teams;
using Xunit;

public class PlayoffTests
{
    private Team T(string n, int s)
    {
        var t = new Team { Name = n };
        t.Players.Add(new Player { Name = n + " P", Stats = { Shooting = s, Passing = s, Finishing = s, Defense = s, Dribbling = s }});
        return t;
    }

    [Fact]
    public void Top4Bracket_Produces_Champion()
    {
        var sim = new MatchSimulator(seed: 42);
        var seeded = new List<Team> { T("S1",80), T("S2",75), T("S3",70), T("S4",65) };

        var po = Playoffs.RunTop4(seeded, sim);
        Assert.NotNull(po.Champion);
    }
}
