namespace Application.DTOs
{
    public record ExerciseResponse(Guid Id, string Title, string Description, int ExperiencePoints, string Type);

    public record MultipleChoiceResponse(Guid Id, string Title, string Description, int ExperiencePoints, List<string> Options)
        : ExerciseResponse(Id, Title, Description, ExperiencePoints, "MultipleChoice");

    public record DragAndDropResponse(Guid Id, string Title, string Description, int ExperiencePoints, List<string> Items, List<string> Zones)
        : ExerciseResponse(Id, Title, Description, ExperiencePoints, "DragAndDrop");

    public record LinkingResponse(Guid Id, string Title, string Description, int ExperiencePoints, List<string> LeftItems, List<string> RightItems)
        : ExerciseResponse(Id, Title, Description, ExperiencePoints, "Linking");

    public record ClickableImageResponse(Guid Id, string Title, string Description, int ExperiencePoints, string ImageUrl)
        : ExerciseResponse(Id, Title, Description, ExperiencePoints, "ClickableImage");
}