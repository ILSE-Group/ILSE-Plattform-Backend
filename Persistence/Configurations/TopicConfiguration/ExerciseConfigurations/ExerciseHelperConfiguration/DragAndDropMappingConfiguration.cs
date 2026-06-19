using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.TopicConfiguration.ExerciseConfigurations
{
    internal class DragAndDropMappingConfiguration : IEntityTypeConfiguration<DragAndDropMapping>
    {
        public void Configure(EntityTypeBuilder<DragAndDropMapping> builder)
        {
            builder.ToTable("DragAndDropMappings");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id)
                   .ValueGeneratedNever(); 
            builder.Property(d => d.ItemId)
                   .IsRequired();
            builder.Property(d => d.DropZoneId)
                   .IsRequired();
        }
    }
}