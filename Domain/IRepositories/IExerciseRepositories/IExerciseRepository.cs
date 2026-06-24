using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.IExerciseRepositories
{
    public interface IExerciseRepository : IBaseRepository<Exercise>
    {
        Task<IEnumerable<Exercise>> GetExercisesByRoomIdAsync(Guid roomId);
        Task<IEnumerable<Exercise>> GetExercisesByMinXpAsync(int minExperiencePoints);
    }
}