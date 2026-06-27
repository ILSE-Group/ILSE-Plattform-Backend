using Domain.DomainObjects.Progresses;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.IProgressRepositories
{
    public interface IExerciseProgressRepository : IBaseRepository<ExerciseProgress>
    {
        Task<ExerciseProgress?> GetByUserAndExerciseAsync(Guid userId, Guid exerciseId);
        Task<IEnumerable<ExerciseProgress>> GetAllByUserIdAsync(Guid userId);
        Task<bool> IsExerciseCompletedAsync(Guid userId, Guid exerciseId);
        
    }
}