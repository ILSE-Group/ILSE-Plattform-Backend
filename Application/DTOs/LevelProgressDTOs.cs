namespace Application.DTOs
{
    public record LevelProgressResponse(Guid UserId, int CurrentLevelNumber, int ExperiencePoints, int ExperienceToNextLevel);
}