using Domain.DomainObjects.User;
using Domain.IRepositories.IUserCredentialRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.BaseRepository;

namespace Persistence.Repositories
{
    public class UserCredentialRepository : BaseRepository<UserCredential>, IUserCredentialRepository
    {
        public UserCredentialRepository(AppDbContext context) : base(context) { }

        public async Task<UserCredential?> GetBySecretIdHashAsync(string secretIdHash)
        {
            return await _context.UserCredentials
                .FirstOrDefaultAsync(c => c.SecretIdHash == secretIdHash);
        }

        public async Task<UserCredential?> GetByUserIdAsync(Guid userId)
        {
            return await _context.UserCredentials
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }
}