using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainObjects.User
{
    public class UserLevel
    {
        public Guid Id { get ; private set; }
        public Guid UserId { get; private set; }
        public int ExperiencePoints { get; private set; }
        private UserLevel()
        {
        }

        public UserLevel(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            ExperiencePoints = 0;
        }
    }
}
