using Domain.DomainObjects.Progresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.TopicConfiguration
{
    internal class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.ToTable("Levels");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.ToolImage)
                   .IsRequired();

            builder.Property(e => e.ExperiencePoints)
                   .IsRequired();
        }
    }
}