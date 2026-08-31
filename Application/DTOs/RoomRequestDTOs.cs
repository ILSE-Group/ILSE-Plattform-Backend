namespace Application.DTOs
{
    public record RoomRequest(string Name, int UnlockLevel, int CompletionExperiencePoints);
    public record RoomResponse(Guid Id, string Name, int UnlockLevel, int CompletionExperiencePoints);
}