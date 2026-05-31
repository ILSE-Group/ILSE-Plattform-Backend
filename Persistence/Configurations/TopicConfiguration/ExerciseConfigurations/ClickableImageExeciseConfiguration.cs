using Domain.DomainObjects.Topics.Exercises;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.TopicConfiguration.ExerciseConfigurations
{
    internal class ClickableImageExeciseConfiguration : IEntityTypeConfiguration<ClickableImageExercise>
    {
        public void Configure(EntityTypeBuilder<ClickableImageExercise> builder)
        {
            builder.ToTable("ClickableImageExercises");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.ImageUrl).IsRequired();
            builder.HasMany(e => e.ClickableAreas)
                   .WithOne()
                   .HasForeignKey("ExerciseId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
