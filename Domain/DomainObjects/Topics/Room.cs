using Domain.DomainObjects.Topics.Exercises.BaseExercise;

namespace Domain.DomainObjects.Topics
{
    public class Room
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int UnlockLevel { get; private set; }
        public int CompletionExperiencePoints { get; private set; }

        private readonly List<Exercise> _exercises;
        public IReadOnlyList<Exercise> Exercises => _exercises;

        private Room(Guid id, string name, int unlockLevel, int completionExperiencePoints)
        {
            Id = id;
            Name = name;
            UnlockLevel = unlockLevel;
            CompletionExperiencePoints = completionExperiencePoints;
            _exercises = [];
        }

        public static Room CreateNew(string name, int unlockLevel, int completionExperiencePoints)
        {
            return new Room(Guid.NewGuid(), name, unlockLevel, completionExperiencePoints);
        }

        public static Room Reconstruct(Guid id, string name, int unlockLevel, int completionExperiencePoints)
        {
            return new Room(id, name, unlockLevel, completionExperiencePoints);
        }
    }
}
