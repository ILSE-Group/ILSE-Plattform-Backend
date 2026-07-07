using Domain.DomainObjects.Topics.Exercises;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.TopicConfiguration.ExerciseConfigurations
{
    internal class LinkingExerciseConfiguration : IEntityTypeConfiguration<LinkingExercise>
    {
        public void Configure(EntityTypeBuilder<LinkingExercise> builder)
        {
            builder.ToTable("LinkingExercises");

            builder.HasMany(e => e.LeftItems)
                .WithOne()
                .HasForeignKey("LinkingExerciseIdLeft")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.RightItems)
                .WithOne()
                .HasForeignKey("LinkingExerciseIdRight")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.CorrectLinks)
                   .WithOne()
                   .HasForeignKey("LinkingExerciseIdCorrect")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}