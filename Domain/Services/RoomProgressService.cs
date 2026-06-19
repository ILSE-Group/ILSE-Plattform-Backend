namespace Domain.Services
{
    public class RoomProgressService
    {
        // Returns true if all required IDs appear in the completed list.
        // <param name="required">All exercise/room IDs that must be completed.</param>
        // <param name="completed">The IDs the user has already completed.</param>
        public bool IsRoomCompleted(IEnumerable<Guid> required, IEnumerable<Guid> completed)
        {
            var completedSet = completed.ToHashSet();
            return required.All(id => completedSet.Contains(id));
        }

        // Returns the completion percentage (0.0 – 100.0).
        // Returns 100 if required is empty.
        // <param name="required">All exercise/room IDs that must be completed.</param>
        // <param name="completed">The IDs the user has already completed.</param>
        public double GetCompletionPercentage(IEnumerable<Guid> required, IEnumerable<Guid> completed)
        {
            var requiredList = required.ToList();

            if (requiredList.Count == 0)
                return 100.0;

            var completedSet = completed.ToHashSet();
            int doneCount = requiredList.Count(id => completedSet.Contains(id));

            return (double)doneCount / requiredList.Count * 100.0;
        }
    }
}