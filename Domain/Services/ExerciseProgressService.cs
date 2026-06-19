namespace Domain.Services
{
    public class ExerciseProgressService
    {
        // Returns true if all required exercise IDs appear in the completed list.
        // <param name="required">All exercise IDs that belong to the room.</param>
        // <param name="completed">The exercise IDs the user has already completed.</param>
        public bool IsExerciseCompleted(IEnumerable<Guid> required, IEnumerable<Guid> completed)
        {
            var completedSet = completed.ToHashSet();
            return required.All(completedSet.Contains);
        }

        // Returns the completion percentage (0.0 – 100.0).
        // Returns 100 if required is empty.
        // <param name="required">All exercise IDs that belong to the room.</param>
        // <param name="completed">The exercise IDs the user has already completed.</param>
        public double GetCompletionPercentage(IEnumerable<Guid> required, IEnumerable<Guid> completed)
        {
            var requiredList = required.ToList();

            if (requiredList.Count == 0)
                return 100.0;

            var completedSet = completed.ToHashSet();
            int doneCount = requiredList.Count(completedSet.Contains);

            return (double)doneCount / requiredList.Count * 100.0;
        }
    }
}