using Microsoft.AspNetCore.Identity;

namespace Persistence.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
    }
}
