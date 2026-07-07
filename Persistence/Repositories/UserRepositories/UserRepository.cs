using Domain.DomainObjects.User;
using Domain.DomainObjects.User.UserEnums;
using Domain.IRepositories.IUserRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Identity;
using Persistence.Repositories.BaseRepository;

namespace Persistence.Repositories.UserRepositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(AppDbContext context, UserManager<AppUser> userManager)
            : base(context)
        {
            _userManager = userManager;
        }

        public async Task<User?> GetByUsernameAsync(string username)
            => await _dbSet.FirstOrDefaultAsync(u => u.Username == username);

        public async Task<User?> GetByEmailAsync(string email)
        {
            // Email kennt nur Identity, also erst AppUser suchen, dann über Id den Domain-User laden
            var appUser = await _userManager.FindByEmailAsync(email);
            if (appUser is null) return null;

            return await _dbSet.FirstOrDefaultAsync(u => u.Id == appUser.Id);
        }

        public async Task<List<User>> GetUsersByRoleAsync(string role)
        {
            var userRole = Enum.Parse<UserRole>(role, ignoreCase: true);
            return await _dbSet.Where(u => u.Role == userRole).ToListAsync();
        }

        public async Task<int> GetExperiencePointsAsync(Guid userId)
        {
            var user = await _dbSet.FirstOrDefaultAsync(u => u.Id == userId)
                ?? throw new KeyNotFoundException($"User {userId} not found.");
            return user.ExperiencePoints;
        }

        public async Task UpdateExperiencePointsAsync(Guid userId, int experiencePoints)
        {
            var user = await _dbSet.FirstOrDefaultAsync(u => u.Id == userId)
                ?? throw new KeyNotFoundException($"User {userId} not found.");

            user.AddExperience(experiencePoints);

            await _context.SaveChangesAsync();
        }
    }
}