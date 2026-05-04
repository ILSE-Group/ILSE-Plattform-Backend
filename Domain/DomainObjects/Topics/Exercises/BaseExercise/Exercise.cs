namespace Domain.DomainObjects.Topics.Exercises.BaseExercise
{
    public abstract class Exercise
    {
        public Guid Id { get; }
        string Title { get; }
        string Description { get; }
        int ExperiencePoints { get; }

        protected Exercise(Guid id, string title, string description, int experiencePoints)
        {
            Id = id;
            Title = title;
            Description = description;
            ExperiencePoints = experiencePoints;
        }

        public abstract Exercise ValidateAnswer(object answer);
    }
}
