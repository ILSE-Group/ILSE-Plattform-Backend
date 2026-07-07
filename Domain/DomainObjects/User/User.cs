using System;
using System.Collections.Generic;
using System.Text;
using Domain.DomainObjects.Progresses;
using Domain.DomainObjects.User.UserEnums;

namespace Domain.DomainObjects.User
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public UserRole Role { get; private set; }
        public int ExperiencePoints { get; private set; }

        private User(Guid id, string username, UserRole role, int experiencePoints)
        {
            Id = id;
            Username = username;
            Role = role;
            ExperiencePoints = experiencePoints;
        }

        public static User CreateNew(string username, UserRole role)
        {
            return new User(Guid.NewGuid(), username, role, 0);
        }

        public static User Reconstruct(Guid id, string username, UserRole role, int experiencePoints)
        {
            return new User(id, username, role, experiencePoints);
        }

        public void AddExperience(int points) {
            ExperiencePoints += points;
        }
    }
}
