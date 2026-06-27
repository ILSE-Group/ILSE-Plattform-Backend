using Persistence.Identity;
using Domain.IRepositories.IUserRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.BaseRepository;
using Domain.DomainObjects.User;

namespace Persistence.Repositories.UserRepositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
            // Constructor calls base class constructor -> no further initialization needed here
        }

        private async Task<User?> MapAsync(AppUser? user)
        {
            if (user is null) return null;

            var roles = await _context.Users.GetRolesAsync(user);
            return new User(
                user.Id,
                user.UserName ?? string.Empty,
                user.Email    ?? string.Empty,
                user.ExperiencePoints,
                roles.ToList().AsReadOnly()
            );
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            var user = await _context.Users.FindByIdAsync(id.ToString());
            return await MapAsync(user);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            var user = await _context.Users.FindByNameAsync(username);
            return await MapAsync(user);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await _context.Users.FindByEmailAsync(email);
            return await MapAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _context.Users.Users.ToListAsync();
            var dtos  = new List<User>();

            foreach (var user in users)
            {
                var dto = await MapAsync(user);
                if (dto is not null) dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role)
        {
            var users = await _context.Users.GetUsersInRoleAsync(role);
            var dtos  = new List<User>();

            foreach (var user in users)
            {
                var dto = await MapAsync(user);
                if (dto is not null) dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<int> GetExperiencePointsAsync(Guid userId)
        {
            var user = await _context.Users.FindByIdAsync(userId.ToString())
                ?? throw new KeyNotFoundException($"User {userId} not found.");
            return user.ExperiencePoints;
        }

        public async Task UpdateExperiencePointsAsync(Guid userId, int newTotal)
        {
            var user = await _context.Users.FindByIdAsync(userId.ToString())
                ?? throw new KeyNotFoundException($"User {userId} not found.");

            user.ExperiencePoints = newTotal;

            var result = await _context.Users.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to update XP for user {userId}: {errors}");
            }
        }

        Task<List<User>> IUserRepository.GetUsersByRoleAsync(string role)
        {
            throw new NotImplementedException();
        }
    }
}