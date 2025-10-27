using System.IO;
using BasketballGame.Core.DTO;
using BasketballGame.Core.Persistence;
using Xunit;

public class SaveLoadTests
{
    [Fact]
    public void Save_Then_Load_Works()
    {
        string path = Path.Combine(Path.GetTempPath(), "career_save_test.json");
        if (File.Exists(path)) File.Delete(path);

        var svc = new SaveService(path);
        var snap = new CareerSnapshot { PlayerName = "Test", CurrentLeague = 3, LastSeasonWins = 18, LastSeasonLosses = 6 };
        svc.Save(snap);

        var loaded = svc.Load();
        Assert.NotNull(loaded);
        Assert.Equal(3, loaded!.CurrentLeague);
        Assert.Equal("Test", loaded.PlayerName);

        File.Delete(path);
    }
}
