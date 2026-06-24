using Domain.DomainObjects.Topics;
using Domain.IRepositories.ITopicRepositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class TopicRepository(AppDbContext context) : ITopicRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Topic> AddAsync(Topic topic)
        {
            await _context.Topics.AddAsync(topic);
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task DeleteAsync(Guid id)
        {
            var topic = await GetByIdAsync(id);
            if (topic is not null)
            {
                _context.Topics.Remove(topic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Topic> UpdateAsync(Topic topic)
        {
            _context.Topics.Update(topic);
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task<Topic?> GetByIdAsync(Guid id)
            => await _context.Topics
                .Include(t => t.Rooms)
                .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<IEnumerable<Topic>> GetAllAsync()
            => await _context.Topics
                .Include(t => t.Rooms)
                .ToListAsync();

        public async Task<Topic?> GetByNameAsync(string name)
            => await _context.Topics
                .Include(t => t.Rooms)
                .FirstOrDefaultAsync(t => t.Name.ToLower() == name.ToLower());

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
    }
}