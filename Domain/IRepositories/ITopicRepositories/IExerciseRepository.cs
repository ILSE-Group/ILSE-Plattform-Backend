using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.ITopicRepositories
{
    public interface IExerciseRepository : IBaseRepository<Exercise>
    {
        Task<List<Exercise>> GetExercisesByRoomIdAsync(Guid roomId);
        Task<List<Exercise>> GetExercisesByMinXpAsync(int minExperiencePoints);
    }
}