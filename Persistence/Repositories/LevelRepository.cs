using Domain.DomainObjects.Progresses;
using Domain.IRepositories.ILevelRepositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class LevelRepository(AppDbContext context) : ILevelRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Level> AddAsync(Level level)
        {
            await _context.Levels.AddAsync(level);
            await _context.SaveChangesAsync();
            return level;
        }

        public async Task DeleteAsync(Guid id)
        {
            var level = await GetByIdAsync(id);
            if (level is not null)
            {
                _context.Levels.Remove(level);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Level> UpdateAsync(Level level)
        {
            _context.Levels.Update(level);
            await _context.SaveChangesAsync();
            return level;
        }

        public async Task<Level?> GetByIdAsync(Guid id)
            => await _context.Levels.FirstOrDefaultAsync(l => l.Id == id);

        public async Task<IEnumerable<Level>> GetAllAsync()
            => await _context.Levels.ToListAsync();

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