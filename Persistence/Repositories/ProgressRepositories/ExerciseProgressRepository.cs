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