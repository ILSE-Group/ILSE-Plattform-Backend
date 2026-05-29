using Domain.DomainObjects.User;
using Domain.DomainObjects.User.UserEnums;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.IUserRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByUserLevelIdAsync(Guid userLevelId);
        Task<IEnumerable<User>> GetUsersByRoleAsync(UserRole role);
    }
}
