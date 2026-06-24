using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.IRepositories.IExerciseRepositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ExerciseRepository(AppDbContext context) : IExerciseRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Exercise> AddAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task DeleteAsync(Guid id)
        {
            var exercise = await GetByIdAsync(id);
            if (exercise is not null)
            {
                _context.Exercises.Remove(exercise);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Exercise> UpdateAsync(Exercise exercise)
        {
            _context.Exercises.Update(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task<Exercise?> GetByIdAsync(Guid id)
            => await _context.Exercises
                .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<IEnumerable<Exercise>> GetAllAsync()
            => await _context.Exercises.ToListAsync();

        public async Task<IEnumerable<Exercise>> GetExercisesByRoomIdAsync(Guid roomId)
            => await _context.Rooms
                .Where(r => r.Id == roomId)
                .SelectMany(r => r.Exercises)
                .ToListAsync();

        public async Task<IEnumerable<Exercise>> GetExercisesByMinXpAsync(int minExperiencePoints)
            => await _context.Exercises
                .Where(e => e.ExperiencePoints >= minExperiencePoints)
                .OrderByDescending(e => e.ExperiencePoints)
                .ToListAsync();
    }
}