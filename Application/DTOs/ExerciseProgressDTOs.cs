namespace Application.DTOs
{
    public record ExerciseProgressResponse(
        Guid Id,
        Guid ExerciseId,
        Guid UserId,
        bool Completed,
        int ExperiencePointsEarned,
        DateTime? CompletedAt
    );

    public record ExerciseProgressRequest(Guid UserId, bool Completed);

    public record SubmitMultipleChoiceAnswerRequest(Guid UserId, List<int> SelectedOptionIndices);

    public record SubmitDragAndDropAnswerRequest(Guid UserId, List<DragAndDropMappingDto> Mappings);

    public record SubmitLinkingAnswerRequest(Guid UserId, List<LinkMappingDto> Links);

    public record SubmitClickableImageAnswerRequest(Guid UserId, int X, int Y);
}