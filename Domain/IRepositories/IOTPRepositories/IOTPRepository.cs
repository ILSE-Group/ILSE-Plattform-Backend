using Domain.DomainObjects;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.IOTPRepositories
{
    public interface IOTPRepository : IBaseRepository<OneTimePassword>
    {
        Task<OneTimePassword?> GetByCodeHashAsync(string codeHash);
    }
}