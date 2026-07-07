using Domain.DomainObjects.Topics;
using Domain.IRepositories.ITopicRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.BaseRepository;

namespace Persistence.Repositories.TopicRepositories
{
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        public TopicRepository(AppDbContext context) : base(context)
        {
            // Constructor calls base class constructor -> no further initialization needed here
        }

        public async Task<IEnumerable<Topic>> GetTopicsByRoomIdAsync(Guid roomId)
            => await _context.Topics
                .Include(t => t.Rooms)
                .Where(t => t.Rooms.Any(r => r.Id == roomId))
                .ToListAsync();

        public async Task<IEnumerable<Topic>> GetAllWithRoomsAsync()
            => await _context.Topics
                .Include(t => t.Rooms)
                    .ThenInclude(r => r.Exercises)
                .ToListAsync();

        public async Task AddRoomToTopicAsync(Guid topicId, Guid roomId)
        {
            var topic = await _context.Topics
                .Include(t => t.Rooms)
                .FirstOrDefaultAsync(t => t.Id == topicId)
                ?? throw new KeyNotFoundException($"Topic {topicId} not found.");

            var room = await _context.Rooms
                .FirstOrDefaultAsync(r => r.Id == roomId)
                ?? throw new KeyNotFoundException($"Room {roomId} not found.");

            topic.AddRoom(room);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRoomFromTopicAsync(Guid topicId, Guid roomId)
        {
            var topic = await _context.Topics
                .Include(t => t.Rooms)
                .FirstOrDefaultAsync(t => t.Id == topicId)
                ?? throw new KeyNotFoundException($"Topic {topicId} not found.");

            var room = topic.Rooms.FirstOrDefault(r => r.Id == roomId);
            if (room is not null)
            {
                topic.RemoveRoom(room);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Topic> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}