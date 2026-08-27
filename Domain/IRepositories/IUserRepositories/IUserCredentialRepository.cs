using Domain.DomainObjects.User;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.IUserCredentialRepositories
{
    public interface IUserCredentialRepository : IBaseRepository<UserCredential>
    {
        Task<UserCredential?> GetBySecretIdHashAsync(string secretIdHash);
        Task<UserCredential?> GetByUserIdAsync(Guid userId);
    }
}