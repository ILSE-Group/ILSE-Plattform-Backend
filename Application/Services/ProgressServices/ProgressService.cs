using Application.IServices.IProgressServices;
using Domain.DomainObjects.Progresses;
using Domain.IRepositories.IProgressRepositories;
using Domain.IRepositories.IUserRepositories;

namespace Application.Services.ProgressServices
{
    public class ProgressService(
        IUserRepository userRepo,
        IRoomProgressRepository roomProgressRepo,
        IExerciseProgressRepository exerciseProgressRepo) : IProgressService
    {
        private readonly IUserRepository _userRepo = userRepo;
        private readonly IRoomProgressRepository _roomProgressRepo = roomProgressRepo;
        private readonly IExerciseProgressRepository _exerciseProgressRepo = exerciseProgressRepo;

        public async Task<UserProgress?> GetUserProgressAsync(Guid userId)
        {
            var xp = await _userRepo.GetExperiencePointsAsync(userId);
            return UserProgress.Reconstruct(Guid.Empty, userId, xp);
        }

        public async Task<RoomProgress?> GetRoomProgressAsync(Guid userId, Guid roomId)
        {
            return await _roomProgressRepo.GetByUserAndRoomAsync(userId, roomId);
        }

        public async Task<ExerciseProgress?> GetExerciseProgressAsync(Guid userId, Guid exerciseId)
        {
            return await _exerciseProgressRepo.GetByUserAndExerciseAsync(userId, exerciseId);
        }

        public async Task MarkExerciseCompletedAsync(Guid userId, Guid exerciseId)
        {
            var existing = await _exerciseProgressRepo.GetByUserAndExerciseAsync(userId, exerciseId);

            if (existing is null)
            {
                var progress = ExerciseProgress.CreateNew(userId, exerciseId);
                progress.MarkAsCompleted();
                await _exerciseProgressRepo.AddAsync(progress);
            }
            else
            {
                existing.MarkAsCompleted();
                await _exerciseProgressRepo.UpdateAsync(existing);
            }
        }

        public async Task MarkRoomCompletedAsync(Guid userId, Guid roomId)
        {
            var existing = await _roomProgressRepo.GetByUserAndRoomAsync(userId, roomId);

            if (existing is null)
            {
                var progress = RoomProgress.CreateNew(userId, roomId);
                progress.MarkAsCompleted();
                await _roomProgressRepo.AddAsync(progress);
            }
            else
            {
                existing.MarkAsCompleted();
                await _roomProgressRepo.UpdateAsync(existing);
            }
        }
    }
}