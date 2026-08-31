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

        [HttpPost("multiple-choice")]
        public async Task<ActionResult<ExerciseResponse>> CreateMultipleChoice(
            Guid topicId, Guid roomId, MultipleChoiceMultiAnswerRequest request)
        {
            var exercise = await _exerciseService.CreateMultipleChoiceAsync(roomId, request);
            return CreatedAtAction(nameof(GetById),
                new { topicId, roomId, exerciseId = exercise.Id }, exercise);
        }

        [HttpPost("drag-and-drop")]
        public async Task<ActionResult<ExerciseResponse>> CreateDragAndDrop(
            Guid topicId, Guid roomId, DragAndDropRequest request)
        {
            var exercise = await _exerciseService.CreateDragAndDropAsync(roomId, request);
            return CreatedAtAction(nameof(GetById),
                new { topicId, roomId, exerciseId = exercise.Id }, exercise);
        }

        [HttpPost("linking")]
        public async Task<ActionResult<ExerciseResponse>> CreateLinking(
            Guid topicId, Guid roomId, LinkingRequest request)
        {
            var exercise = await _exerciseService.CreateLinkingAsync(roomId, request);
            return CreatedAtAction(nameof(GetById),
                new { topicId, roomId, exerciseId = exercise.Id }, exercise);
        }

        [HttpPost("clickable-image")]
        public async Task<ActionResult<ExerciseResponse>> CreateClickableImage(
            Guid topicId, Guid roomId, ClickableImageRequest request)
        {
            var exercise = await _exerciseService.CreateClickableImageAsync(roomId, request);
            return CreatedAtAction(nameof(GetById),
                new { topicId, roomId, exerciseId = exercise.Id }, exercise);
        }
    }
}