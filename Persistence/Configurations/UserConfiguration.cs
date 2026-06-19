using Domain.DomainObjects.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.UserConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Username)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.Role)
                   .IsRequired();

            builder.Property(e => e.ExperiencePoints)
                   .IsRequired();
        }
    }
}