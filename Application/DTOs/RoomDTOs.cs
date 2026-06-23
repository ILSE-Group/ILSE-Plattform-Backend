namespace Application.DTOs
{
    public record RoomResponse(Guid Id, string Name, int UnlockLevel, int CompletionExperiencePoints);
}