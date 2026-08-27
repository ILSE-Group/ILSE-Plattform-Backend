namespace Domain.DomainObjects.User
{
    public class UserCredential
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string SecretIdHash { get; private set; }
        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private UserCredential(Guid id, Guid userId, string secretIdHash, string passwordHash, string passwordSalt, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            SecretIdHash = secretIdHash;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            CreatedAt = createdAt;
        }

        public static UserCredential CreateNew(Guid userId, string secretIdHash, string passwordHash, string passwordSalt)
            => new(Guid.NewGuid(), userId, secretIdHash, passwordHash, passwordSalt, DateTime.UtcNow);

        public static UserCredential Reconstruct(Guid id, Guid userId, string secretIdHash, string passwordHash, string passwordSalt, DateTime createdAt)
            => new(id, userId, secretIdHash, passwordHash, passwordSalt, createdAt);

        public void UpdatePassword(string newPasswordHash, string newPasswordSalt)
        {
            PasswordHash = newPasswordHash;
            PasswordSalt = newPasswordSalt;
        }
    }
}