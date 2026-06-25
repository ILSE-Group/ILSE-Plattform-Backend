using Application.IServices.ITopicServices;
using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.IRepositories.ITopicRepositories;

namespace Application.Services.TopicServices
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Exercise?> GetByIdAsync(Guid exerciseId)
        {
            return await _exerciseRepository.GetByIdAsync(exerciseId);
        }

        public async Task<List<Exercise>> GetExercisesByRoomAsync(Guid roomId)
        {
            return await _exerciseRepository.GetExercisesByRoomIdAsync(roomId);
        }
    }
}
