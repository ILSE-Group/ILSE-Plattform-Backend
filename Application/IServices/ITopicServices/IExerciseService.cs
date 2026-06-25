using Domain.DomainObjects.Topics.Exercises.BaseExercise;

namespace Application.IServices.ITopicServices
{
    public interface IExerciseService
    {
        Task<List<Exercise>> GetExercisesByRoomAsync(Guid roomId);
        Task<Exercise?> GetByIdAsync(Guid exerciseId);
    }
}
