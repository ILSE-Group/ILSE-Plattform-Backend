using Application.DTOs;
using Application.IServices.ITopicServices;
using Microsoft.AspNetCore.Mvc;

namespace ILSE_Plattform.Controllers
{
    [ApiController]
    [Route("api/topics/{topicId}/rooms/{roomId}/exercises")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseResponse>>> GetAll(Guid topicId, Guid roomId)
        {
            var exercises = await _exerciseService.GetExercisesByRoomAsync(roomId);
            return Ok(exercises);
        }

        [HttpGet("{exerciseId}")]
        public async Task<ActionResult<ExerciseResponse>> GetById(Guid topicId, Guid roomId, Guid exerciseId)
        {
            var exercise = await _exerciseService.GetByIdAsync(exerciseId);
            if (exercise == null) return NotFound();

            return Ok(exercise);
        }
    }
}