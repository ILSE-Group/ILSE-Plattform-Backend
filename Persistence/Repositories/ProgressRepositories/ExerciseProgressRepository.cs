using Domain.DomainObjects.Progresses;
using Domain.IRepositories.IProgressRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.BaseRepository;

namespace Persistence.Repositories.ProgressRepository
{
    public class ExerciseProgressRepository : BaseRepository<ExerciseProgress>, IExerciseProgressRepository
    {
        public ExerciseProgressRepository(AppDbContext context) : base(context)
        {
            // Constructor calls base class constructor -> no further initialization needed here
        }

        public async Task<ExerciseProgress> AddAsync(ExerciseProgress progress)
        {
            await _context.ExerciseProgresses.AddAsync(progress);
            await _context.SaveChangesAsync();
            return progress;
        }

        public async Task DeleteAsync(Guid id)
        {
            var progress = await GetByIdAsync(id);
            if (progress is not null)
            {
                _context.ExerciseProgresses.Remove(progress);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ExerciseProgress> UpdateAsync(ExerciseProgress progress)
        {
            _context.ExerciseProgresses.Update(progress);
            await _context.SaveChangesAsync();
            return progress;
        }

        public async Task<ExerciseProgress?> GetByIdAsync(Guid id)
            => await _context.ExerciseProgresses
                .FirstOrDefaultAsync(ep => ep.Id == id);

        public async Task<IEnumerable<ExerciseProgress>> GetAllAsync()
            => await _context.ExerciseProgresses.ToListAsync();

        public async Task<ExerciseProgress?> GetByUserAndExerciseAsync(Guid userId, Guid exerciseId)
            => await _context.ExerciseProgresses
                .FirstOrDefaultAsync(ep => ep.UserId == userId && ep.ExerciseId == exerciseId);

        public async Task<IEnumerable<ExerciseProgress>> GetAllByUserIdAsync(Guid userId)
            => await _context.ExerciseProgresses
                .Where(ep => ep.UserId == userId)
                .ToListAsync();

        public async Task<bool> IsExerciseCompletedAsync(Guid userId, Guid exerciseId)
            => await _context.ExerciseProgresses
                .AnyAsync(ep => ep.UserId == userId
                             && ep.CompletedExercises.Contains(exerciseId));
    }
}