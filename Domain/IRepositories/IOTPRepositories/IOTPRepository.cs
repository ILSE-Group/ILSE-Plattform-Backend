using Domain.DomainObjects;
using Domain.IRepositories.IBaseRepository;

namespace Domain.IRepositories.IOTPRepositories
{
    public interface IOTPRepository : IBaseRepository<OneTimePassword>
    {
        /// <summary>
        /// Finds an OTP by its code string (case-insensitive).
        /// Returns null if no matching code exists.
        /// </summary>
        Task<OneTimePassword?> GetByCodeAsync(string code);
    }
}