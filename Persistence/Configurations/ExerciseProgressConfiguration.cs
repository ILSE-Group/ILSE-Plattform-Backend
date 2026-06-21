using Domain.DomainObjects.Progresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Persistence.Configurations.ProgressConfigurations
{
    internal class ExerciseProgressConfiguration : IEntityTypeConfiguration<ExerciseProgress>
    {
        public void Configure(EntityTypeBuilder<ExerciseProgress> builder)
        {
            builder.ToTable("ExerciseProgresses");

            builder.HasKey(ep => ep.Id);

            builder.Property(ep => ep.Id)
                   .ValueGeneratedNever();

            builder.Property(ep => ep.UserId)
                   .IsRequired();

            builder.Property(ep => ep.ExerciseId)
                   .IsRequired();

            builder.Property(ep => ep.CompletedExercises)
                   .HasConversion(
                       v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                       v => JsonSerializer.Deserialize<List<Guid>>(v, (JsonSerializerOptions)null)
                   );
        }
    }
}