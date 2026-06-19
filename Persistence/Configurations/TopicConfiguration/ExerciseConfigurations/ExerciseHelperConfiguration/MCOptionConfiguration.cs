using Domain.DomainObjects.Topics.Exercises.ExerciseHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.TopicConfiguration.ExerciseConfigurations
{
    internal class MCOptionConfiguration : IEntityTypeConfiguration<MCOption>
    {
        public void Configure(EntityTypeBuilder<MCOption> builder)
        {
            builder.ToTable("MCOptions");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OptionText)
                   .IsRequired();
        }
    }
}