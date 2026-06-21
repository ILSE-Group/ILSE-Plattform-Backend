using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.TopicConfiguration.ExerciseConfigurations
{
    internal class DraggableItemConfiguration : IEntityTypeConfiguration<DraggableItem>
    {
        public void Configure(EntityTypeBuilder<DraggableItem> builder)
        {
            builder.ToTable("DraggableItems");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Content)
                   .IsRequired();
        }
    }
}