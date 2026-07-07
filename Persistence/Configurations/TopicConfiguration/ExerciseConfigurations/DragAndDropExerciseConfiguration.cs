using Domain.DomainObjects.Topics.Exercises;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.TopicConfiguration.ExerciseConfigurations
{
    internal class DragAndDropExerciseConfiguration : IEntityTypeConfiguration<DragAndDropExercise>
    {
        public void Configure(EntityTypeBuilder<DragAndDropExercise> builder)
        {
            builder.ToTable("DragAndDropExercises");

            builder.HasMany(e => e.Items)
                   .WithOne()
                   .HasForeignKey("ExerciseId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Zones)
                   .WithOne()
                   .HasForeignKey("ExerciseId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.CorrectMappings)
                   .WithOne()
                   .HasForeignKey("ExerciseId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}