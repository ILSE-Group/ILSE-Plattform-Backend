using Domain.DomainObjects.Topics;
using Domain.IRepositories.IRoomRepositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class RoomRepository(AppDbContext context) : IRoomRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Room> AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task DeleteAsync(Guid id)
        {
            var room = await GetByIdAsync(id);
            if (room is not null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Room> UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room?> GetByIdAsync(Guid id)
            => await _context.Rooms
                .FirstOrDefaultAsync(r => r.Id == id);

        public async Task<IEnumerable<Room>> GetAllAsync()
            => await _context.Rooms.ToListAsync();

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