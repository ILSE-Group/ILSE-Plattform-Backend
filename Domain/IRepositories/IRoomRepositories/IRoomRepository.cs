using Domain.DomainObjects.Topics;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.IRoomRepositories
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        Task<Room?> GetByNameAsync(string name);
        Task<IEnumerable<Room>> GetRoomsByMaxUnlockLevelAsync(int maxLevel);
        Task<IEnumerable<Room>> GetRoomsByTopicIdAsync(Guid topicId);
        Task<Room?> GetByIdWithExercisesAsync(Guid roomId);
    }
}