using Domain.DomainObjects.User.UserEnums;

namespace Domain.DomainObjects
{
    public class OneTimePassword
    {
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public UserRole TargetRole { get; private set; }
        public bool IsUsed { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid CreatedByUserId { get; private set; }
        public Guid UserId { get; private set; }

        private OneTimePassword(Guid id, string code, UserRole targetRole, Guid createdByUserId)
        {
            Id = id;
            Code = code;
            TargetRole = targetRole;
            IsUsed = false;
            CreatedAt = DateTime.UtcNow;
            CreatedByUserId = createdByUserId;
        }

        public static OneTimePassword CreateNew(string code, UserRole targetRole, Guid createdByUserId, Guid userId)
        {
            var otp = new OneTimePassword(Guid.NewGuid(), code, targetRole, createdByUserId);
            otp.UserId = userId;
            return otp;
        }

        public static OneTimePassword Reconstruct(Guid id, string code, UserRole targetRole, bool isUsed, DateTime createdAt, Guid createdByUserId)
        {
            var otp = new OneTimePassword(id, code, targetRole, createdByUserId);
            // Use reflection-free reconstruction via dedicated constructor
            return new OneTimePassword(id, code, targetRole, isUsed, createdAt, createdByUserId);
        }

        private OneTimePassword(Guid id, string code, UserRole targetRole, bool isUsed, DateTime createdAt, Guid createdByUserId)
        {
            Id = id;
            Code = code;
            TargetRole = targetRole;
            IsUsed = isUsed;
            CreatedAt = createdAt;
            CreatedByUserId = createdByUserId;
        }

        /// <summary>
        /// Marks this code as used. Call once after successful login.
        /// </summary>
        public void MarkAsUsed()
        {
            if (IsUsed)
                throw new InvalidOperationException("This code has already been used.");

            IsUsed = true;
        }
    }
}