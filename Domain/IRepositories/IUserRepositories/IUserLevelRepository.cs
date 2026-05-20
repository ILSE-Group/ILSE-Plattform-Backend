using Domain.DomainObjects.User;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.IUserRepositories
{
    public interface IUserLevelRepository : IBaseRepository<UserLevel>
    {
        Task<UserLevel> GetByUserIdAsync(Guid userId);
        Task AddExperiencePointsAsync(Guid userId, int points);
        Task<int> GetCurrentExperiencePointsAsync(Guid userId);
        Task<int> GetCurrentLevelAsync(Guid userId);
    }
}
