using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.TopicConfiguration.ExerciseConfigurations
{
    internal class DropZoneConfiguration : IEntityTypeConfiguration<DropZone>
    {
        public void Configure(EntityTypeBuilder<DropZone> builder)
        {
            builder.ToTable("DropZones");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Label)
                   .IsRequired();
        }
    }
}