namespace BasketballGame.Core.Players
{
    public class Progression
    {
        public int Level { get; set; } = 5;
        public int CurrentExperience { get; set; } = 0;
        public int StatPoints { get; set; } = 0;
        public int YearsPro { get; set; } = 0;

        public int ExperienceToNextLevel => Level * 100;

        public void AddExperience(int amount)
        {
            CurrentExperience += amount;
            while (CurrentExperience >= ExperienceToNextLevel)
            {
                CurrentExperience -= ExperienceToNextLevel;
                Level++;
                StatPoints += 5;
            }
        }
    }
}
