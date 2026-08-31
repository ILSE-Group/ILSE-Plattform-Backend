namespace Domain.DomainObjects.Progresses
{
    public class ExerciseProgress
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ExerciseId { get; private set; }
        public bool Completed { get; private set; }
        public int ExperiencePointsEarned { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public List<Guid> CompletedExercises { get; private set; }

        private ExerciseProgress(Guid id, Guid userId, Guid exerciseId, bool completed, int experiencePointsEarned, DateTime? completedAt, List<Guid> completedExercises)
        {
            Id = id;
            UserId = userId;
            ExerciseId = exerciseId;
            Completed = completed;
            ExperiencePointsEarned = experiencePointsEarned;
            CompletedAt = completedAt;
            CompletedExercises = completedExercises ?? [];
        }

        public static ExerciseProgress CreateNew(Guid userId, Guid exerciseId)
        {
            return new ExerciseProgress(Guid.NewGuid(), userId, exerciseId, false, 0, null, []);
        }

        public static ExerciseProgress Reconstruct(Guid id, Guid userId, Guid exerciseId, List<Guid> completedExercises)
        {
            return new ExerciseProgress(id, userId, exerciseId, false, 0, null, completedExercises ?? []);
        }

        public void MarkAsCompleted(int experiencePointsEarned = 0)
        {
            if (Completed)
            {
                return; // Already completed, no action needed
            }
            if (!CompletedExercises.Contains(ExerciseId))
            {
                CompletedExercises.Add(ExerciseId);
            }

            Completed = true;
            ExperiencePointsEarned = experiencePointsEarned;
            CompletedAt = DateTime.UtcNow;
        }
    }
}
