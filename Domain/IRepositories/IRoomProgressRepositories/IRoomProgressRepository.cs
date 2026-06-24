using Domain.DomainObjects.Progresses;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.IRoomProgressRepositories
{
    public interface IRoomProgressRepository : IBaseRepository<RoomProgress>
    {
        Task<RoomProgress?> GetByUserAndRoomAsync(Guid userId, Guid roomId);
        Task<IEnumerable<RoomProgress>> GetAllByUserIdAsync(Guid userId);
        Task<bool> IsRoomCompletedAsync(Guid userId, Guid roomId);
    }
}