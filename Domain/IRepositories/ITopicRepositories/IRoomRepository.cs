using Domain.DomainObjects.Topics;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.IRoomRepositories
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        Task<Room?> GetByNameAsync(string name);
        Task<List<Room>> GetRoomsByMaxUnlockLevelAsync(int maxLevel);
        Task<List<Room>> GetRoomsByTopicIdAsync(Guid topicId);
        Task<Room?> GetByIdWithExercisesAsync(Guid roomId);
    }
}