namespace BasketballGame.Core.Teams
{
    public static class Ratings
    {
        public static int ClampScore(int raw) => raw < 40 ? 40 : raw;
    }
}
