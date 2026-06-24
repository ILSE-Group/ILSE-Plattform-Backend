using Microsoft.AspNetCore.Identity;

namespace Persistence.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public int ExperiencePoints { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
    }
}
