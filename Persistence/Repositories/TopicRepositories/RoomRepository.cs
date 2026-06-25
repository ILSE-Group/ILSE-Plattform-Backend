using Domain.DomainObjects.Topics;
using Domain.IRepositories.IRoomRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.BaseRepository;

namespace Persistence.Repositories.TopicRepositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context)
        {
            // Constructor calls base class constructor -> no further initialization needed here
        }

        public async Task<Room?> GetByNameAsync(string name)
            => await _context.Rooms
                .FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower());

        public async Task<IEnumerable<Room>> GetRoomsByMaxUnlockLevelAsync(int maxLevel)
            => await _context.Rooms
                .Where(r => r.UnlockLevel <= maxLevel)
                .OrderBy(r => r.UnlockLevel)
                .ToListAsync();

        public async Task<IEnumerable<Room>> GetRoomsByTopicIdAsync(Guid topicId)
            => await _context.Topics
                .Where(t => t.Id == topicId)
                .SelectMany(t => t.Rooms)
                .Include(r => r.Exercises)
                .ToListAsync();

        public async Task<Room?> GetByIdWithExercisesAsync(Guid roomId)
            => await _context.Rooms
                .Include(r => r.Exercises)
                .FirstOrDefaultAsync(r => r.Id == roomId);
    }
}