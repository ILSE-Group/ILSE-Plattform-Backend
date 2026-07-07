using Domain.DomainObjects.User;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.IUserRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<List<User>> GetUsersByRoleAsync(string role);
        Task<int> GetExperiencePointsAsync(Guid userId);
        Task UpdateExperiencePointsAsync(Guid userId, int newTotal);
    }
}
