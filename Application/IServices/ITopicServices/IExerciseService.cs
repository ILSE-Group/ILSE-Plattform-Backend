using Application.DTOs;
using Domain.DomainObjects.Topics.Exercises.BaseExercise;

namespace Application.IServices.ITopicServices
{
    public interface IExerciseService
    {
        Task<List<ExerciseResponse>> GetExercisesByRoomAsync(Guid roomId);
        Task<ExerciseResponse?> GetByIdAsync(Guid exerciseId);

        Task<ExerciseResponse> CreateMultipleChoiceAsync(Guid roomId, MultipleChoiceMultiAnswerRequest request);
        Task<ExerciseResponse> CreateDragAndDropAsync(Guid roomId, DragAndDropRequest request);
        Task<ExerciseResponse> CreateLinkingAsync(Guid roomId, LinkingRequest request);
        Task<ExerciseResponse> CreateClickableImageAsync(Guid roomId, ClickableImageRequest request);
    }
}
