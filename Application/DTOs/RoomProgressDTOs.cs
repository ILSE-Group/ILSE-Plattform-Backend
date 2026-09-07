namespace Application.DTOs
{
    public record RoomProgressResponse(Guid Id, Guid RoomId, Guid UserId, int ExperiencePoints, bool Completed, int ExercisesCompleted, int ExercisesTotal);
    public record RoomProgressRequest(Guid UserId);
}