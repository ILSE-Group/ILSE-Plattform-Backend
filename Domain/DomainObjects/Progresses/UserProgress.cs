using System;

namespace Domain.DomainObjects.Progresses
{
    public class UserProgress
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public int ExperiencePoints { get; private set; }

        private UserProgress(Guid id, Guid userId, int experiencePoints)
        {
            Id = id;
            UserId = userId;
            ExperiencePoints = experiencePoints;
        }

        public static UserProgress CreateNew(Guid userId)
        {
            return new UserProgress(Guid.NewGuid(), userId, 0);
        }

        public static UserProgress Reconstruct(Guid id, Guid userId, int experiencePoints)
        {
            return new UserProgress(id, userId, experiencePoints);
        }
    }
}