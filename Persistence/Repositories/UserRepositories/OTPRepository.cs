using Domain.DomainObjects;
using Domain.IRepositories.IOTPRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.BaseRepository;

namespace Persistence.Repositories.UserRepository.UserRepository
{
    public class OTPRepository : BaseRepository<OneTimePassword>, IOTPRepository
    {
        public OTPRepository(AppDbContext context) : base(context) 
        {
            // Constructor calls base class constructor -> no further initialization needed here
        }

        public async Task<OneTimePassword?> GetByCodeAsync(string code)
        {
            return await _context.OneTimePasswords
                .FirstOrDefaultAsync(o => o.Code == code.ToUpperInvariant());
        }
    }
}