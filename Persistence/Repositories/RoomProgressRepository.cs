using Domain.DomainObjects.Progresses;
using Domain.IRepositories.IRoomProgressRepositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class RoomProgressRepository(AppDbContext context) : IRoomProgressRepository
    {
        private readonly AppDbContext _context = context;

        // ── IBaseRepository ──────────────────────────────────────────────────

        public async Task<RoomProgress> AddAsync(RoomProgress progress)
        {
            await _context.RoomProgresses.AddAsync(progress);
            await _context.SaveChangesAsync();
            return progress;
        }

        public async Task DeleteAsync(Guid id)
        {
            var progress = await GetByIdAsync(id);
            if (progress is not null)
            {
                _context.RoomProgresses.Remove(progress);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<RoomProgress> UpdateAsync(RoomProgress progress)
        {
            _context.RoomProgresses.Update(progress);
            await _context.SaveChangesAsync();
            return progress;
        }

        public async Task<RoomProgress?> GetByIdAsync(Guid id)
            => await _context.RoomProgresses.FirstOrDefaultAsync(rp => rp.Id == id);

        public async Task<IEnumerable<RoomProgress>> GetAllAsync()
            => await _context.RoomProgresses.ToListAsync();

        // ── IRoomProgressRepository ──────────────────────────────────────────

        public async Task<RoomProgress?> GetByUserAndRoomAsync(Guid userId, Guid roomId)
            => await _context.RoomProgresses
                .FirstOrDefaultAsync(rp => rp.UserId == userId && rp.RoomId == roomId);

        public async Task<IEnumerable<RoomProgress>> GetAllByUserIdAsync(Guid userId)
            => await _context.RoomProgresses
                .Where(rp => rp.UserId == userId)
                .ToListAsync();

        public async Task<bool> IsRoomCompletedAsync(Guid userId, Guid roomId)
        {
            var progress = await GetByUserAndRoomAsync(userId, roomId);
            return progress is not null && progress.CompletedRooms.Contains(roomId);
        }
    }
}