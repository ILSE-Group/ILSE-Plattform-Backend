using Domain.DomainObjects;
using Domain.IRepositories.IBaseRepository;
using Domain.IRepositories.IOTPRepositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class OTPRepository(AppDbContext context) : IOTPRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<OneTimePassword?> GetByCodeAsync(string code)
        {
            return await _context.OneTimePasswords
                .FirstOrDefaultAsync(o => o.Code == code.ToUpperInvariant());
        }

        public async Task<OneTimePassword?> GetByIdAsync(Guid id)
        {
            return await _context.OneTimePasswords
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(OneTimePassword otp)
        {
            await _context.OneTimePasswords.AddAsync(otp);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OneTimePassword otp)
        {
            _context.OneTimePasswords.Update(otp);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var otp = await GetByIdAsync(id);
            if (otp is not null)
            {
                _context.OneTimePasswords.Remove(otp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OneTimePassword>> GetAllAsync()
        {
            return await _context.OneTimePasswords.ToListAsync();
        }

        Task<OneTimePassword> IBaseRepository<OneTimePassword>.AddAsync(OneTimePassword obj)
        {
            throw new NotImplementedException();
        }

        Task<OneTimePassword> IBaseRepository<OneTimePassword>.UpdateAsync(OneTimePassword obj)
        {
            throw new NotImplementedException();
        }
    }
}