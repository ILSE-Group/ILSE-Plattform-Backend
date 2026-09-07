using Application.DTOs;

namespace Application.IServices.IProgressServices
{
    public interface IExerciseProgressService
    {
        Task<ExerciseProgressResponse?> GetByExerciseAndUserAsync(Guid exerciseId, Guid userId);
        Task<ExerciseProgressResponse> SubmitMultipleChoiceAsync(Guid exerciseId, SubmitMultipleChoiceAnswerRequest request);
        Task<ExerciseProgressResponse> SubmitDragAndDropAsync(Guid exerciseId, SubmitDragAndDropAnswerRequest request);
        Task<ExerciseProgressResponse> SubmitLinkingAsync(Guid exerciseId, SubmitLinkingAnswerRequest request);
        Task<ExerciseProgressResponse> SubmitClickableImageAsync(Guid exerciseId, SubmitClickableImageAnswerRequest request);
    }
}