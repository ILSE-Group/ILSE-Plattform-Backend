namespace Application.DTOs
{
    public abstract record ExerciseRequest(string Title, string Description, int ExperiencePoints, string Type);
    public record MultipleChoiceMultiAnswerRequest(
        string Title,
        string Description,
        int ExperiencePoints,
        List<string> Options,
        List<int> CorrectOptionIndices
    ) : ExerciseRequest(Title, Description, ExperiencePoints, "MultipleChoiceMultiAnswer");
    public record DragAndDropRequest(
        string Title,
        string Description,
        int ExperiencePoints,
        List<string> Items,
        List<string> Zones
    ) : ExerciseRequest(Title, Description, ExperiencePoints, "DragAndDrop");
    public record DragAndDropMappingDto(int ItemIndex, int ZoneIndex);
    public record LinkingRequest(
        string Title,
        string Description,
        int ExperiencePoints,
        List<string> LeftItems,
        List<string> RightItems,
        List<LinkMappingDto> CorrectLinks
    ) : ExerciseRequest(Title, Description, ExperiencePoints, "Linking");
    public record LinkMappingDto(int LeftIndex, int RightIndex);
    public record ClickableImageRequest(
        string Title,
        string Description,
        int ExperiencePoints,
        string ImageUrl,
        List<ClickableAreaDto> ClickableAreas
    ) : ExerciseRequest(Title, Description, ExperiencePoints, "ClickableImage");
    public record ClickableAreaDto(int X, int Y, int Width, int Height);
}