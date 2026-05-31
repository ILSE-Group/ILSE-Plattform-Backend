using Domain.DomainObjects.Topics.Exercises;
using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.TopicConfiguration.ExerciseConfigurations
{
    internal class ClickableAreaConfiguration : IEntityTypeConfiguration<ClickableArea>
    {
        public void Configure(EntityTypeBuilder<ClickableArea> builder)
        {
            builder.ToTable("ClickableAreas");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.X).IsRequired();
            builder.Property(e => e.Y).IsRequired();
            builder.Property(e => e.Width).IsRequired();
            builder.Property(e => e.Height).IsRequired();
        }
    }
}
