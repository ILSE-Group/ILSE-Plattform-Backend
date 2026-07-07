using Domain.DomainObjects.Topics.Exercises.BaseExercise;
using Domain.IRepositories.ITopicRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.BaseRepository;

namespace Persistence.Repositories.TopicRepositories
{
    public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(AppDbContext context) : base(context)
        {
            // Constructor calls base class constructor -> no further initialization needed here
        }

        public async Task<List<Exercise>> GetExercisesByRoomIdAsync(Guid roomId)
            => await _context.Rooms
                .Where(r => r.Id == roomId)
                .SelectMany(r => r.Exercises)
                .ToListAsync();

        public async Task<List<Exercise>> GetExercisesByMinXpAsync(int minExperiencePoints)
            => await _context.Exercises
                .Where(e => e.ExperiencePoints >= minExperiencePoints)
                .OrderByDescending(e => e.ExperiencePoints)
                .ToListAsync();
    }
}