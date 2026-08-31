using Application.DTOs;
using Application.IServices.IProgressServices;
using Domain.DomainObjects.Progresses;
using Domain.IRepositories.IProgressRepositories;

namespace Application.Services.ProgressServices
{
    public class UserProgressService(IUserProgressRepository userProgressRepository) : IUserProgressService
    {
        private readonly IUserProgressRepository _userProgressRepository = userProgressRepository;

        public async Task<UserProgressResponse?> GetByUserIdAsync(Guid userId)
        {
            var progress = await _userProgressRepository.GetByUserIdAsync(userId);
            return progress is null ? null : MapToResponse(progress);
        }

        public async Task<UserProgressResponse> StartAsync(Guid userId)
        {
            var existing = await _userProgressRepository.GetByUserIdAsync(userId);
            if (existing is not null)
            {
                return MapToResponse(existing);
            }

            var created = UserProgress.CreateNew(userId);
            await _userProgressRepository.AddAsync(created);
            return MapToResponse(created);
        }

        private static UserProgressResponse MapToResponse(UserProgress progress) =>
            new(
                progress.UserId,
                progress.ExperiencePoints
            );
    }
}