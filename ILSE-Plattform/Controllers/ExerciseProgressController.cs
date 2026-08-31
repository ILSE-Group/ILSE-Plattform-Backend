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

        [HttpPost("multiple-choice")]
        public async Task<ActionResult<ExerciseProgressResponse>> SubmitMultipleChoice(
            Guid exerciseId, SubmitMultipleChoiceAnswerRequest request)
        {
            var progress = await _exerciseProgressService.SubmitMultipleChoiceAsync(exerciseId, request);
            return Ok(progress);
        }

        [HttpPost("drag-and-drop")]
        public async Task<ActionResult<ExerciseProgressResponse>> SubmitDragAndDrop(
            Guid exerciseId, SubmitDragAndDropAnswerRequest request)
        {
            var progress = await _exerciseProgressService.SubmitDragAndDropAsync(exerciseId, request);
            return Ok(progress);
        }

        [HttpPost("linking")]
        public async Task<ActionResult<ExerciseProgressResponse>> SubmitLinking(
            Guid exerciseId, SubmitLinkingAnswerRequest request)
        {
            var progress = await _exerciseProgressService.SubmitLinkingAsync(exerciseId, request);
            return Ok(progress);
        }

        [HttpPost("clickable-image")]
        public async Task<ActionResult<ExerciseProgressResponse>> SubmitClickableImage(
            Guid exerciseId, SubmitClickableImageAnswerRequest request)
        {
            var progress = await _exerciseProgressService.SubmitClickableImageAsync(exerciseId, request);
            return Ok(progress);
        }
    }
}