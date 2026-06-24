namespace Domain.IRepositories.IUserRepositories
{
    public interface IUserRepository
    {
        Task<UserDto?> GetByIdAsync(Guid id);
        Task<UserDto?> GetByUsernameAsync(string username);
        Task<UserDto?> GetByEmailAsync(string email);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<IEnumerable<UserDto>> GetUsersByRoleAsync(string role);
        Task<int> GetExperiencePointsAsync(Guid userId);
        Task UpdateExperiencePointsAsync(Guid userId, int newTotal);
    }

    public sealed record UserDto(
        Guid   Id,
        string Username,
        string Email,
        int    ExperiencePoints,
        IReadOnlyList<string> Roles
    );
}
