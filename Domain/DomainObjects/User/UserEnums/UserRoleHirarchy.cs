using Domain.DomainObjects.User.UserEnums;

namespace BogenElDorado.Domain.Entities.UserObjects.UserEnums
{
    public static class UserRoleHierarchy
    {
        private static readonly Dictionary<UserRole, int> Rank = new()
    {
        { UserRole.Student, 0 },
        { UserRole.Teacher, 10 },
        { UserRole.Admin, 20 }
    };

        public static bool IsAtLeast(this UserRole role, UserRole minimum)
            => Rank[role] >= Rank[minimum];
    }

}