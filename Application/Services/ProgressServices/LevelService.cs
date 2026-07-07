using Application.IServices.IProgressServices;
using Domain.DomainObjects.Progresses;
using Domain.IRepositories.ILevelRepositories;

namespace Application.Services.ProgressServices
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _levelRepository;

        public LevelService(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }

        public async Task<List<Level>> GetAllAsync()
        {
            return await _levelRepository.GetAllAsync();
        }

        public async Task<Level?> GetCurrentLevelAsync(int experiencePoints)
        {
            var levels = await _levelRepository.GetAllAsync();

            // The current level is the highest one the user has reached
            return levels
                .Where(l => l.ExperiencePoints <= experiencePoints)
                .OrderByDescending(l => l.ExperiencePoints)
                .FirstOrDefault();
        }
    }
}