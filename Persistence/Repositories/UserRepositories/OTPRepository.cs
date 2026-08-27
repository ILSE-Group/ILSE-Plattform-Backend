using Domain.DomainObjects;
using Domain.IRepositories.IOTPRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.BaseRepository;

namespace Persistence.Repositories.UserRepository.UserRepository
{
    public class OTPRepository : BaseRepository<OneTimePassword>, IOTPRepository
    {
        public OTPRepository(AppDbContext context) : base(context) { }

        public async Task<OneTimePassword?> GetByCodeHashAsync(string codeHash)
        {
            return await _context.OneTimePasswords
                .FirstOrDefaultAsync(o => o.CodeHash == codeHash);
        }
    }
}