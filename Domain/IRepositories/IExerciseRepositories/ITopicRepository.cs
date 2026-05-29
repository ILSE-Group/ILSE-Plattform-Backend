using Domain.DomainObjects.Topics;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.IExerciseRepositories
{
    public interface ITopicRepository : IBaseRepository<Topic>
    {
        Task<Topic> GetByNameAsync(string name);
        Task<IEnumerable<Topic>> GetTopicsByRoomIdAsync(Guid roomId);
        Task<IEnumerable<Topic>> GetCurrentTopicsWithRoomsAsync();
        Task AddRoomToTopicAsync(Guid topicId, Guid roomId);
        Task RemoveRoomFromTopicAsync(Guid topicId, Guid roomId);
    }
}
