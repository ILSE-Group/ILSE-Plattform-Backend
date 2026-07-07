using Application.DTOs;
using Domain.DomainObjects.Topics;

namespace Application.IServices.ITopicServices
{
    public interface ITopicService
    {
        Task<List<Topic>> GetAllAsync();
        Task<Topic?> GetByIdAsync(Guid id);
        Task<Topic> CreateAsync(TopicRequest request);
    }
}
