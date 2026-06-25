using Domain.DomainObjects.Topics;

namespace Application.IServices.ITopicServices
{
    public interface IRoomService
    {
        Task<List<Room>> GetAllByTopicIdAsync(Guid topicId);
        Task<Room?> GetByIdAsync(Guid roomId);
    }
}
