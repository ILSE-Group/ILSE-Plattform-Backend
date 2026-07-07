using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILSE_Plattform.Controllers
{
    [ApiController]
    [Route("api/exercises/{exerciseId}/progress")]
    public class ExerciseProgressController : ControllerBase
    {
        private readonly IExerciseProgressService _exerciseProgressService;

        public ExerciseProgressController(IExerciseProgressService exerciseProgressService)
        {
            _exerciseProgressService = exerciseProgressService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<ExerciseProgressResponse>> GetByExerciseAndUser(Guid exerciseId, Guid userId)
        {
            var progress = await _exerciseProgressService.GetByExerciseAndUserAsync(exerciseId, userId);
            if (progress == null) return NotFound();
            return Ok(progress);
        }
    }
}