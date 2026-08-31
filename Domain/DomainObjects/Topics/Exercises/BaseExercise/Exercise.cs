namespace Domain.DomainObjects.Topics.Exercises.BaseExercise
{
    public abstract class Exercise
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int ExperiencePoints { get; private set; }

        protected Exercise() { }

        protected Exercise(Guid id, string title, string description, int experiencePoints)
        {
            Id = id;
            Title = title;
            Description = description;
            ExperiencePoints = experiencePoints;
        }

        public abstract bool ValidateAnswer(object answer);
    }
}
