using Persistence.Identity;
using Domain.IRepositories.IUserRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class UserRepository(UserManager<AppUser> userManager) : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager = userManager;

        private async Task<UserDto?> MapAsync(AppUser? user)
        {
            if (user is null) return null;

            var roles = await _userManager.GetRolesAsync(user);
            return new UserDto(
                user.Id,
                user.UserName ?? string.Empty,
                user.Email    ?? string.Empty,
                user.ExperiencePoints,
                roles.ToList().AsReadOnly()
            );
        }

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return await MapAsync(user);
        }

        public async Task<UserDto?> GetByUsernameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return await MapAsync(user);
        }

        public async Task<UserDto?> GetByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await MapAsync(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var dtos  = new List<UserDto>();

            foreach (var user in users)
            {
                var dto = await MapAsync(user);
                if (dto is not null) dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<IEnumerable<UserDto>> GetUsersByRoleAsync(string role)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);
            var dtos  = new List<UserDto>();

            foreach (var user in users)
            {
                var dto = await MapAsync(user);
                if (dto is not null) dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<int> GetExperiencePointsAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString())
                ?? throw new KeyNotFoundException($"User {userId} not found.");
            return user.ExperiencePoints;
        }

        public async Task UpdateExperiencePointsAsync(Guid userId, int newTotal)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString())
                ?? throw new KeyNotFoundException($"User {userId} not found.");

            user.ExperiencePoints = newTotal;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to update XP for user {userId}: {errors}");
            }
        }
    }
}