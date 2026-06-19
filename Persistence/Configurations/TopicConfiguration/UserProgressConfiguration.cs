using Domain.DomainObjects.Progresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.ProgressConfigurations
{
    internal class UserProgressConfiguration : IEntityTypeConfiguration<UserProgress>
    {
        public void Configure(EntityTypeBuilder<UserProgress> builder)
        {
            builder.ToTable("UserProgresses");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.UserId).IsRequired();
            builder.Property(e => e.ExperiencePoints).IsRequired();
            builder.HasIndex(e => e.UserId).IsUnique();
        }
    }
}