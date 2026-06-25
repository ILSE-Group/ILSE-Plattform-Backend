using Domain.DomainObjects.Progresses;
using Domain.IRepositories.IProgressRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.BaseRepository;

namespace Persistence.Repositories.ProgressRepository
{
    public class RoomProgressRepository : BaseRepository<RoomProgress>, IRoomProgressRepository
    {
        public RoomProgressRepository(AppDbContext context) : base(context)
        {
            // Constructor calls base class constructor -> no further initialization needed here
        }

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