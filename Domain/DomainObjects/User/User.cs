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
        public UserLevel UserLevel { get; private set; }
        private User()
        {
            Username = string.Empty;
            UserLevel = null!;
        }

        public User(string username, UserRole userRole)
        {
            Id = Guid.NewGuid();
            Username = username;
            Role = userRole;
            UserLevel = new UserLevel(Id);
        }
    }
}
