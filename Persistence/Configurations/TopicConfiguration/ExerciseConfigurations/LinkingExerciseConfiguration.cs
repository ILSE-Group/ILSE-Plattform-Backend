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
            builder.HasKey(e => e.Id);

            builder.Property(e => e.LeftItems).IsRequired();
            builder.Property(e => e.RightItems).IsRequired();

            builder.HasMany(e => e.CorrectLinks)
                   .WithOne()
                   .HasForeignKey("ExerciseId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}