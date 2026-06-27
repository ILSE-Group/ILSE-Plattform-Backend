using Application.IServices.ITopicServices;
using Domain.DomainObjects.Topics;
using Domain.IRepositories.ITopicRepositories;

namespace Application.Services.TopicServices
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<List<Topic>> GetAllAsync()
        {
            return await _topicRepository.GetAllAsync();
        }

        public async Task<Topic?> GetByIdAsync(Guid id)
        {
            return await _topicRepository.GetByIdAsync(id);
        }
    }
}
