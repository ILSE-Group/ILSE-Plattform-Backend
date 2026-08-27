using Domain.DomainObjects.User.UserEnums;

namespace Domain.DomainObjects
{
    public class OneTimePassword
    {
        public Guid Id { get; private set; }
        public string CodeHash { get; private set; }
        public UserRole TargetRole { get; private set; }
        public bool IsUsed { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public Guid CreatedByUserId { get; private set; }
        public Guid UserId { get; private set; }

        private OneTimePassword(Guid id, string codeHash, UserRole targetRole, bool isUsed,
            DateTime createdAt, DateTime expiresAt, Guid createdByUserId, Guid userId)
        {
            Id = id;
            CodeHash = codeHash;
            TargetRole = targetRole;
            IsUsed = isUsed;
            CreatedAt = createdAt;
            ExpiresAt = expiresAt;
            CreatedByUserId = createdByUserId;
            UserId = userId;
        }

        public static OneTimePassword CreateNew(string codeHash, UserRole targetRole, Guid createdByUserId, Guid userId, int expiryDays)
        {
            var now = DateTime.UtcNow;
            return new OneTimePassword(Guid.NewGuid(), codeHash, targetRole, false, now, now.AddDays(expiryDays), createdByUserId, userId);
        }

        public static OneTimePassword Reconstruct(Guid id, string codeHash, UserRole targetRole, bool isUsed,
            DateTime createdAt, DateTime expiresAt, Guid createdByUserId, Guid userId)
        {
            return new OneTimePassword(id, codeHash, targetRole, isUsed, createdAt, expiresAt, createdByUserId, userId);
        }

        public bool IsExpired() => DateTime.UtcNow > ExpiresAt;

        public void MarkAsUsed()
        {
            if (IsUsed)
                throw new InvalidOperationException("This code has already been used.");
            if (IsExpired())
                throw new InvalidOperationException("This code has expired.");
            IsUsed = true;
        }
    }
}