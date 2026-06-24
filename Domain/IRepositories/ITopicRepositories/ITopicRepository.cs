using Domain.DomainObjects.Topics;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.ITopicRepositories
{
    public interface ITopicRepository : IBaseRepository<Topic>
    {
        Task<Topic> GetByNameAsync(string name);
        Task<IEnumerable<Topic>> GetTopicsByRoomIdAsync(Guid roomId);
        Task<IEnumerable<Topic>> GetAllWithRoomsAsync();
        Task AddRoomToTopicAsync(Guid topicId, Guid roomId);
        Task RemoveRoomFromTopicAsync(Guid topicId, Guid roomId);
    }
}
