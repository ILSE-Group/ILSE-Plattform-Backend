using Domain.DomainObjects.Progresses;
using Domain.IRepositories.ILevelRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.BaseRepository;

namespace Persistence.Repositories.ProgressRepository
{
    public class LevelRepository : BaseRepository<Level>, ILevelRepository
    {
        public LevelRepository(AppDbContext context) : base(context)
        {
            // Constructor calls base class constructor -> no further initialization needed here
        }

        public async Task<Level?> GetByNameAsync(string name)
            => await _context.Levels
                .FirstOrDefaultAsync(l => l.Name.ToLower() == name.ToLower());

        public async Task<Level?> GetLevelForExperiencePointsAsync(int experiencePoints)
            => await _context.Levels
                .Where(l => l.ExperiencePoints <= experiencePoints)
                .OrderByDescending(l => l.ExperiencePoints)
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<Level>> GetAllOrderedByXpAsync()
            => await _context.Levels
                .OrderBy(l => l.ExperiencePoints)
                .ToListAsync();
    }
}