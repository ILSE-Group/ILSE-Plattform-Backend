using Domain.DomainObjects.Progresses;

namespace Application.IServices.IProgressServices
{
    public interface IProgressService
    {
        Task<UserProgress?> GetUserProgressAsync(Guid userId);
        Task<RoomProgress?> GetRoomProgressAsync(Guid userId, Guid roomId);
        Task<ExerciseProgress?> GetExerciseProgressAsync(Guid userId, Guid exerciseId);

        Task MarkExerciseCompletedAsync(Guid userId, Guid exerciseId);
        Task MarkRoomCompletedAsync(Guid userId, Guid roomId);
    }
}