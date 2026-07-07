using Domain.DomainObjects.Topics.Exercises;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.TopicConfiguration.ExerciseConfigurations
{
    internal class MultipleChoiceMultiAnswerExerciseConfiguration : IEntityTypeConfiguration<MultipleChoiceMultiAnswerExercise>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceMultiAnswerExercise> builder)
        {
            builder.ToTable("MultipleChoiceExercises");

            builder.HasMany(e => e.Options)
                   .WithOne()
                   .HasForeignKey("ExerciseId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.CorrectOptionIds)
                   .WithOne()
                   .HasForeignKey("ExerciseId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}