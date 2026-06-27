using Application.IServices.ITopicServices;
using Domain.DomainObjects.Topics;
using Domain.IRepositories.IRoomRepositories;

namespace Application.Services.TopicServices
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<List<Room>> GetAllByTopicIdAsync(Guid topicId)
        {
            return await _roomRepository.GetRoomsByTopicIdAsync(topicId);
        }

        public async Task<Room?> GetByIdAsync(Guid roomId)
        {
            return await _roomRepository.GetByIdAsync(roomId);
        }
    }
}
