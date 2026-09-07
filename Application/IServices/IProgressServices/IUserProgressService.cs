using Application.DTOs;

namespace Application.IServices.IProgressServices
{
    public interface IUserProgressService
    {
        Task<UserProgressResponse?> GetByUserIdAsync(Guid userId);
        Task<UserProgressResponse> StartAsync(Guid userId);
    }
}