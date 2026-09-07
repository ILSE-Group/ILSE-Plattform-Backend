using Domain.DomainObjects.Progresses;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.IProgressRepositories
{
    public interface IUserProgressRepository : IBaseRepository<UserProgress>
    {
        Task<UserProgress?> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<UserProgress>> GetAllByUserIdAsync(Guid userId);
        Task<UserProgress?> GetByUserAndExerciseAsync(Guid userId, Guid exerciseId);
        Task<bool> IsExerciseCompletedAsync(Guid userId, Guid exerciseId);
    }
}